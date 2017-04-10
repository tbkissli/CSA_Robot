using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
//eigene usings
using RobotCtrl;
using RobotView;

namespace RobotView
{
    public partial class ConsoleView : UserControl
    {
        #region members
        private RobotConsole robotConsole;
        #endregion

        #region constructor
        public ConsoleView()
        {
            InitializeComponent();
        }
        #endregion

        #region properties
        public RobotConsole RobotConsole
        {
            get { return robotConsole; }
            set
            {
                robotConsole = value;

                if (robotConsole != null)
                {
                    //jeder LedView über das Led Property die entsprechende Led zuweisen
                    ledView1.Led = robotConsole[Leds.Led1];
                    ledView2.Led = robotConsole[Leds.Led2];
                    ledView3.Led = robotConsole[Leds.Led3];
                    ledView4.Led = robotConsole[Leds.Led4];
                    //jeder SwitchView über das Switch Property den entsprechenden Schalter zuweisen
                    switchView1.Switch = robotConsole[Switches.Switch1];
                    switchView2.Switch = robotConsole[Switches.Switch2];
                    switchView3.Switch = robotConsole[Switches.Switch3];
                    switchView4.Switch = robotConsole[Switches.Switch4];
                }
            }
        }
        #endregion
    }
}