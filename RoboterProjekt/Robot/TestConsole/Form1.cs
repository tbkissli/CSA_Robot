using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//eigene usings
using RobotCtrl;
using RobotView;

namespace TestConsole
{
    public partial class Form1 : Form
    {
        #region members
        private RobotConsole rc;
        #endregion

        #region constructors
        public Form1()
        {
            InitializeComponent();

            rc = new RobotConsole();            //neue RobotConsole erstellen
            consoleView1.RobotConsole = rc;     //Robot Console der consoleView zuweisen über RobotConsole Property
            //Abonnieren der Switch Changed Events über die RobotConsole
            rc[Switches.Switch1].SwitchStateChanged += Switch1StateChanged;
            rc[Switches.Switch2].SwitchStateChanged += Switch2StateChanged;
            rc[Switches.Switch3].SwitchStateChanged += Switch3StateChanged;
            rc[Switches.Switch4].SwitchStateChanged += Switch4StateChanged;
        }
        #endregion

        #region methods
        private void Switch1StateChanged(object sender, SwitchEventArgs e)
        {
            rc[Leds.Led1].LedEnabled = e.SwitchEnabled;
        }

        private void Switch2StateChanged(object sender, SwitchEventArgs e)
        {
            rc[Leds.Led2].LedEnabled = e.SwitchEnabled;
        }

        private void Switch3StateChanged(object sender, SwitchEventArgs e)
        {
            rc[Leds.Led3].LedEnabled = e.SwitchEnabled;
        }

        private void Switch4StateChanged(object sender, SwitchEventArgs e)
        {
            rc[Leds.Led4].LedEnabled = e.SwitchEnabled;
        }
        #endregion
    }
}
