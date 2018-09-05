using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RIS.Common;

namespace hardcode
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.txthardcode.Text = ComputerUtility.GetDeviceID();
        }
    }
}
