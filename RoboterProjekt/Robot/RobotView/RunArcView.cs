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
    public partial class RunArcView : UserControl
    {
        public RunArcView()
        {
            InitializeComponent();
        }

        public Drive Drive { get; set; }
        public float Speed { get; set; }
        public float Acceleration { get; set; }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            if (radioButtonLeft.Checked)
            {
                Drive.RunArcLeft((float)numericUpDownRadius.Value / 1000, (float)numericUpDownAngle.Value,Speed,Acceleration);
            }
            else if (radioButtonRight.Checked)
            {
                Drive.RunArcRight((float)numericUpDownRadius.Value / 1000, (float)numericUpDownAngle.Value, Speed, Acceleration);
            }
        }
    }
}