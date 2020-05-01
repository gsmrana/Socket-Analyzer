using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;


namespace Socket_Analyzer
{
    public partial class HttpForm : Form
    {
        #region Internal Methods

        HttpWebRequest request;

        private string ReadResponse(string url)
        {
            string reply = "";

            // check the url provided
            try
            {
                //request = WebRequest.CreateHttp(url);     //.net 4.5 only
                request = (HttpWebRequest)WebRequest.Create(url);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Invalid");
                return reply;
            }

            // set WebRequest parameter
            request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
            request.UserAgent = "Mozilla/5.0 (Windows NT 6.3; rv:24.0) Gecko/20100101 Firefox/24.0";
            //request.Headers.Add("Accept-Language", "en-gb,en;q=0.5");
            //request.Headers.Add("Accept-Encoding", "gzip,deflate");
            request.Method = comboBoxMethod.Text;

            // set extra parameter in case of post method
            if (request.Method == "POST")
            {
                string postData = comboBoxPostData.Text;
                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = postData.Length;

                using (StreamWriter dataStream = new StreamWriter(request.GetRequestStream()))
                    dataStream.Write(postData);
            }

            // read the respose and handle exception
            try
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream());
                reply = reader.ReadToEnd();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception");
            }

            return reply;
        }

        #endregion


        public HttpForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            comboBoxMethod.SelectedIndex = 0;
            comboBoxUrl.SelectedIndex = 1;
            comboBoxPostData.SelectedIndex = 1;
        }

        private void ButtonGo_Click(object sender, EventArgs e)
        {
            textBoxResponse.Clear();
            textBoxResponse.Text = ReadResponse(comboBoxUrl.Text);
            if (browserViewToolStripMenuItem.Checked)
                wb1.DocumentText = textBoxResponse.Text;
        }

        private void ButtonView_Click(object sender, EventArgs e)
        {
            wb1.DocumentText = textBoxResponse.Text;
        }

        private void AlwaysOnTopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.TopMost = alwaysOnTopToolStripMenuItem.Checked;
        }


    }
}
