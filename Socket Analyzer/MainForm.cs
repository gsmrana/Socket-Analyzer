using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Megamind.Net.Sockets;

namespace Socket_Analyzer
{
    public partial class MainForm : Form
    {
        #region Enum

        enum Protocol { TCP, UDP };
        enum EncodeType { Ascii, Hex, Mixed }

        const int ListenerMaxClients = 100;
        const string KnownPortsFileName = "KnownPorts.info";

        readonly List<string> ComboBoxIpList = new List<string>
        {
             "8.8.8.8",
             "127.0.0.1",
             "192.168.0.1",
             "localhost",
             "broadcast",
             "google.com",
             "time.windows.com"
        };

        readonly List<string> ComboBoxPortList = new List<string> { "22", "80", "8080" };

        readonly List<KnownValue> KnownPorts = new List<KnownValue>
        {
            new KnownValue { Value = "21", ProtoCol="TCP", Usage = "FTP", },
            new KnownValue { Value = "22", ProtoCol="TCP", Usage = "SSH", },
            new KnownValue { Value = "80", ProtoCol="TCP", Usage = "HTTP", },
            new KnownValue { Value = "8080", ProtoCol="TCP", Usage = "Alt HTTP" }
        };

        #endregion

        #region Data

        bool _appendCrOnTx = false;
        bool _appendLfOnTx = false;
        bool _sendOnKeyPress = false;
        bool _appendCrOnRx = true;
        bool _rxAutoScrollEnable = true;
        bool _isEventLogClear = true;
        EncodeType _txEncode = EncodeType.Mixed;
        EncodeType _rxDecode = EncodeType.Mixed;


        readonly List<SocketListener> _socketListeners = new List<SocketListener>();
        readonly List<ListenerClient> _listenerClients = new List<ListenerClient>();
        readonly List<SocketClient> _socketClients = new List<SocketClient>();

        #endregion

        #region ctor

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                cbListeners.Font = new Font("Consolas", 9);
                cbListenerClients.Font = new Font("Consolas", 8);
                cbSocketClients.Font = new Font("Consolas", 8);
                richTextBoxTxData.Font = new Font("Consolas", 9);
                richTextBoxExEventLog.Font = new Font("Consolas", 9);
            }
            catch (Exception ex)
            {
                PopupException(ex.Message);
            }
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            try
            {
                // Parse known Ports file
                if (File.Exists(KnownPortsFileName))
                {
                    var lines = File.ReadAllLines(KnownPortsFileName);
                    foreach (var line in lines)
                    {
                        var token = line.Split(',');
                        if (!KnownPorts.Select(p => p.Value).Contains(token[0]))
                            KnownPorts.Add(new KnownValue { Value = token[0], ProtoCol = token[1], Usage = token[2] });

                    }
                }
            }
            catch (Exception ex)
            {
                PopupException(ex.Message);
            }

            try
            {
                var protos = Enum.GetNames(typeof(Protocol));
                cboxSrvProto.Items.AddRange(protos);
                cboxClientProto.Items.AddRange(protos);
                ComboBoxIpList.AddRange(ServerInfo.GetLocalIPs.Select(p => p.ToString()));
                toolStripComboBoxHostName.Items.AddRange(ComboBoxIpList.ToArray());
                comboBoxClientHost.Items.AddRange(ComboBoxIpList.ToArray());
                comboBoxServerPort.Items.AddRange(ComboBoxPortList.ToArray());
                comboBoxClientPort.Items.AddRange(ComboBoxPortList.ToArray());
                comboBoxInterface.Items.AddRange(new string[] { "Any", "localhost" });
                comboBoxInterface.Items.AddRange(ServerInfo.GetLocalIPs.ToArray());

                cboxSrvProto.SelectedIndex = 0;
                cboxClientProto.SelectedIndex = 0;
                toolStripComboBoxHostName.SelectedIndex = 2;
                comboBoxClientHost.SelectedIndex = 2;
                comboBoxServerPort.SelectedIndex = 1;
                comboBoxClientPort.SelectedIndex = 1;
                comboBoxInterface.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                PopupException(ex.Message);
            }
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                _socketClients.ForEach(client => client.Disconnect());
                _listenerClients.ForEach(client => client.Disconnect());
                _socketListeners.ForEach(listener => listener.Stop());
            }
            catch (Exception) { }
        }

        #endregion

        #region Internal Methods

        private void AppendEventLog(string str, Color? color = null, bool appendNewLine = true)
        {
            var clr = color ?? Color.Black;
            if (appendNewLine) str += Environment.NewLine;
            if (_isEventLogClear)
            {
                if (str.StartsWith("\r"))
                    str = str.Remove(0, 1);
                _isEventLogClear = false;
            }

            Invoke(new MethodInvoker(() =>
            {
                richTextBoxExEventLog.AppendText(str, clr);
                if (!richTextBoxExEventLog.Focused)
                    richTextBoxExEventLog.ScrollToCaret();
            }));
        }

        private void UpdateProgress(int percent)
        {
            Invoke(new MethodInvoker(() =>
            {
                toolStripLabelPercent.Text = percent + "%";
            }));
        }

        public static string ByteArrayToHexString(byte[] bytes, string separator = "")
        {
            return BitConverter.ToString(bytes).Replace("-", separator);
        }

        public static byte[] HexStringToByteArray(string hexstr)
        {
            hexstr.Trim();
            hexstr = hexstr.Replace("-", "");
            hexstr = hexstr.Replace(" ", "");
            return Enumerable.Range(0, hexstr.Length)
                             .Where(x => x % 2 == 0)
                             .Select(x => Convert.ToByte(hexstr.Substring(x, 2), 16))
                             .ToArray();
        }

        private void PopupException(string message, string caption = "Exception")
        {
            Invoke(new Action(() =>
            {
                MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }));
        }

        #endregion

        #region Form Events

        private void ButtonStartListen_Click(object sender, EventArgs e)
        {
            try
            {
                var str = comboBoxInterface.Text;
                IPAddress ip;
                if (str == "Any") ip = IPAddress.Any;
                if (str == "localhost") ip = IPAddress.Loopback;
                ip = IPAddress.TryParse(str, out IPAddress temp) ? temp : IPAddress.Any;

                var listener = new SocketListener(ip, int.Parse(comboBoxServerPort.Text));
                listener.OnClientConnected += Listener_OnClientConnected;
                listener.Start();

                _socketListeners.Add(listener);
                cbListeners.Items.Add(listener.LocalEndPoint);
                cbListeners.SelectedItem = listener.LocalEndPoint;
                AppendEventLog("Started Listening on " + listener.LocalEndPoint, Color.BlueViolet);
            }
            catch (Exception ex)
            {
                PopupException(ex.Message, "Listener Exception");
            }
        }

        private void ButtonStopListen_Click(object sender, EventArgs e)
        {
            try
            {
                var localEp = cbListeners.SelectedItem;
                var listener = _socketListeners.Find(l => Equals(l.LocalEndPoint, localEp));
                listener.Stop();

                cbListeners.Items.Remove(listener.LocalEndPoint);
                if (cbListeners.Items.Count > 0) cbListeners.SelectedIndex = 0;
                _socketListeners.Remove(listener);
                AppendEventLog("Stopped Listening on " + listener.LocalEndPoint, Color.BlueViolet);
            }
            catch (Exception ex)
            {
                PopupException(ex.Message, "Listener Exception");
            }
        }

        private void ButtonLcAccept_Click(object sender, EventArgs e)
        {
            MessageBox.Show("ListenerClient auto accept enabled", "Info");
        }

        private void BtnLcDisconnect_Click(object sender, EventArgs e)
        {
            try
            {
                var endPointString = cbListenerClients.SelectedItem;
                var client = _listenerClients.Find(c => Equals(c.EndPointString, endPointString));
                client.Disconnect();
            }
            catch (Exception ex)
            {
                PopupException(ex.Message, "ListenerClient Exception");
            }
        }

        private void ButtonScConnect_Click(object sender, EventArgs e)
        {
            try
            {
                var host = comboBoxClientHost.Text;
                host = host.Replace("https://", "");
                host = host.Replace("http://", "");
                host = host.Replace("/", "");
                comboBoxClientHost.Text = host;
                if (!comboBoxClientHost.Items.Contains(host))
                    comboBoxClientHost.Items.Add(host);

                var socketClient = new SocketClient(host, int.Parse(comboBoxClientPort.Text));
                socketClient.OnAsyncConnectFailed += SocketClient_OnAsyncConnectFailed;
                socketClient.OnConnected += SocketClient_OnConnected;
                socketClient.OnDataSending += SocketClient_OnDataSending;
                socketClient.OnDataReceived += SocketClient_OnDataReceived;
                socketClient.OnConnectionLost += SocketClient_OnConnectionLost;
                socketClient.OnDisconnected += SocketClient_OnDisconnected;
                socketClient.ConnectAsync();

                btnScConnect.Text = "Connecting";
            }
            catch (Exception ex)
            {
                PopupException(ex.Message, "SocketClient Exception");
            }
        }

        private void ButtonScDisconnect_Click(object sender, EventArgs e)
        {
            try
            {
                var endPointString = cbSocketClients.SelectedItem;
                var client = _socketClients.Find(c => Equals(c.EndPointString, endPointString));
                client.Disconnect();
            }
            catch (Exception ex)
            {
                PopupException(ex.Message, "SocketClient Exception");
            }
        }

        private void RichTextBoxTxData_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (_sendOnKeyPress)
                {
                    var txbytes = new byte[] { (byte)e.KeyChar };
                    if (rbtnSocketClient.Checked)
                    {
                        var endPointString = cbSocketClients.SelectedItem;
                        var client = _socketClients.Find(c => Equals(c.EndPointString, endPointString));
                        client.SendData(txbytes);
                    }
                    else //ListenerClient
                    {
                        var endPointString = cbListenerClients.SelectedItem;
                        var client = _listenerClients.Find(c => Equals(c.EndPointString, endPointString));
                        client.SendData(txbytes);
                    }
                }
            }
            catch (Exception ex)
            {
                PopupException(ex.Message, "Exception");
            }
        }

        private void ButtonSend_Click(object sender, EventArgs e)
        {
            try
            {
                var isHexEncoding = false;
                var txstr = richTextBoxTxData.Text;
                if (_txEncode == EncodeType.Ascii) isHexEncoding = false;
                else if (_txEncode == EncodeType.Hex) isHexEncoding = true;
                else isHexEncoding = txstr.StartsWith("0x");

                if (!isHexEncoding && _appendCrOnTx) txstr += "\r";
                if (!isHexEncoding && _appendLfOnTx) txstr += "\n";
                var txbytes = isHexEncoding ? HexStringToByteArray(txstr) : Encoding.ASCII.GetBytes(txstr);

                if (rbtnSocketClient.Checked)
                {
                    var endPointString = cbSocketClients.SelectedItem;
                    var client = _socketClients.Find(c => Equals(c.EndPointString, endPointString));
                    client.SendData(txbytes);
                }
                else //ListenerClient
                {
                    var endPointString = cbListenerClients.SelectedItem;
                    var client = _listenerClients.Find(c => Equals(c.EndPointString, endPointString));
                    client.SendData(txbytes);
                }
            }
            catch (Exception ex)
            {
                PopupException(ex.Message, "Exception");
            }
        }

        #endregion

        #region MenuStrip Events

        private void MenuNew_Click(object sender, EventArgs e)
        {
            Process.Start(Application.ExecutablePath);
        }

        private void MenuOpen_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog())
            {
                ofd.Filter = "Text Files|*.txt|All Files (*.*)|*.*";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    richTextBoxExEventLog.Text = File.ReadAllText(ofd.FileName);
                }
            }
        }

        private void MenuSave_Click(object sender, EventArgs e)
        {
            using (var sfd = new SaveFileDialog())
            {
                sfd.Filter = "Text Files|*.txt|All Files (*.*)|*.*";
                sfd.FileName = "Socket_log.txt";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    richTextBoxExEventLog.SaveFile(sfd.FileName);
                }
            }
        }

        private void MenuExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void EncodeAutoToolStripMenuItemTx_Click(object sender, EventArgs e)
        {
            _txEncode = EncodeType.Mixed;
            encodeAsciiToolStripMenuItemTx.Checked = false;
            encodeHexToolStripMenuItemTx.Checked = false;
        }

        private void EncodeAsciiStringToolStripMenuItemTx_Click(object sender, EventArgs e)
        {
            _txEncode = EncodeType.Ascii;
            encodeAutoToolStripMenuItemTx.Checked = false;
            encodeHexToolStripMenuItemTx.Checked = false;
        }

        private void EncodeHexStringToolStripMenuItemTx_Click(object sender, EventArgs e)
        {
            _txEncode = EncodeType.Hex;
            encodeAutoToolStripMenuItemTx.Checked = false;
            encodeAsciiToolStripMenuItemTx.Checked = false;
        }

        private void EncodeAutoToolStripMenuItemRx_Click(object sender, EventArgs e)
        {
            _rxDecode = EncodeType.Mixed;
            encodeAsciiToolStripMenuItemRx.Checked = false;
            encodeHexToolStripMenuItemRx.Checked = false;
        }

        private void EncodeAsciiStringToolStripMenuItemRx_Click(object sender, EventArgs e)
        {
            _rxDecode = EncodeType.Ascii;
            encodeAutoToolStripMenuItemRx.Checked = false;
            encodeHexToolStripMenuItemRx.Checked = false;
        }

        private void EncodeHexStringToolStripMenuItemRx_Click(object sender, EventArgs e)
        {
            _rxDecode = EncodeType.Hex;
            encodeAutoToolStripMenuItemRx.Checked = false;
            encodeAsciiToolStripMenuItemRx.Checked = false;
        }

        private void SendOnKeyPressToolStripMenuItemTx_Click(object sender, EventArgs e)
        {
            _sendOnKeyPress = sendOnKeyPressToolStripMenuItemTx.Checked;
        }

        private void AppendrToolStripMenuItemTx_Click(object sender, EventArgs e)
        {
            _appendCrOnTx = appendrToolStripMenuItemTx.Checked;
        }

        private void AppendnToolStripMenuItemTx_Click(object sender, EventArgs e)
        {
            _appendLfOnTx = appendnToolStripMenuItemTx.Checked;
        }

        private void AutoScrollToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _rxAutoScrollEnable = autoScrollToolStripMenuItem.Checked;
            richTextBoxExEventLog.Autoscroll = _rxAutoScrollEnable;
        }

        private void AppendrToolStripMenuItemRx_Click(object sender, EventArgs e)
        {
            _appendCrOnRx = appendrToolStripMenuItemRx.Checked;
        }

        private void MenuGetTcpEndPoints_Click(object sender, EventArgs e)
        {
            try
            {
                var header = "TCP EndPoints: ";
                var tableview = new TableViwForm();
                tableview.Tittle = header;
                tableview.ColumnHeaders.Add(new ColumnHeader("#", 40));
                tableview.ColumnHeaders.Add(new ColumnHeader("LocalEndPoint", 180));
                tableview.ColumnHeaders.Add(new ColumnHeader("RemoteEndPoint", 180));
                tableview.ColumnHeaders.Add(new ColumnHeader("State", 100));
                tableview.ColumnHeaders.Add(new ColumnHeader("Remarks", 140));
                var count = 0;
                foreach (var item in ServerInfo.GetTcpEndpoints)
                {
                    count++;
                    tableview.DataRows.Add(new[] { count.ToString(), item.LocalEndPoint.ToString(), item.RemoteEndPoint.ToString(), item.State.ToString() });
                }
                tableview.Show();
            }
            catch (Exception ex)
            {
                PopupException(ex.Message);
            }
        }

        private void MenuListeningPorts_Click(object sender, EventArgs e)
        {
            try
            {
                var header = "Listening TCP/UDP Ports: ";
                var tableview = new TableViwForm();
                tableview.Tittle = header;
                tableview.ColumnHeaders.Add(new ColumnHeader("#", 40));
                tableview.ColumnHeaders.Add(new ColumnHeader("Type", 60));
                tableview.ColumnHeaders.Add(new ColumnHeader("Interface", 150));
                tableview.ColumnHeaders.Add(new ColumnHeader("Port", 100));
                tableview.ColumnHeaders.Add(new ColumnHeader("Usage", 300));
                var count = 0;
                foreach (var item in ServerInfo.GetTcpListeners)
                {
                    count++;
                    var knownport = KnownPorts.FirstOrDefault(p => p.Value == item.Port.ToString());
                    var info = knownport != null ? knownport.Usage : "";
                    tableview.DataRows.Add(new[] { count.ToString(), "TCP", item.Address.ToString(), item.Port.ToString(), info });
                }
                foreach (var item in ServerInfo.GetUdpListeners)
                {
                    count++;
                    var knownport = KnownPorts.FirstOrDefault(p => p.Value == item.Port.ToString());
                    var info = knownport != null ? knownport.Usage : "";
                    tableview.DataRows.Add(new[] { count.ToString(), "UDP", item.Address.ToString(), item.Port.ToString(), info });
                }
                tableview.Show();
            }
            catch (Exception ex)
            {
                PopupException(ex.Message);
            }
        }

        private void MenuListeningProcess_Click(object sender, EventArgs e)
        {
            try
            {
                var header = "Listening TCP/UDP Process: ";
                var tableview = new TableViwForm();
                tableview.Tittle = header;
                tableview.ColumnHeaders.Add(new ColumnHeader("#", 40));
                tableview.ColumnHeaders.Add(new ColumnHeader("Type", 80));
                tableview.ColumnHeaders.Add(new ColumnHeader("EndPoint", 200));
                tableview.ColumnHeaders.Add(new ColumnHeader("PID", 60));
                tableview.ColumnHeaders.Add(new ColumnHeader("Process", 260));
                var count = 0;
                foreach (var p in ProcessPorts.GetProcessPortMap())
                {
                    count++;
                    tableview.DataRows.Add(new[] { count.ToString(), p.Protocol, p.EndPoint, p.ProcessId.ToString(), p.ProcessName + ".exe" });
                }
                tableview.Show();
            }
            catch (Exception ex)
            {
                PopupException(ex.Message);
            }
        }

        private void ToolStripMenuItemPortScanner_Click(object sender, EventArgs e)
        {
            var host = GetInputTextFromToolStrip();
            Task.Run(new Action(() =>
            {
                try
                {
                    var portlist = new List<PortScanResult>();
                    const int MinPort = 1;
                    const int MaxPort = 100;
                    for (int i = MinPort; i <= MaxPort; i++)
                    {
                        portlist.Add(new PortScanResult { Value = i });
                    }
                    AppendEventLog(string.Format("Starting TCP Port Scanning host... {0} from {1} to {2}", host, portlist.First().Value, portlist.Last().Value), Color.DarkGreen);
                    var scancount = 0;
                    var foundcount = 0;
                    UpdateProgress(scancount * 100 / portlist.Count);
                    Parallel.ForEach(portlist, (port) =>
                    {
                        var socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                        try
                        {
                            // ToDo: do the scan without connect
                            socket.Connect(host, port.Value);
                            foundcount++;
                            port.IsOpen = true;
                            var knownport = KnownPorts.FirstOrDefault(p => p.Value == port.Value.ToString());
                            port.Info = knownport != null ? knownport.Usage : "";
                            AppendEventLog(string.Format("{0:00}. {1} \t{2}", foundcount.ToString(), port.Value, port.Info));
                            socket.Close();
                        }
                        catch { }
                        scancount++;
                        UpdateProgress(scancount * 100 / portlist.Count);
                    });
                    AppendEventLog("Port Scanning Completed\r", Color.DarkGreen);

                    var tableview = new TableViwForm();
                    tableview.Tittle = string.Format("TCP Port Scan Result... {0} from {1} to {2}", host, portlist.First().Value, portlist.Last().Value);
                    tableview.ColumnHeaders.Add(new ColumnHeader("#", 40));
                    tableview.ColumnHeaders.Add(new ColumnHeader("Type", 60));
                    tableview.ColumnHeaders.Add(new ColumnHeader("Port", 100));
                    tableview.ColumnHeaders.Add(new ColumnHeader("Usage", 350));
                    var count = 0;
                    foreach (var port in portlist.Where(p => p.IsOpen == true))
                    {
                        count++;
                        tableview.DataRows.Add(new[] { count.ToString(), "TCP", port.Value.ToString(), port.Info });
                    }
                    Invoke(new Action(() => { tableview.Show(); }));
                }
                catch (Exception ex)
                {
                    PopupException(ex.Message);
                }
            }));
        }

        private void ToolStripMenuItemNetScanner_Click(object sender, EventArgs e)
        {
            var host = GetInputTextFromToolStrip();
            var iplist = new List<NetworkScanResult>();
            Task.Run(new Action(() =>
            {
                try
                {
                    var inputip = IPAddress.Parse(host).GetAddressBytes();

                    const int MaxIP = 254;
                    for (byte i = 1; i <= MaxIP; i++)
                    {
                        var ip = new IPAddress(new byte[] { inputip[0], inputip[1], inputip[2], i });
                        iplist.Add(new NetworkScanResult { Address = ip });
                    }
                    AppendEventLog(string.Format("Network Scanning with range... {0} to {1}", iplist.First().Address, iplist.Last().Address), Color.DarkGreen);
                    var scancount = 0;
                    var foundcount = 0;
                    UpdateProgress(scancount * 100 / MaxIP);
                    Parallel.ForEach(iplist, (ip) =>
                    {
                        var pinger = new Ping();
                        var trycount = 3;
                        while (trycount-- > 0)
                        {
                            var resp = pinger.Send(ip.Address);
                            if (resp.Status == IPStatus.Success)
                            {
                                foundcount++;
                                ip.IsAlive = true;
                                ip.RespTime = resp.RoundtripTime;
                                AppendEventLog(string.Format("{0:00}. {1} \t{2}ms", foundcount.ToString(), ip.Address, ip.RespTime));
                                break;
                            }
                        }
                        scancount++;
                        UpdateProgress(scancount * 100 / MaxIP);
                    });
                    AppendEventLog("Network Scanning Completed\r", Color.DarkGreen);

                    var tableview = new TableViwForm();
                    tableview.Tittle = string.Format("Network Scan Result... {0} to {1}", iplist.First().Address, iplist.Last().Address);
                    tableview.ColumnHeaders.Add(new ColumnHeader("#", 40));
                    tableview.ColumnHeaders.Add(new ColumnHeader("Host", 120));
                    tableview.ColumnHeaders.Add(new ColumnHeader("Response Time", 100));
                    tableview.ColumnHeaders.Add(new ColumnHeader("Remarks", 300));
                    var count = 0;
                    foreach (var ip in iplist.Where(p => p.IsAlive == true))
                    {
                        count++;
                        tableview.DataRows.Add(new[] { count.ToString(), ip.Address.ToString(), ip.RespTime.ToString() });
                    }
                    Invoke(new Action(() => { tableview.Show(); }));
                }
                catch (Exception ex)
                {
                    PopupException(ex.Message);
                }
            }));
        }
        private void MenuHttpAnalyzer_Click(object sender, EventArgs e)
        {
            try
            {
                var httpRespForm = new HttpForm();
                httpRespForm.Show();
            }
            catch (Exception ex)
            {
                PopupException(ex.Message);
            }
        }

        private void MenuHttpGetReq_Click(object sender, EventArgs e)
        {
            var host = comboBoxClientHost.Text;
            var location = "/";
            var request = string.Format("GET {0} HTTP/1.1\r\n"
                                    + "Host: {1}\r\n"
                                    + "User-Agent: Chrome/64.0\r\n"
                                    + "\r\n", location, host);

            richTextBoxTxData.Text = request;
        }

        private void MenuHttpGetResp_Click(object sender, EventArgs e)
        {
            var response = string.Format("HTTP/1.1 200 OK\r\n"
                                     + "Transfer-Encoding: chunked\r\n"
                                     + "Content-Type: text/html\r\n"
                                     + "\r\n"
                                     + "26\r\n"
                                     + "Server Time 24-06-2015 05:17:09 am UTC\r\n"
                                     + "0\r\n"
                                     + "\r\n");

            richTextBoxTxData.Text = response;
        }

        private void AlwaysOnTopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.TopMost = !this.TopMost;
        }

        private void MenuAbout_Click(object sender, EventArgs e)
        {
            AboutToolStripButton_Click(sender, e);
        }

        private void MenuUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                var result = MessageBox.Show("Do you want to browse release page?", "Confirmation",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                    Process.Start("https://github.com/gsmrana/Socket-Analyzer/releases");
            }
            catch (Exception ex)
            {
                PopupException(ex.Message);
            }
        }

        #endregion

        #region ToolStrip Event

        private void NewToolStripButton_Click(object sender, EventArgs e)
        {
            Process.Start(Application.ExecutablePath);
        }

        private void OpenToolStripButton_Click(object sender, EventArgs e)
        {
            menuOpen.PerformClick();
        }

        private void SaveToolStripButton_Click(object sender, EventArgs e)
        {
            menuSave.PerformClick();
        }

        private void ToolStripButtonCopyText_Click(object sender, EventArgs e)
        {
            richTextBoxExEventLog.SelectAll();
            richTextBoxExEventLog.Copy();
        }

        private void ToolStripButtonClear_Click(object sender, EventArgs e)
        {
            richTextBoxExEventLog.Clear();
            _isEventLogClear = true;
        }

        private void AboutToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                var aboutbox = new AboutBox();
                aboutbox.ShowDialog();
            }
            catch (Exception ex)
            {
                PopupException(ex.Message);
            }
        }

        private string GetInputTextFromToolStrip()
        {
            var host = toolStripComboBoxHostName.Text;
            host = host.Replace("https://", "");
            host = host.Replace("http://", "");
            host = host.Replace("/", "");
            toolStripComboBoxHostName.Text = host;
            if (!toolStripComboBoxHostName.Items.Contains(host))
                toolStripComboBoxHostName.Items.Add(host);
            return host;
        }

        private void ToolStripButtonPing_Click(object sender, EventArgs e)
        {
            try
            {
                var host = GetInputTextFromToolStrip();
                AppendEventLog(string.Format("Pinging Host... {0}", host), Color.DarkGreen);
                Task.Run(() =>
                {
                    try
                    {
                        var pinger = new Ping();
                        for (int i = 0; i < 4; i++)
                        {
                            var sb = new StringBuilder();
                            var resp = pinger.Send(host);
                            if (resp.Status == IPStatus.Success)
                            {
                                sb.AppendFormat("Reply from {0}: bytes={1} time={2:000}ms",
                                    resp.Address, resp.Buffer.Length, resp.RoundtripTime);
                                if (resp.Options != null) sb.Append(" TTL=" + resp.Options.Ttl);
                            }
                            else sb.Append("Response " + resp.Status);
                            AppendEventLog(sb.ToString(), Color.Blue);
                            Thread.Sleep(100);
                        }
                        AppendEventLog("", Color.Blue);
                    }
                    catch (Exception ex)
                    {
                        AppendEventLog("Exception: " + ex.Message, Color.Magenta);
                    }
                });
            }
            catch (Exception ex)
            {
                AppendEventLog("Exception: " + ex.Message, Color.Magenta);
            }
        }

        private void ToolStripButtonResolve_Click(object sender, EventArgs e)
        {
            try
            {
                var host = GetInputTextFromToolStrip();
                AppendEventLog(string.Format("Resolving DNS of... {0}", host), Color.DarkGreen);
                Task.Run(() =>
                {
                    try
                    {
                        var sb = new StringBuilder();
                        foreach (var item in ServerInfo.ResolveDns(host))
                            sb.AppendLine(item.ToString());
                        AppendEventLog(sb.ToString(), Color.Blue);
                    }
                    catch (Exception ex)
                    {
                        AppendEventLog("Exception: " + ex.Message, Color.Magenta);
                    }
                });
            }
            catch (Exception ex)
            {
                AppendEventLog("Exception: " + ex.Message, Color.Magenta);
            }
        }

        private void ToolStripButtonReverseDns_Click(object sender, EventArgs e)
        {
            try
            {
                var hostip = GetInputTextFromToolStrip();
                AppendEventLog(string.Format("Resolving Hostname of... {0}", hostip), Color.DarkGreen);
                Task.Run(() =>
                {
                    try
                    {
                        var hostname = ServerInfo.ResolveHostname(IPAddress.Parse(hostip));
                        AppendEventLog(hostname + "\r", Color.Blue);
                    }
                    catch (Exception ex)
                    {
                        AppendEventLog("Exception: " + ex.Message, Color.Magenta);
                    }
                });
            }
            catch (Exception ex)
            {
                AppendEventLog("Exception: " + ex.Message, Color.Magenta);
            }
        }

        private void ToolStripButtonNtpRequest_Click(object sender, EventArgs e)
        {
            try
            {
                var host = GetInputTextFromToolStrip();
                var port = 123;
                AppendEventLog(string.Format("Requesting NTP from... {0}:{1}", host, port), Color.DarkGreen);
                Task.Run(() =>
                {
                    try
                    {
                        var ntpDateTime = ServerInfo.GetDatetimeFromNTP(host, port);
                        AppendEventLog("NTP Datetime: " + ntpDateTime + "\r", Color.Blue);
                    }
                    catch (Exception ex)
                    {
                        AppendEventLog("Exception: " + ex.Message, Color.Magenta);
                    }
                });
            }
            catch (Exception ex)
            {
                AppendEventLog("Exception: " + ex.Message, Color.Magenta);
            }
        }

        #endregion

        #region Listener Events

        void Listener_OnClientConnected(Socket sender)
        {
            //Max number of client already connected
            if (_listenerClients.Count >= ListenerMaxClients)
            {
                const string errmsg = "Error 01: Maximum ListenerClient already connected.";
                sender.Send(Encoding.ASCII.GetBytes(errmsg));
                AppendEventLog(string.Format("Rejecting ListenerClient {0} due to {1}", sender.RemoteEndPoint, errmsg), Color.Magenta);
                sender.Close();
                return;
            }

            var listenerClient = new ListenerClient(sender);
            var str = string.Format("ListenerClient Connected from [{0}] [{1} of {2}]", listenerClient.EndPointString, _listenerClients.Count + 1, ListenerMaxClients);
            AppendEventLog(str, Color.DarkOliveGreen);

            listenerClient.OnDataSending += ListenerClient_OnDataSending;
            listenerClient.OnDataReceived += ListenerClient_OnDataReceived;
            listenerClient.OnConnectionLost += ListenerClient_OnConnectionLost;
            listenerClient.OnClientIdleTimeout += ListenerClient_OnClientIdleTimeout;
            listenerClient.OnClientDisconnected += ListenerClient_OnClientDisconnected;
            listenerClient.BeginReceive();

            _listenerClients.Add(listenerClient);
            Invoke(new MethodInvoker(() =>
            {
                cbListenerClients.Items.Add(listenerClient.EndPointString);
                cbListenerClients.SelectedItem = listenerClient.EndPointString;
            }));
        }

        #endregion

        #region Listener Clients Events

        void ListenerClient_OnDataSending(ListenerClient sender, SocketEventArgs e)
        {
            bool encodeAscii;
            if (_txEncode == EncodeType.Ascii) encodeAscii = true;
            else if (_txEncode == EncodeType.Hex) encodeAscii = false;
            else encodeAscii = !e.Data.Any(ch => ch < 10 || ch > 126);

            var txtype = encodeAscii ? "Ascii " : "Binary";
            var txdata = encodeAscii ? Encoding.ASCII.GetString(e.Data) : ByteArrayToHexString(e.Data);
            var str = string.Format("ListenerClient Tx {0} [{1}] --> {2}", txtype, sender.EndPointString, txdata);
            AppendEventLog(str, Color.DarkGreen);
        }

        void ListenerClient_OnDataReceived(ListenerClient sender, SocketEventArgs e)
        {
            bool encodeAscii;
            if (_rxDecode == EncodeType.Ascii) encodeAscii = true;
            else if (_rxDecode == EncodeType.Hex) encodeAscii = false;
            else encodeAscii = !e.Data.Any(ch => ch < 10 || ch > 126);

            var rxtype = encodeAscii ? "Ascii " : "Binary";
            var rxdata = encodeAscii ? Encoding.ASCII.GetString(e.Data) : ByteArrayToHexString(e.Data);
            var str = string.Format("ListenerClient Rx {0} [{1}] <-- {2}", rxtype, sender.EndPointString, rxdata);
            AppendEventLog(str, Color.Blue, _appendCrOnRx);
        }

        void ListenerClient_OnClientIdleTimeout(ListenerClient sender)
        {
            AppendEventLog(string.Format("ListenerClient Idle Timeout [{0}] ", sender.EndPointString), Color.Magenta);
        }

        void ListenerClient_OnConnectionLost(ListenerClient sender, SocketEventArgs e)
        {
            AppendEventLog(string.Format("ListenerClient Connection Lost [{0}] due to {1}", sender.EndPointString, e.Info), Color.Magenta);
        }

        void ListenerClient_OnClientDisconnected(ListenerClient sender)
        {
            AppendEventLog(string.Format("ListenerClient Disconnected [{0}]", sender.EndPointString), Color.DarkOliveGreen);
            _listenerClients.Remove(sender);
            Invoke(new MethodInvoker(() =>
            {
                cbListenerClients.Items.Remove(sender.EndPointString);
                if (cbListenerClients.Items.Count > 0) cbListenerClients.SelectedIndex = 0;
            }));
        }

        #endregion

        #region Socket Clients Events

        void SocketClient_OnAsyncConnectFailed(object sender, SocketEventArgs e)
        {
            var client = sender as SocketClient;
            AppendEventLog(string.Format("SocketClient Failed to Connect... {0}:{1}", client.Host, client.Port), Color.Red);
            AppendEventLog("Exception: " + e.Info, Color.Magenta);
            Invoke(new MethodInvoker(() =>
            {
                btnScConnect.Text = "Connect";
            }));
        }

        private void SocketClient_OnConnected(object sender)
        {
            var client = sender as SocketClient;
            AppendEventLog(string.Format("SocketClient Conencted to [{0}]", client.EndPointString), Color.DarkCyan);
            _socketClients.Add(client);
            Invoke(new MethodInvoker(() =>
            {
                btnScConnect.Text = "Connect";
                cbSocketClients.Items.Add(client.EndPointString);
                cbSocketClients.SelectedItem = client.EndPointString;
            }));
        }

        void SocketClient_OnDataSending(object sender, SocketEventArgs e)
        {
            var client = sender as SocketClient;
            bool encodeAscii;
            if (_txEncode == EncodeType.Ascii) encodeAscii = true;
            else if (_txEncode == EncodeType.Hex) encodeAscii = false;
            else encodeAscii = !e.Data.Any(ch => ch < 10 || ch > 126);

            var txtype = encodeAscii ? "Ascii " : "Binary";
            var txdata = encodeAscii ? Encoding.ASCII.GetString(e.Data) : ByteArrayToHexString(e.Data);
            var str = string.Format("SocketClient Tx {0} [{1}] --> {2}", txtype, client.EndPointString, txdata);
            AppendEventLog(str, Color.DarkGreen);
        }

        void SocketClient_OnDataReceived(object sender, SocketEventArgs e)
        {
            var client = sender as SocketClient;
            bool encodeAscii;
            if (_rxDecode == EncodeType.Ascii) encodeAscii = true;
            else if (_rxDecode == EncodeType.Hex) encodeAscii = false;
            else encodeAscii = !e.Data.Any(ch => ch < 10 || ch > 126);

            var rxtype = encodeAscii ? "Ascii " : "Binary";
            var rxdata = encodeAscii ? Encoding.ASCII.GetString(e.Data) : ByteArrayToHexString(e.Data);
            var str = string.Format("SocketClient Rx {0} [{1}] <-- {2}", rxtype, client.EndPointString, rxdata);
            AppendEventLog(str, Color.Blue, _appendCrOnRx);
        }

        void SocketClient_OnConnectionLost(object sender, SocketEventArgs e)
        {
            var client = sender as SocketClient;
            AppendEventLog(string.Format("SocketClient Connection Lost [{0}] due to {1} ", client.EndPointString, e.Info), Color.Magenta);
        }

        void SocketClient_OnDisconnected(object sender)
        {
            var client = sender as SocketClient;
            AppendEventLog(string.Format("SocketClient Disconnected [{0}]", client.EndPointString), Color.DarkCyan);
            _socketClients.Remove(client);
            Invoke(new MethodInvoker(() =>
            {
                cbSocketClients.Items.Remove(client.EndPointString);
                if (cbSocketClients.Items.Count > 0) cbSocketClients.SelectedIndex = 0;
            }));
        }

        #endregion

        #region Timer Event

        private void Timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                tbListenerStatus.Text = string.Format("Listeners: {0}", _socketListeners.Count);
                tbLcStatus.Text = string.Format("Listener Clients: {0} / {1}", _listenerClients.Count, ListenerMaxClients);
                tbScStatus.Text = string.Format("Socket Clients: {0}", _socketClients.Count);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Timer1_Tick Exception: " + ex.Message);
            }
        }



        #endregion

    }

    #region Prop Class

    public class KnownValue
    {
        public string Value { get; set; }
        public string ProtoCol { get; set; }
        public string Usage { get; set; }
    }

    public class NetworkScanResult
    {
        public bool IsAlive { get; set; }
        public long RespTime { get; set; }
        public IPAddress Address { get; set; }
    }

    public class PortScanResult
    {
        public int Value { get; set; }
        public bool IsOpen { get; set; }
        public string Info { get; set; }
    }

    #endregion

}
