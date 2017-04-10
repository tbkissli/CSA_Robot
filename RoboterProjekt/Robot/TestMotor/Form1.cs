using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TestMotor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            driveCtrlView1.DriveCtrl = new RobotCtrl.DriveCtrl(RobotCtrl.Constants.IODriveCtrl);
            motorCtrlView1.MotorCtrl = new RobotCtrl.MotorCtrl(RobotCtrl.Constants.IOMotorCtrlRight);
            motorCtrlView2.MotorCtrl = new RobotCtrl.MotorCtrl(RobotCtrl.Constants.IOMotorCtrlLeft);
        }
    }
}
