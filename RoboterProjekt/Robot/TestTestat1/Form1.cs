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
        #region members
        public static bool switch1enabled;
        private Robot robot;
        private BlinkingLED blinkingLED;
        private DriveParcour driveParcour;
        #endregion

        #region constructors
        public Form1()
        {
            InitializeComponent();

            //neuen Roboter erstellen
            robot = new Robot();

            //Motoren einschalten des Roboters
            robot.Drive.Power = true;

            //zwei Objekte und danach Threads erzeugen und starten für die verschiedenen Aufgaben
            blinkingLED = new BlinkingLED();
            blinkingLED.Robot = robot;      //Robot Objekt über Property zuweisen, damit Zugriff auf LEDs 
                                            //möglich wird
            driveParcour = new DriveParcour();
            driveParcour.Robot = robot;     //Robot Objekt über Property zuweisen, damit Zugriff auf drive 
                                            //Methoden zugänglich sind

            //Erzeugen
            Thread blinkingTask = new Thread(new ThreadStart(blinkingLED.blinkLED));
            Thread driveTask = new Thread(new ThreadStart(driveParcour.drive));

            //Threads background setzen, damit beim Schliessen des GUI's die Tasks beendet werden
            blinkingTask.IsBackground = true;
            driveTask.IsBackground = true;

            //Starten
            blinkingTask.Start();
            driveTask.Start();

            //Event von driveTask abonnieren, dass das GUI aktualisiert werden soll
            driveParcour.ObjectParametersChanged += DriveParcour_ObjectParametersChanged;
            //Event von Schalter 1 abbonieren
            robot.RobotConsole[Switches.Switch1].SwitchStateChanged += Switch1_SwitchStateChanged;

        }
        #endregion

        //#region properties
        //public float ObjectLength
        //{
        //    get;
        //    set
        //    {
        //        textBoxLänge.Text = value.ToString;
        //    }
        //}
        //#endregion

        #region event handler
        //Eventhandler für eine Änderung der Werte des GUIs (Form1)
        private void DriveParcour_ObjectParametersChanged(object sender, ObjectParametersEventArgs e)
        {
            //Invoke Required ist nötig, da nur der Thread der hier die Form erzeugt hat, etwas am 
            //GUI ändern darf. Wenn dieser Thread aktiv ist, ist InvokeRequired = false und das GUI wird aktualisiert
            //Ansonsten wenn ein anderer Thread zugreifen will, ist das InvokeRequired = true und die 
            //ObjectParametersChanged Methode muss nochmals aufgerufen werden vom richtigen Thread. Das geschieht im 
            //Code unten nach der If-Anweisung Invoke(new.....)
            if (InvokeRequired)
            {
                Invoke(new EventHandler<ObjectParametersEventArgs>(DriveParcour_ObjectParametersChanged), sender, e);
            }
            else
            {
                //Länge und Breite auf GUI anzeigen inklusive Stringkonkatenation
                textBoxLänge.Text = (e.LengthObject).ToString("F3") + " m";     //"F3" muss zwingend im ToString stehen 
                                                                                //--> gibt Zahl mit drei Nachkommastellen an
                textBoxBreite.Text = (e.WidthObject).ToString("F3") + " m";
            }
        }

        //Wenn Schalter 1 betätigt wurde, soll der Vorgang gestartet werden
        private void Switch1_SwitchStateChanged(object sender, SwitchEventArgs e)
        {

            //Wenn bool Variable noch nicht gesetzt und Schalter betätigt wurde --> Variable setzen
            //und Vorgänge starten
            if (e.SwitchEnabled && !switch1enabled)
            {
                switch1enabled = true;
            }
            
        }
        #endregion
    }
}
