using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using RIS.Common;
using System.IO;

namespace RIS.Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string loginUrl = this.textBox1.Text;
            if (string.IsNullOrEmpty(loginUrl))
            {
                MessageBox.Show("请填写URL");
                return;
            }
            string sendcontent = this.textBox3.Text;
            string returnMessage = HttpUtility.CreatePostTCPResponse(loginUrl, sendcontent, null,  Encoding.UTF8);

            this.textBox2.Text = returnMessage;

        }

        private void TestTcp_Click(object sender, EventArgs e)
        {

        }

        private void TestHttp_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
        }
    }
}
