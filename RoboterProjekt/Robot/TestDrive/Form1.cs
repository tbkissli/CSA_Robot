using RobotCtrl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TestDrive
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            driveCtrlView1.DriveCtrl = new RobotCtrl.DriveCtrl(RobotCtrl.Constants.IODriveCtrl);

            Drive drive = new Drive();
            //Events abbonieren 
            commonRunParameters1.SpeedChanged += SpeedChanged;
            commonRunParameters1.AccelerationChanged += AccelerationChanged;

            runLineView1.Drive = drive;
            runTurnView1.Drive = drive;
            runArcView1.Drive = drive;

            AccelerationChanged(null, null);
            SpeedChanged(null, null);
            
        }

        private void AccelerationChanged(object sender, EventArgs e)
        {
            runLineView1.Acceleration = commonRunParameters1.Acceleration;
            runTurnView1.Acceleration = commonRunParameters1.Acceleration;
            runArcView1.Acceleration = commonRunParameters1.Acceleration;
        }

        private void SpeedChanged(object sender, EventArgs e)
        {
            runLineView1.Speed = commonRunParameters1.Speed;
            runTurnView1.Speed = commonRunParameters1.Speed;
            runArcView1.Speed = commonRunParameters1.Speed;
        }
    }
}
