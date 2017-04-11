using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RobotCtrl;
using System.Threading;
using System.Diagnostics;


namespace TestTestat1
{
    class DriveParcour
    {
        #region members
        private const float parcourLength = 1.5f;      //Länge des Parcours[m] --> müsste 3m sein
        private const float parcourWidth = 1.5f;       //Breite des Parcours[m] --> müsste 2.5m sein
        private const float speedParcour = 0.5f;           //Geschwindigkeit [m/s]
        private const float accelerationParcour = 0.2f;    //Beschleunigung [m/(s^2)]
        private const float parcourAngle = 90;             //Drehwinkel [°]

        private const float resolution = 0.05f;         //Auflösung Messungen in m
        private const int resolutionMS = 100;         //Messperiode in ms

        private const float maxMeasureDistance = 1.2f;   //gibt die maximale Messdistanz in [m] an

        private float lenghtObject;     //berechnete Länge des Objekts
        private float widthObject;     //berechnete Breite des Objekts

        private const float roboterWidth = 0.22f; //Roboterbreite in m 

        private float measures1part;    //Messungen erster Streckenteil
        private int i1part;     //Laufvariable zum Mittelwert berechnen
        private float measures2part;    //Messungen zweiter Streckenteil
        private int i2part;     //Laufvariable zum Mittelwert berechnen
        private float measures3part;    //Messungen dritter Streckenteil
        private int i3part;     //Laufvariable zum Mittelwert berechnen
        private float measures4part;    //Messungen vierter Streckenteil
        private int i4part;     //Laufvariable zum Mittelwert berechnen

        public event EventHandler<ObjectParametersEventArgs> ObjectParametersChanged;
        #endregion

        #region drive Task Method
        public void drive()
        {
            for (;;)    //Endlosloop des Tasks
            {
                if (Form1.switch1enabled)   //Wurde Startschalter gedrückt?
                {
                    //1. Abschnitt fahren
                    Robot.Drive.RunLine(parcourLength, speedParcour, accelerationParcour);  
                    while (!Robot.Drive.Done)   //Solange RunMethode nicht abgeschlossen ist in while warten       
                    {
                        if (Robot.Radar.Distance < maxMeasureDistance)
                        {
                            measures1part  = measures1part + Robot.Radar.Distance;
                            Debug.WriteLine("Strecke 1 Radar Wert: " + Robot.Radar.Distance);
                            i1part++;
                        }
                        //Thread.Sleep((int)(1000*(resolution / speedParcour)));
                        Thread.Sleep(resolutionMS);
                    }

                    //1. Drehung
                    Robot.Drive.RunTurn(parcourAngle, speedParcour, accelerationParcour);  
                    while (!Robot.Drive.Done);   //Solange RunMethode nicht abgeschlossen ist in while warten       

                    //2. Abschnitt fahren
                    Robot.Drive.RunLine(parcourWidth, speedParcour, accelerationParcour);  
                    while (!Robot.Drive.Done)   //Solange RunMethode nicht abgeschlossen ist in while warten       
                    {
                        if (Robot.Radar.Distance < maxMeasureDistance)
                        {
                            measures2part = measures2part + Robot.Radar.Distance;
                            Debug.WriteLine("Strecke 2 Radar Wert: " + Robot.Radar.Distance);
                            i2part++;
                        }
                        //Thread.Sleep((int)(1000*(resolution / speedParcour)));
                        Thread.Sleep(resolutionMS);
                    }

                    //2. Drehung
                    Robot.Drive.RunTurn(parcourAngle, speedParcour, accelerationParcour);
                    while (!Robot.Drive.Done) ;   //Solange RunMethode nicht abgeschlossen ist in while warten  

                    //3. Abschnitt fahren
                    Robot.Drive.RunLine(parcourLength, speedParcour, accelerationParcour);
                    while (!Robot.Drive.Done)   //Solange RunMethode nicht abgeschlossen ist in while warten       
                    {
                        if (Robot.Radar.Distance < maxMeasureDistance)
                        {
                            measures3part = measures3part + Robot.Radar.Distance;
                            Debug.WriteLine("Strecke 3 Radar Wert: " + Robot.Radar.Distance);
                            i3part++;
                        }
                        //Thread.Sleep((int)(1000*(resolution / speedParcour)));
                        Thread.Sleep(resolutionMS);
                    }

                    //3. Drehung
                    Robot.Drive.RunTurn(parcourAngle, speedParcour, accelerationParcour);
                    while (!Robot.Drive.Done) ;   //Solange RunMethode nicht abgeschlossen ist in while warten       

                    //4. Abschnitt fahren
                    Robot.Drive.RunLine(parcourWidth, speedParcour, accelerationParcour);
                    while (!Robot.Drive.Done)   //Solange RunMethode nicht abgeschlossen ist in while warten       
                    {
                        if (Robot.Radar.Distance < maxMeasureDistance)
                        {
                            measures4part = measures4part + Robot.Radar.Distance;
                            Debug.WriteLine("Strecke 4 Radar Wert: " + Robot.Radar.Distance);
                            i4part++;
                        }
                        //Thread.Sleep((int)(1000*(resolution / speedParcour)));
                        Thread.Sleep(resolutionMS);
                    }

                    //4. Drehung
                    Robot.Drive.RunTurn(parcourAngle, speedParcour, accelerationParcour);
                    while (!Robot.Drive.Done) ;   //Solange RunMethode nicht abgeschlossen ist in while warten  

                    //Berechnungen Länge und Breite Objekt
                    widthObject = parcourWidth - (measures1part / i1part) - (measures3part / i3part) - roboterWidth;
                    lenghtObject = parcourLength - (measures2part / i2part) - (measures4part / i4part) - roboterWidth;

                    Debug.WriteLine("Breite Objekt: " + widthObject);
                    Debug.WriteLine("Länge Objekt: " + lenghtObject);
                    
                    //berechnete Werte auf GUI schreiben --> 
                    //dazu ein Event feuern, der vom GUI (Form1) abonniert ist und dort auch gehandelt wird
                    OnObjectParametersChanged(new ObjectParametersEventArgs(lenghtObject, widthObject));

                    //neuer Durchgang zulassen indem switch enabled zurückgesetzt wird
                    Form1.switch1enabled = false;

                    //LEDs löschen falls noch leuchten
                    Robot.RobotConsole[Leds.Led1].LedEnabled = false;
                    Robot.RobotConsole[Leds.Led2].LedEnabled = false;
                    Robot.RobotConsole[Leds.Led3].LedEnabled = false;
                    Robot.RobotConsole[Leds.Led4].LedEnabled = false;
                }
            }
        }
        #endregion

        #region methods
        /// <summary>
        /// Erzeugt das GUIChanged Event.
        /// </summary>
        /// <param name="e"></param>
        protected void OnObjectParametersChanged(ObjectParametersEventArgs e)
        {
            if (ObjectParametersChanged != null)
            {
                ObjectParametersChanged(this, e);
            }
        }
        #endregion

        #region properties
        public Robot Robot { get; set; }
        #endregion
    }
}
