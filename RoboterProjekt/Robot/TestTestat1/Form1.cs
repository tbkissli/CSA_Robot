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

namespace TestTestat1
{
    public partial class Form1 : Form
    { 
        public static bool switch1enabled;

        public Form1()
        {
            InitializeComponent();

            //neuen Roboter erstellen
            Robot robot = new Robot();

            //zwei Objekte und danach Threads erzeugen und starten für die verschiedenen Aufgaben
            BlinkingLED blinkingLED = new BlinkingLED();
            blinkingLED.Robot = robot;      //Robot Objekt über Property zuweisen, damit Zugriff auf LEDs möglich wird
            DriveParcour driveParcour = new DriveParcour();

            //Erzeugen
            Thread blinkingTask = new Thread(new ThreadStart(blinkingLED.blinkLED));
            Thread driveTask = new Thread(new ThreadStart(driveParcour.drive));

            //Threads background setzen, damit beim Schliessen des GUI's die Tasks beendet werden
            blinkingTask.IsBackground = true;
            driveTask.IsBackground = true;

            //Starten
            blinkingTask.Start();
            driveTask.Start();

            //Event von Schalter 1 abbonieren
            robot.RobotConsole[Switches.Switch1].SwitchStateChanged += Switch1_SwitchStateChanged;

        }

        public bool Switch1 { get; set; }

        //Wenn Schalter 1 betätigt wurde, soll der Vorgang gestartet werden
        private static void Switch1_SwitchStateChanged(object sender, SwitchEventArgs e)
        {
            switch1enabled = true;
        }

    }
}
