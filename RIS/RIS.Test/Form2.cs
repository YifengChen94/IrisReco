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
    public partial class Form2 : Form
    {
        public Form2()
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
            HttpWebResponse response = HttpUtility.CreateGetHttpResponse(loginUrl, 120 * 1000, "", null);

            using (Stream stream = response.GetResponseStream())
            {
                StreamReader sr = new StreamReader(stream, Encoding.UTF8);
                string content = sr.ReadToEnd();
                sr.Close();
                this.textBox2.Text = content;
               
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string loginUrl = this.textBox1.Text;
            if (string.IsNullOrEmpty(loginUrl))
            {
                MessageBox.Show("请填写URL");
                return;
            }
            string sendcontent = this.textBox3.Text;
            HttpWebResponse response = HttpUtility.CreatePostHttpResponse(loginUrl,sendcontent, 120 * 1000, "",Encoding.UTF8, null);

            using (Stream stream = response.GetResponseStream())
            {
                StreamReader sr = new StreamReader(stream, Encoding.UTF8);
                string content = sr.ReadToEnd();
                sr.Close();
                this.textBox2.Text = content;

            }
        }
    }
}
