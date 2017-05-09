using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RobotCtrl;
using System.Threading;


namespace Uebung7_SocketImplementation
{
    public partial class Form1 : Form
    {
        #region members
        private Robot robot;
        private SimpleDayTimeServer simpleDayTimeServer;
        #endregion

        public Form1()
        {
            InitializeComponent();

            //neuer Roboter erstellen für zugriff auf LEDs
            robot = new Robot();

            //LEDs initial ausschalten
            robot.RobotConsole[Leds.Led1].LedEnabled = false;
            robot.RobotConsole[Leds.Led2].LedEnabled = false;
            robot.RobotConsole[Leds.Led3].LedEnabled = false;
            robot.RobotConsole[Leds.Led4].LedEnabled = false;

            //ein Objekt und danach Thread erzeugen und starten für die verschiedenen Aufgaben
            simpleDayTimeServer = new SimpleDayTimeServer();
            simpleDayTimeServer.Robot = robot;      //Robot Objekt über Property zuweisen, damit Zugriff auf LEDs 
                                                    //möglich wird

            //Erzeugen
            Thread serverTask = new Thread(new ThreadStart(simpleDayTimeServer.dayTime));

            //Thread background setzen, damit beim Schliessen des GUI's die Tasks beendet werden
            serverTask.IsBackground = true;

            //Starten
            serverTask.Start();
        }
    }
}
