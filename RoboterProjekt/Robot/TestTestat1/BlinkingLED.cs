using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RobotCtrl;
using System.Threading;

namespace TestTestat1
{
    class BlinkingLED
    {
        #region members
        private bool ledState = false;
        private int blinkPeriod = 500;      //Blink Periode in ms
        #endregion

        #region blinkLED Task Method
        public void blinkLED()
        {
            for(;;)   //Endlosloop des Tasks
            {
                if (Form1.switch1enabled)
                {
                    Robot.RobotConsole[Leds.Led1].LedEnabled = ledState;
                    Robot.RobotConsole[Leds.Led2].LedEnabled = ledState;
                    Robot.RobotConsole[Leds.Led3].LedEnabled = ledState;
                    Robot.RobotConsole[Leds.Led4].LedEnabled = ledState;
                    ledState = !ledState;
                }
                Thread.Sleep(blinkPeriod);
            }
        }
        #endregion

        #region properties
        public Robot Robot { get; set; }
        #endregion

    }
}
