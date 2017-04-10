using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using RobotCtrl;

namespace RobotView
{
    public partial class RunLineView : UserControl
    {
        public RunLineView()
        {
            InitializeComponent();
        }

        public Drive Drive { get; set; }
        public float Speed { get; set; }
        public float Acceleration { get; set; }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            Drive.RunLine((float)(numericUpDown1.Value / 1000), Speed, Acceleration);
        }
    }
}