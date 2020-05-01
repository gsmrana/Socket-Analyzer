namespace Socket_Analyzer
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuNew = new System.Windows.Forms.ToolStripMenuItem();
            this.menuOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSave = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.encodeAsciiToolStripMenuItemTx = new System.Windows.Forms.ToolStripMenuItem();
            this.encodeHexToolStripMenuItemTx = new System.Windows.Forms.ToolStripMenuItem();
            this.encodeAutoToolStripMenuItemTx = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.appendrToolStripMenuItemTx = new System.Windows.Forms.ToolStripMenuItem();
            this.appendnToolStripMenuItemTx = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.sendOnKeyPressToolStripMenuItemTx = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.encodeAsciiToolStripMenuItemRx = new System.Windows.Forms.ToolStripMenuItem();
            this.encodeHexToolStripMenuItemRx = new System.Windows.Forms.ToolStripMenuItem();
            this.encodeAutoToolStripMenuItemRx = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.autoScrollToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.appendrToolStripMenuItemRx = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.alwaysOnTopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.menuGetTcpEndpoints = new System.Windows.Forms.ToolStripMenuItem();
            this.menuGetTcpListeners = new System.Windows.Forms.ToolStripMenuItem();
            this.menuListeningProcess = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItemPortScanner = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemNetScanner = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.menuHttpAnalyzer = new System.Windows.Forms.ToolStripMenuItem();
            this.menuHttpGetReq = new System.Windows.Forms.ToolStripMenuItem();
            this.menuHttpGetResp = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.menuOptions = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuUpdate = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.richTextBoxTxData = new System.Windows.Forms.RichTextBox();
            this.rbtnSocketClient = new System.Windows.Forms.RadioButton();
            this.rbtnListenerClient = new System.Windows.Forms.RadioButton();
            this.btnSend = new System.Windows.Forms.Button();
            this.gbServer = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbListeners = new System.Windows.Forms.ComboBox();
            this.btnStopListen = new System.Windows.Forms.Button();
            this.cboxSrvProto = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnStartListen = new System.Windows.Forms.Button();
            this.comboBoxServerPort = new System.Windows.Forms.ComboBox();
            this.comboBoxInterface = new System.Windows.Forms.ComboBox();
            this.gbClient = new System.Windows.Forms.GroupBox();
            this.btnLcDisconnect = new System.Windows.Forms.Button();
            this.btnLcAccept = new System.Windows.Forms.Button();
            this.cbListenerClients = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBoxClientHost = new System.Windows.Forms.ComboBox();
            this.cbSocketClients = new System.Windows.Forms.ComboBox();
            this.comboBoxClientPort = new System.Windows.Forms.ComboBox();
            this.btnScDisconnect = new System.Windows.Forms.Button();
            this.btnScConnect = new System.Windows.Forms.Button();
            this.cboxClientProto = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.richTextBoxExEventLog = new yournamespace.RichTextBoxEx();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tbListenerStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.tbLcStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.tbScStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripLabelPercent = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.newToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.openToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.saveToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripComboBoxHostName = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripButtonPing = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonResolve = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonReverseDns = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonNtpRequest = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonCopyText = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonClear = new System.Windows.Forms.ToolStripButton();
            this.aboutToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.gbServer.SuspendLayout();
            this.gbClient.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.menuStrip1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.splitContainer1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.statusStrip1, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.toolStrip1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(934, 711);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(934, 23);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuNew,
            this.menuOpen,
            this.menuSave,
            this.toolStripSeparator1,
            this.menuExit});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 19);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // menuNew
            // 
            this.menuNew.Image = ((System.Drawing.Image)(resources.GetObject("menuNew.Image")));
            this.menuNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.menuNew.Name = "menuNew";
            this.menuNew.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.menuNew.Size = new System.Drawing.Size(154, 22);
            this.menuNew.Text = "&New";
            this.menuNew.Click += new System.EventHandler(this.MenuNew_Click);
            // 
            // menuOpen
            // 
            this.menuOpen.Image = ((System.Drawing.Image)(resources.GetObject("menuOpen.Image")));
            this.menuOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.menuOpen.Name = "menuOpen";
            this.menuOpen.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.menuOpen.Size = new System.Drawing.Size(154, 22);
            this.menuOpen.Text = "&Open";
            this.menuOpen.Click += new System.EventHandler(this.MenuOpen_Click);
            // 
            // menuSave
            // 
            this.menuSave.Image = ((System.Drawing.Image)(resources.GetObject("menuSave.Image")));
            this.menuSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.menuSave.Name = "menuSave";
            this.menuSave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.menuSave.Size = new System.Drawing.Size(154, 22);
            this.menuSave.Text = "&Save As";
            this.menuSave.Click += new System.EventHandler(this.MenuSave_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(151, 6);
            // 
            // menuExit
            // 
            this.menuExit.Name = "menuExit";
            this.menuExit.Size = new System.Drawing.Size(154, 22);
            this.menuExit.Text = "E&xit";
            this.menuExit.Click += new System.EventHandler(this.MenuExit_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.encodeAsciiToolStripMenuItemTx,
            this.encodeHexToolStripMenuItemTx,
            this.encodeAutoToolStripMenuItemTx,
            this.toolStripSeparator5,
            this.appendrToolStripMenuItemTx,
            this.appendnToolStripMenuItemTx,
            this.toolStripSeparator7,
            this.sendOnKeyPressToolStripMenuItemTx});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(45, 19);
            this.editToolStripMenuItem.Text = "&Send";
            // 
            // encodeAsciiToolStripMenuItemTx
            // 
            this.encodeAsciiToolStripMenuItemTx.CheckOnClick = true;
            this.encodeAsciiToolStripMenuItemTx.Name = "encodeAsciiToolStripMenuItemTx";
            this.encodeAsciiToolStripMenuItemTx.Size = new System.Drawing.Size(169, 22);
            this.encodeAsciiToolStripMenuItemTx.Text = "Encode ASCII";
            this.encodeAsciiToolStripMenuItemTx.Click += new System.EventHandler(this.EncodeAsciiStringToolStripMenuItemTx_Click);
            // 
            // encodeHexToolStripMenuItemTx
            // 
            this.encodeHexToolStripMenuItemTx.CheckOnClick = true;
            this.encodeHexToolStripMenuItemTx.Name = "encodeHexToolStripMenuItemTx";
            this.encodeHexToolStripMenuItemTx.Size = new System.Drawing.Size(169, 22);
            this.encodeHexToolStripMenuItemTx.Text = "Encode HEX";
            this.encodeHexToolStripMenuItemTx.Click += new System.EventHandler(this.EncodeHexStringToolStripMenuItemTx_Click);
            // 
            // encodeAutoToolStripMenuItemTx
            // 
            this.encodeAutoToolStripMenuItemTx.Checked = true;
            this.encodeAutoToolStripMenuItemTx.CheckOnClick = true;
            this.encodeAutoToolStripMenuItemTx.CheckState = System.Windows.Forms.CheckState.Checked;
            this.encodeAutoToolStripMenuItemTx.Name = "encodeAutoToolStripMenuItemTx";
            this.encodeAutoToolStripMenuItemTx.Size = new System.Drawing.Size(169, 22);
            this.encodeAutoToolStripMenuItemTx.Text = "Encode Mixed";
            this.encodeAutoToolStripMenuItemTx.Click += new System.EventHandler(this.EncodeAutoToolStripMenuItemTx_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(166, 6);
            // 
            // appendrToolStripMenuItemTx
            // 
            this.appendrToolStripMenuItemTx.CheckOnClick = true;
            this.appendrToolStripMenuItemTx.Name = "appendrToolStripMenuItemTx";
            this.appendrToolStripMenuItemTx.Size = new System.Drawing.Size(169, 22);
            this.appendrToolStripMenuItemTx.Text = "Append - \\r";
            this.appendrToolStripMenuItemTx.Click += new System.EventHandler(this.AppendrToolStripMenuItemTx_Click);
            // 
            // appendnToolStripMenuItemTx
            // 
            this.appendnToolStripMenuItemTx.CheckOnClick = true;
            this.appendnToolStripMenuItemTx.Name = "appendnToolStripMenuItemTx";
            this.appendnToolStripMenuItemTx.Size = new System.Drawing.Size(169, 22);
            this.appendnToolStripMenuItemTx.Text = "Append - \\n";
            this.appendnToolStripMenuItemTx.Click += new System.EventHandler(this.AppendnToolStripMenuItemTx_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(166, 6);
            // 
            // sendOnKeyPressToolStripMenuItemTx
            // 
            this.sendOnKeyPressToolStripMenuItemTx.CheckOnClick = true;
            this.sendOnKeyPressToolStripMenuItemTx.Name = "sendOnKeyPressToolStripMenuItemTx";
            this.sendOnKeyPressToolStripMenuItemTx.Size = new System.Drawing.Size(169, 22);
            this.sendOnKeyPressToolStripMenuItemTx.Text = "Send on Key Press";
            this.sendOnKeyPressToolStripMenuItemTx.Click += new System.EventHandler(this.SendOnKeyPressToolStripMenuItemTx_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.encodeAsciiToolStripMenuItemRx,
            this.encodeHexToolStripMenuItemRx,
            this.encodeAutoToolStripMenuItemRx,
            this.toolStripSeparator6,
            this.autoScrollToolStripMenuItem,
            this.appendrToolStripMenuItemRx});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(59, 19);
            this.viewToolStripMenuItem.Text = "&Receive";
            // 
            // encodeAsciiToolStripMenuItemRx
            // 
            this.encodeAsciiToolStripMenuItemRx.CheckOnClick = true;
            this.encodeAsciiToolStripMenuItemRx.Name = "encodeAsciiToolStripMenuItemRx";
            this.encodeAsciiToolStripMenuItemRx.Size = new System.Drawing.Size(150, 22);
            this.encodeAsciiToolStripMenuItemRx.Text = "Decode ASCII";
            this.encodeAsciiToolStripMenuItemRx.Click += new System.EventHandler(this.EncodeAsciiStringToolStripMenuItemRx_Click);
            // 
            // encodeHexToolStripMenuItemRx
            // 
            this.encodeHexToolStripMenuItemRx.CheckOnClick = true;
            this.encodeHexToolStripMenuItemRx.Name = "encodeHexToolStripMenuItemRx";
            this.encodeHexToolStripMenuItemRx.Size = new System.Drawing.Size(150, 22);
            this.encodeHexToolStripMenuItemRx.Text = "Decode HEX";
            this.encodeHexToolStripMenuItemRx.Click += new System.EventHandler(this.EncodeHexStringToolStripMenuItemRx_Click);
            // 
            // encodeAutoToolStripMenuItemRx
            // 
            this.encodeAutoToolStripMenuItemRx.Checked = true;
            this.encodeAutoToolStripMenuItemRx.CheckOnClick = true;
            this.encodeAutoToolStripMenuItemRx.CheckState = System.Windows.Forms.CheckState.Checked;
            this.encodeAutoToolStripMenuItemRx.Name = "encodeAutoToolStripMenuItemRx";
            this.encodeAutoToolStripMenuItemRx.Size = new System.Drawing.Size(150, 22);
            this.encodeAutoToolStripMenuItemRx.Text = "Decode Mixed";
            this.encodeAutoToolStripMenuItemRx.Click += new System.EventHandler(this.EncodeAutoToolStripMenuItemRx_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(147, 6);
            // 
            // autoScrollToolStripMenuItem
            // 
            this.autoScrollToolStripMenuItem.Checked = true;
            this.autoScrollToolStripMenuItem.CheckOnClick = true;
            this.autoScrollToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.autoScrollToolStripMenuItem.Name = "autoScrollToolStripMenuItem";
            this.autoScrollToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.autoScrollToolStripMenuItem.Text = "Auto Scroll";
            this.autoScrollToolStripMenuItem.Click += new System.EventHandler(this.AutoScrollToolStripMenuItem_Click);
            // 
            // appendrToolStripMenuItemRx
            // 
            this.appendrToolStripMenuItemRx.Checked = true;
            this.appendrToolStripMenuItemRx.CheckOnClick = true;
            this.appendrToolStripMenuItemRx.CheckState = System.Windows.Forms.CheckState.Checked;
            this.appendrToolStripMenuItemRx.Name = "appendrToolStripMenuItemRx";
            this.appendrToolStripMenuItemRx.Size = new System.Drawing.Size(150, 22);
            this.appendrToolStripMenuItemRx.Text = "Append - \\r";
            this.appendrToolStripMenuItemRx.Click += new System.EventHandler(this.AppendrToolStripMenuItemRx_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.alwaysOnTopToolStripMenuItem,
            this.toolStripSeparator9,
            this.menuGetTcpEndpoints,
            this.menuGetTcpListeners,
            this.menuListeningProcess,
            this.toolStripSeparator3,
            this.toolStripMenuItemPortScanner,
            this.toolStripMenuItemNetScanner,
            this.toolStripSeparator8,
            this.menuHttpAnalyzer,
            this.menuHttpGetReq,
            this.menuHttpGetResp,
            this.toolStripSeparator10,
            this.menuOptions});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(46, 19);
            this.toolsToolStripMenuItem.Text = "&Tools";
            // 
            // alwaysOnTopToolStripMenuItem
            // 
            this.alwaysOnTopToolStripMenuItem.Name = "alwaysOnTopToolStripMenuItem";
            this.alwaysOnTopToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.alwaysOnTopToolStripMenuItem.Text = "&Always on Top";
            this.alwaysOnTopToolStripMenuItem.Click += new System.EventHandler(this.AlwaysOnTopToolStripMenuItem_Click);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(167, 6);
            // 
            // menuGetTcpEndpoints
            // 
            this.menuGetTcpEndpoints.Name = "menuGetTcpEndpoints";
            this.menuGetTcpEndpoints.Size = new System.Drawing.Size(170, 22);
            this.menuGetTcpEndpoints.Text = "TCP Endpoints";
            this.menuGetTcpEndpoints.Click += new System.EventHandler(this.MenuGetTcpEndPoints_Click);
            // 
            // menuGetTcpListeners
            // 
            this.menuGetTcpListeners.Name = "menuGetTcpListeners";
            this.menuGetTcpListeners.Size = new System.Drawing.Size(170, 22);
            this.menuGetTcpListeners.Text = "TCP/UDP Ports";
            this.menuGetTcpListeners.Click += new System.EventHandler(this.MenuListeningPorts_Click);
            // 
            // menuListeningProcess
            // 
            this.menuListeningProcess.Name = "menuListeningProcess";
            this.menuListeningProcess.Size = new System.Drawing.Size(170, 22);
            this.menuListeningProcess.Text = "TCP/UDP Process";
            this.menuListeningProcess.Click += new System.EventHandler(this.MenuListeningProcess_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(167, 6);
            // 
            // toolStripMenuItemPortScanner
            // 
            this.toolStripMenuItemPortScanner.Name = "toolStripMenuItemPortScanner";
            this.toolStripMenuItemPortScanner.Size = new System.Drawing.Size(170, 22);
            this.toolStripMenuItemPortScanner.Text = "Port Scanner";
            this.toolStripMenuItemPortScanner.Click += new System.EventHandler(this.ToolStripMenuItemPortScanner_Click);
            // 
            // toolStripMenuItemNetScanner
            // 
            this.toolStripMenuItemNetScanner.Name = "toolStripMenuItemNetScanner";
            this.toolStripMenuItemNetScanner.Size = new System.Drawing.Size(170, 22);
            this.toolStripMenuItemNetScanner.Text = "Network Scanner";
            this.toolStripMenuItemNetScanner.Click += new System.EventHandler(this.ToolStripMenuItemNetScanner_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(167, 6);
            // 
            // menuHttpAnalyzer
            // 
            this.menuHttpAnalyzer.Name = "menuHttpAnalyzer";
            this.menuHttpAnalyzer.Size = new System.Drawing.Size(170, 22);
            this.menuHttpAnalyzer.Text = "http Analyzer";
            this.menuHttpAnalyzer.Click += new System.EventHandler(this.MenuHttpAnalyzer_Click);
            // 
            // menuHttpGetReq
            // 
            this.menuHttpGetReq.Name = "menuHttpGetReq";
            this.menuHttpGetReq.Size = new System.Drawing.Size(170, 22);
            this.menuHttpGetReq.Text = "http Get Request";
            this.menuHttpGetReq.Click += new System.EventHandler(this.MenuHttpGetReq_Click);
            // 
            // menuHttpGetResp
            // 
            this.menuHttpGetResp.Name = "menuHttpGetResp";
            this.menuHttpGetResp.Size = new System.Drawing.Size(170, 22);
            this.menuHttpGetResp.Text = "http Get Response";
            this.menuHttpGetResp.Click += new System.EventHandler(this.MenuHttpGetResp_Click);
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            this.toolStripSeparator10.Size = new System.Drawing.Size(167, 6);
            // 
            // menuOptions
            // 
            this.menuOptions.Name = "menuOptions";
            this.menuOptions.Size = new System.Drawing.Size(170, 22);
            this.menuOptions.Text = "&Options";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuUpdate,
            this.menuAbout});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 19);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // menuUpdate
            // 
            this.menuUpdate.Name = "menuUpdate";
            this.menuUpdate.Size = new System.Drawing.Size(121, 22);
            this.menuUpdate.Text = "Update...";
            this.menuUpdate.Click += new System.EventHandler(this.MenuUpdate_Click);
            // 
            // menuAbout
            // 
            this.menuAbout.Name = "menuAbout";
            this.menuAbout.Size = new System.Drawing.Size(121, 22);
            this.menuAbout.Text = "About...";
            this.menuAbout.Click += new System.EventHandler(this.MenuAbout_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(3, 51);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.richTextBoxExEventLog);
            this.splitContainer1.Size = new System.Drawing.Size(928, 637);
            this.splitContainer1.SplitterDistance = 264;
            this.splitContainer1.TabIndex = 2;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.groupBox3, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.gbServer, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.gbClient, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.groupBox1, 0, 2);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 4;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 145F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 89F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 141F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(260, 633);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.richTextBoxTxData);
            this.groupBox3.Controls.Add(this.rbtnSocketClient);
            this.groupBox3.Controls.Add(this.rbtnListenerClient);
            this.groupBox3.Controls.Add(this.btnSend);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(3, 378);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(254, 252);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Data Send";
            // 
            // richTextBoxTxData
            // 
            this.richTextBoxTxData.Location = new System.Drawing.Point(6, 19);
            this.richTextBoxTxData.Name = "richTextBoxTxData";
            this.richTextBoxTxData.Size = new System.Drawing.Size(242, 170);
            this.richTextBoxTxData.TabIndex = 4;
            this.richTextBoxTxData.Text = "hi";
            this.richTextBoxTxData.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.RichTextBoxTxData_KeyPress);
            // 
            // rbtnSocketClient
            // 
            this.rbtnSocketClient.AutoSize = true;
            this.rbtnSocketClient.Checked = true;
            this.rbtnSocketClient.Location = new System.Drawing.Point(17, 218);
            this.rbtnSocketClient.Name = "rbtnSocketClient";
            this.rbtnSocketClient.Size = new System.Drawing.Size(88, 17);
            this.rbtnSocketClient.TabIndex = 2;
            this.rbtnSocketClient.TabStop = true;
            this.rbtnSocketClient.Text = "Socket Client";
            this.rbtnSocketClient.UseVisualStyleBackColor = true;
            // 
            // rbtnListenerClient
            // 
            this.rbtnListenerClient.AutoSize = true;
            this.rbtnListenerClient.Location = new System.Drawing.Point(17, 195);
            this.rbtnListenerClient.Name = "rbtnListenerClient";
            this.rbtnListenerClient.Size = new System.Drawing.Size(91, 17);
            this.rbtnListenerClient.TabIndex = 1;
            this.rbtnListenerClient.Text = "Listener Client";
            this.rbtnListenerClient.UseVisualStyleBackColor = true;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(145, 195);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(101, 40);
            this.btnSend.TabIndex = 3;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.ButtonSend_Click);
            // 
            // gbServer
            // 
            this.gbServer.Controls.Add(this.label5);
            this.gbServer.Controls.Add(this.cbListeners);
            this.gbServer.Controls.Add(this.btnStopListen);
            this.gbServer.Controls.Add(this.cboxSrvProto);
            this.gbServer.Controls.Add(this.label2);
            this.gbServer.Controls.Add(this.label1);
            this.gbServer.Controls.Add(this.btnStartListen);
            this.gbServer.Controls.Add(this.comboBoxServerPort);
            this.gbServer.Controls.Add(this.comboBoxInterface);
            this.gbServer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbServer.Location = new System.Drawing.Point(3, 3);
            this.gbServer.Name = "gbServer";
            this.gbServer.Size = new System.Drawing.Size(254, 139);
            this.gbServer.TabIndex = 0;
            this.gbServer.TabStop = false;
            this.gbServer.Text = "Listeners";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 76);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Listeners";
            // 
            // cbListeners
            // 
            this.cbListeners.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbListeners.FormattingEnabled = true;
            this.cbListeners.Location = new System.Drawing.Point(69, 73);
            this.cbListeners.Name = "cbListeners";
            this.cbListeners.Size = new System.Drawing.Size(177, 21);
            this.cbListeners.TabIndex = 2;
            // 
            // btnStopListen
            // 
            this.btnStopListen.Location = new System.Drawing.Point(161, 100);
            this.btnStopListen.Name = "btnStopListen";
            this.btnStopListen.Size = new System.Drawing.Size(85, 26);
            this.btnStopListen.TabIndex = 5;
            this.btnStopListen.Text = "Stop";
            this.btnStopListen.UseVisualStyleBackColor = true;
            this.btnStopListen.Click += new System.EventHandler(this.ButtonStopListen_Click);
            // 
            // cboxSrvProto
            // 
            this.cboxSrvProto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxSrvProto.FormattingEnabled = true;
            this.cboxSrvProto.Location = new System.Drawing.Point(69, 46);
            this.cboxSrvProto.Name = "cboxSrvProto";
            this.cboxSrvProto.Size = new System.Drawing.Size(85, 21);
            this.cboxSrvProto.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Bind Port";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Interface";
            // 
            // btnStartListen
            // 
            this.btnStartListen.Location = new System.Drawing.Point(69, 100);
            this.btnStartListen.Name = "btnStartListen";
            this.btnStartListen.Size = new System.Drawing.Size(85, 26);
            this.btnStartListen.TabIndex = 3;
            this.btnStartListen.Text = "Start";
            this.btnStartListen.UseVisualStyleBackColor = true;
            this.btnStartListen.Click += new System.EventHandler(this.ButtonStartListen_Click);
            // 
            // comboBoxServerPort
            // 
            this.comboBoxServerPort.FormattingEnabled = true;
            this.comboBoxServerPort.Location = new System.Drawing.Point(161, 46);
            this.comboBoxServerPort.Name = "comboBoxServerPort";
            this.comboBoxServerPort.Size = new System.Drawing.Size(85, 21);
            this.comboBoxServerPort.TabIndex = 4;
            this.comboBoxServerPort.Text = "80";
            // 
            // comboBoxInterface
            // 
            this.comboBoxInterface.FormattingEnabled = true;
            this.comboBoxInterface.Location = new System.Drawing.Point(69, 19);
            this.comboBoxInterface.Name = "comboBoxInterface";
            this.comboBoxInterface.Size = new System.Drawing.Size(177, 21);
            this.comboBoxInterface.TabIndex = 0;
            this.comboBoxInterface.Text = "Any";
            // 
            // gbClient
            // 
            this.gbClient.Controls.Add(this.btnLcDisconnect);
            this.gbClient.Controls.Add(this.btnLcAccept);
            this.gbClient.Controls.Add(this.cbListenerClients);
            this.gbClient.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbClient.Location = new System.Drawing.Point(3, 148);
            this.gbClient.Name = "gbClient";
            this.gbClient.Size = new System.Drawing.Size(254, 83);
            this.gbClient.TabIndex = 1;
            this.gbClient.TabStop = false;
            this.gbClient.Text = "Listener Clients";
            // 
            // btnLcDisconnect
            // 
            this.btnLcDisconnect.Location = new System.Drawing.Point(161, 46);
            this.btnLcDisconnect.Name = "btnLcDisconnect";
            this.btnLcDisconnect.Size = new System.Drawing.Size(85, 26);
            this.btnLcDisconnect.TabIndex = 3;
            this.btnLcDisconnect.Text = "Disconnect";
            this.btnLcDisconnect.UseVisualStyleBackColor = true;
            this.btnLcDisconnect.Click += new System.EventHandler(this.BtnLcDisconnect_Click);
            // 
            // btnLcAccept
            // 
            this.btnLcAccept.Location = new System.Drawing.Point(69, 46);
            this.btnLcAccept.Name = "btnLcAccept";
            this.btnLcAccept.Size = new System.Drawing.Size(85, 26);
            this.btnLcAccept.TabIndex = 2;
            this.btnLcAccept.Text = "Accept";
            this.btnLcAccept.UseVisualStyleBackColor = true;
            this.btnLcAccept.Click += new System.EventHandler(this.ButtonLcAccept_Click);
            // 
            // cbListenerClients
            // 
            this.cbListenerClients.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbListenerClients.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbListenerClients.FormattingEnabled = true;
            this.cbListenerClients.Location = new System.Drawing.Point(3, 16);
            this.cbListenerClients.Name = "cbListenerClients";
            this.cbListenerClients.Size = new System.Drawing.Size(248, 21);
            this.cbListenerClients.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBoxClientHost);
            this.groupBox1.Controls.Add(this.cbSocketClients);
            this.groupBox1.Controls.Add(this.comboBoxClientPort);
            this.groupBox1.Controls.Add(this.btnScDisconnect);
            this.groupBox1.Controls.Add(this.btnScConnect);
            this.groupBox1.Controls.Add(this.cboxClientProto);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 237);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(254, 135);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Socket Clients";
            // 
            // comboBoxClientHost
            // 
            this.comboBoxClientHost.FormattingEnabled = true;
            this.comboBoxClientHost.Location = new System.Drawing.Point(69, 46);
            this.comboBoxClientHost.Name = "comboBoxClientHost";
            this.comboBoxClientHost.Size = new System.Drawing.Size(177, 21);
            this.comboBoxClientHost.TabIndex = 0;
            this.comboBoxClientHost.Text = "localhost";
            // 
            // cbSocketClients
            // 
            this.cbSocketClients.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbSocketClients.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSocketClients.FormattingEnabled = true;
            this.cbSocketClients.Location = new System.Drawing.Point(3, 16);
            this.cbSocketClients.Name = "cbSocketClients";
            this.cbSocketClients.Size = new System.Drawing.Size(248, 21);
            this.cbSocketClients.TabIndex = 2;
            // 
            // comboBoxClientPort
            // 
            this.comboBoxClientPort.FormattingEnabled = true;
            this.comboBoxClientPort.Location = new System.Drawing.Point(161, 73);
            this.comboBoxClientPort.Name = "comboBoxClientPort";
            this.comboBoxClientPort.Size = new System.Drawing.Size(85, 21);
            this.comboBoxClientPort.TabIndex = 4;
            this.comboBoxClientPort.Text = "80";
            // 
            // btnScDisconnect
            // 
            this.btnScDisconnect.Location = new System.Drawing.Point(161, 100);
            this.btnScDisconnect.Name = "btnScDisconnect";
            this.btnScDisconnect.Size = new System.Drawing.Size(85, 26);
            this.btnScDisconnect.TabIndex = 5;
            this.btnScDisconnect.Text = "Disconnect";
            this.btnScDisconnect.UseVisualStyleBackColor = true;
            this.btnScDisconnect.Click += new System.EventHandler(this.ButtonScDisconnect_Click);
            // 
            // btnScConnect
            // 
            this.btnScConnect.Location = new System.Drawing.Point(69, 100);
            this.btnScConnect.Name = "btnScConnect";
            this.btnScConnect.Size = new System.Drawing.Size(85, 26);
            this.btnScConnect.TabIndex = 3;
            this.btnScConnect.Text = "Connect";
            this.btnScConnect.UseVisualStyleBackColor = true;
            this.btnScConnect.Click += new System.EventHandler(this.ButtonScConnect_Click);
            // 
            // cboxClientProto
            // 
            this.cboxClientProto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxClientProto.FormattingEnabled = true;
            this.cboxClientProto.Location = new System.Drawing.Point(69, 73);
            this.cboxClientProto.Name = "cboxClientProto";
            this.cboxClientProto.Size = new System.Drawing.Size(86, 21);
            this.cboxClientProto.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Host";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Port";
            // 
            // richTextBoxExEventLog
            // 
            this.richTextBoxExEventLog.Autoscroll = true;
            this.richTextBoxExEventLog.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.richTextBoxExEventLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxExEventLog.Location = new System.Drawing.Point(0, 0);
            this.richTextBoxExEventLog.Name = "richTextBoxExEventLog";
            this.richTextBoxExEventLog.ReadOnly = true;
            this.richTextBoxExEventLog.Size = new System.Drawing.Size(656, 633);
            this.richTextBoxExEventLog.TabIndex = 0;
            this.richTextBoxExEventLog.Text = "";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbListenerStatus,
            this.tbLcStatus,
            this.tbScStatus,
            this.toolStripStatusLabel1,
            this.toolStripLabelPercent});
            this.statusStrip1.Location = new System.Drawing.Point(0, 691);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(934, 20);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tbListenerStatus
            // 
            this.tbListenerStatus.Name = "tbListenerStatus";
            this.tbListenerStatus.Size = new System.Drawing.Size(83, 15);
            this.tbListenerStatus.Text = "Listener Status";
            // 
            // tbLcStatus
            // 
            this.tbLcStatus.Margin = new System.Windows.Forms.Padding(20, 3, 0, 2);
            this.tbLcStatus.Name = "tbLcStatus";
            this.tbLcStatus.Size = new System.Drawing.Size(117, 15);
            this.tbLcStatus.Text = "Listener Client Status";
            // 
            // tbScStatus
            // 
            this.tbScStatus.Margin = new System.Windows.Forms.Padding(20, 3, 0, 2);
            this.tbScStatus.Name = "tbScStatus";
            this.tbScStatus.Size = new System.Drawing.Size(111, 15);
            this.tbScStatus.Text = "Socket Client Status";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Margin = new System.Windows.Forms.Padding(20, 3, 0, 2);
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(55, 15);
            this.toolStripStatusLabel1.Text = "Progress:";
            // 
            // toolStripLabelPercent
            // 
            this.toolStripLabelPercent.Name = "toolStripLabelPercent";
            this.toolStripLabelPercent.Size = new System.Drawing.Size(47, 15);
            this.toolStripLabelPercent.Text = "percent";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripButton,
            this.openToolStripButton,
            this.saveToolStripButton,
            this.toolStripSeparator4,
            this.toolStripComboBoxHostName,
            this.toolStripButtonPing,
            this.toolStripButtonResolve,
            this.toolStripButtonReverseDns,
            this.toolStripButtonNtpRequest,
            this.toolStripSeparator2,
            this.toolStripButtonCopyText,
            this.toolStripButtonClear,
            this.aboutToolStripButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 23);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(934, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // newToolStripButton
            // 
            this.newToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.newToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("newToolStripButton.Image")));
            this.newToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newToolStripButton.Name = "newToolStripButton";
            this.newToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.newToolStripButton.Text = "&New";
            this.newToolStripButton.Click += new System.EventHandler(this.NewToolStripButton_Click);
            // 
            // openToolStripButton
            // 
            this.openToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.openToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripButton.Image")));
            this.openToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openToolStripButton.Name = "openToolStripButton";
            this.openToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.openToolStripButton.Text = "&Open";
            this.openToolStripButton.Click += new System.EventHandler(this.OpenToolStripButton_Click);
            // 
            // saveToolStripButton
            // 
            this.saveToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.saveToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripButton.Image")));
            this.saveToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveToolStripButton.Name = "saveToolStripButton";
            this.saveToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.saveToolStripButton.Text = "&Save";
            this.saveToolStripButton.Click += new System.EventHandler(this.SaveToolStripButton_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripComboBoxHostName
            // 
            this.toolStripComboBoxHostName.Name = "toolStripComboBoxHostName";
            this.toolStripComboBoxHostName.Size = new System.Drawing.Size(185, 25);
            // 
            // toolStripButtonPing
            // 
            this.toolStripButtonPing.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonPing.Image")));
            this.toolStripButtonPing.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonPing.Name = "toolStripButtonPing";
            this.toolStripButtonPing.Size = new System.Drawing.Size(51, 22);
            this.toolStripButtonPing.Text = "Ping";
            this.toolStripButtonPing.Click += new System.EventHandler(this.ToolStripButtonPing_Click);
            // 
            // toolStripButtonResolve
            // 
            this.toolStripButtonResolve.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonResolve.Image")));
            this.toolStripButtonResolve.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonResolve.Name = "toolStripButtonResolve";
            this.toolStripButtonResolve.Size = new System.Drawing.Size(50, 22);
            this.toolStripButtonResolve.Text = "DNS";
            this.toolStripButtonResolve.Click += new System.EventHandler(this.ToolStripButtonResolve_Click);
            // 
            // toolStripButtonReverseDns
            // 
            this.toolStripButtonReverseDns.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonReverseDns.Image")));
            this.toolStripButtonReverseDns.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonReverseDns.Name = "toolStripButtonReverseDns";
            this.toolStripButtonReverseDns.Size = new System.Drawing.Size(82, 22);
            this.toolStripButtonReverseDns.Text = "Hostname";
            this.toolStripButtonReverseDns.Click += new System.EventHandler(this.ToolStripButtonReverseDns_Click);
            // 
            // toolStripButtonNtpRequest
            // 
            this.toolStripButtonNtpRequest.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonNtpRequest.Image")));
            this.toolStripButtonNtpRequest.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonNtpRequest.Name = "toolStripButtonNtpRequest";
            this.toolStripButtonNtpRequest.Size = new System.Drawing.Size(49, 22);
            this.toolStripButtonNtpRequest.Text = "NTP";
            this.toolStripButtonNtpRequest.Click += new System.EventHandler(this.ToolStripButtonNtpRequest_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButtonCopyText
            // 
            this.toolStripButtonCopyText.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonCopyText.Image")));
            this.toolStripButtonCopyText.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonCopyText.Name = "toolStripButtonCopyText";
            this.toolStripButtonCopyText.Size = new System.Drawing.Size(79, 22);
            this.toolStripButtonCopyText.Text = "Copy Text";
            this.toolStripButtonCopyText.Click += new System.EventHandler(this.ToolStripButtonCopyText_Click);
            // 
            // toolStripButtonClear
            // 
            this.toolStripButtonClear.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonClear.Image")));
            this.toolStripButtonClear.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonClear.Name = "toolStripButtonClear";
            this.toolStripButtonClear.Size = new System.Drawing.Size(77, 22);
            this.toolStripButtonClear.Text = "Clear Log";
            this.toolStripButtonClear.Click += new System.EventHandler(this.ToolStripButtonClear_Click);
            // 
            // aboutToolStripButton
            // 
            this.aboutToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("aboutToolStripButton.Image")));
            this.aboutToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.aboutToolStripButton.Name = "aboutToolStripButton";
            this.aboutToolStripButton.Size = new System.Drawing.Size(60, 22);
            this.aboutToolStripButton.Text = "About";
            this.aboutToolStripButton.Click += new System.EventHandler(this.AboutToolStripButton_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(934, 711);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(500, 400);
            this.Name = "MainForm";
            this.Text = "Socket Analyzer";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.gbServer.ResumeLayout(false);
            this.gbServer.PerformLayout();
            this.gbClient.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuNew;
        private System.Windows.Forms.ToolStripMenuItem menuOpen;
        private System.Windows.Forms.ToolStripMenuItem menuSave;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem autoScrollToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripMenuItem encodeAutoToolStripMenuItemTx;
        private System.Windows.Forms.ToolStripMenuItem encodeHexToolStripMenuItemTx;
        private System.Windows.Forms.ToolStripMenuItem encodeAsciiToolStripMenuItemTx;
        private System.Windows.Forms.ToolStripMenuItem encodeAutoToolStripMenuItemRx;
        private System.Windows.Forms.ToolStripMenuItem encodeHexToolStripMenuItemRx;
        private System.Windows.Forms.ToolStripMenuItem encodeAsciiToolStripMenuItemRx;
        private System.Windows.Forms.ToolStripMenuItem alwaysOnTopToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem sendOnKeyPressToolStripMenuItemTx;
        private System.Windows.Forms.ToolStripMenuItem appendrToolStripMenuItemTx;
        private System.Windows.Forms.ToolStripMenuItem appendnToolStripMenuItemTx;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem appendrToolStripMenuItemRx;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem menuExit;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuGetTcpEndpoints;
        private System.Windows.Forms.ToolStripMenuItem menuGetTcpListeners;
        private System.Windows.Forms.ToolStripMenuItem menuListeningProcess;
        private System.Windows.Forms.ToolStripMenuItem menuHttpAnalyzer;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuHttpGetReq;
        private System.Windows.Forms.ToolStripMenuItem menuHttpGetResp;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemNetScanner;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemPortScanner;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripMenuItem menuUpdate;
        private System.Windows.Forms.ToolStripMenuItem menuOptions;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuAbout;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tbListenerStatus;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.GroupBox gbServer;
        private System.Windows.Forms.Button btnStartListen;
        private System.Windows.Forms.ComboBox comboBoxServerPort;
        private System.Windows.Forms.ComboBox comboBoxInterface;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripStatusLabel tbLcStatus;
        private System.Windows.Forms.ComboBox cbListenerClients;
        private System.Windows.Forms.ComboBox cboxSrvProto;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnStopListen;
        private System.Windows.Forms.ComboBox cbListeners;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnLcDisconnect;
        private System.Windows.Forms.Button btnLcAccept;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton rbtnSocketClient;
        private System.Windows.Forms.RadioButton rbtnListenerClient;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.GroupBox gbClient;
        private System.Windows.Forms.ComboBox cbSocketClients;
        private System.Windows.Forms.Button btnScDisconnect;
        private System.Windows.Forms.ComboBox cboxClientProto;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnScConnect;
        private System.Windows.Forms.ComboBox comboBoxClientPort;
        private System.Windows.Forms.ComboBox comboBoxClientHost;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton newToolStripButton;
        private System.Windows.Forms.ToolStripButton openToolStripButton;
        private System.Windows.Forms.ToolStripButton saveToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton aboutToolStripButton;
        private System.Windows.Forms.ToolStripButton toolStripButtonResolve;
        private System.Windows.Forms.ToolStripButton toolStripButtonClear;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton toolStripButtonReverseDns;
        private System.Windows.Forms.RichTextBox richTextBoxTxData;
        private System.Windows.Forms.ToolStripButton toolStripButtonPing;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBoxHostName;
        private yournamespace.RichTextBoxEx richTextBoxExEventLog;
        private System.Windows.Forms.ToolStripButton toolStripButtonCopyText;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.ToolStripButton toolStripButtonNtpRequest;
        private System.Windows.Forms.ToolStripStatusLabel tbScStatus;
        private System.Windows.Forms.ToolStripStatusLabel toolStripLabelPercent;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
    }
}

