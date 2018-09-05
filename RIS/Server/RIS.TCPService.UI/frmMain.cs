using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.Threading;

namespace RIS.TCPService.UI
{
    public partial class frmMain : Form
    {
        int port = 8010;
        HttpServer httpServer;
        public frmMain()
        {
            InitializeComponent();
        }
        
        private void btnStart_Click(object sender, EventArgs e)
        {
            port = int.Parse(ConfigurationManager.AppSettings["Port"]);
            httpServer = new HttpServer(port);
            httpServer.frm = this;
            Thread thread = new Thread(new ThreadStart(httpServer.listen));
            thread.Start();
            httpServer.Display("Start listen to " + port.ToString(), "", "", "");
        }

        public void AddList(DisplayText text)
        {
            if (this.InvokeRequired)
            {
                AddListDelegate add = new AddListDelegate(AddList);
                this.BeginInvoke(add, new object[] { text });
            }
            else
            {
                ListViewItem lvi = new ListViewItem(text.Action);
                lvi.SubItems.Add(text.ActionTime.ToString());
                lvi.SubItems.Add(text.From);
                lvi.SubItems.Add(text.Flag);
                lvi.SubItems.Add(text.Length);
                lvResult.Items.Add(lvi);
            }
        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (httpServer != null)
            {
                httpServer.is_active = false;
                httpServer.StopListen();
            }
        }
    }

    delegate void AddListDelegate(DisplayText text);

    public class DisplayText
    {
        public string Action, From;
        public DateTime ActionTime;
        public string Flag, Length;
    }
}