using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RobotCtrl;
using System.Threading;

namespace TestTestat1
{
    class DriveParcour
    {
        #region members
        private const float parcourLength = 3;      //Länge des Parcours[m]
        private const float parcourWidth = 2.5f;       //Breite des Parcours[m]
        private const float speedParcour = 0.5f;           //Geschwindigkeit [m/s]
        private const float accelerationParcour = 0.2f;    //Beschleunigung [m/(s^2)]
        private const float parcourAngle = 90;             //Drehwinkel [°]
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
                        /* ToDo Messungen durchführen */
                    }

                    //1. Drehung
                    Robot.Drive.RunTurn(parcourAngle, speedParcour, accelerationParcour);  
                    while (!Robot.Drive.Done);   //Solange RunMethode nicht abgeschlossen ist in while warten       

                    //2. Abschnitt fahren
                    Robot.Drive.RunLine(parcourWidth, speedParcour, accelerationParcour);  
                    while (!Robot.Drive.Done)   //Solange RunMethode nicht abgeschlossen ist in while warten       
                    {
                        /* ToDo Messungen durchführen */
                    }

                    //2. Drehung
                    Robot.Drive.RunTurn(parcourAngle, speedParcour, accelerationParcour);
                    while (!Robot.Drive.Done) ;   //Solange RunMethode nicht abgeschlossen ist in while warten  

                    //3. Abschnitt fahren
                    Robot.Drive.RunLine(parcourLength, speedParcour, accelerationParcour);
                    while (!Robot.Drive.Done)   //Solange RunMethode nicht abgeschlossen ist in while warten       
                    {
                        /* ToDo Messungen durchführen */
                    }

                    //3. Drehung
                    Robot.Drive.RunTurn(parcourAngle, speedParcour, accelerationParcour);
                    while (!Robot.Drive.Done) ;   //Solange RunMethode nicht abgeschlossen ist in while warten       

                    //4. Abschnitt fahren
                    Robot.Drive.RunLine(parcourWidth, speedParcour, accelerationParcour);
                    while (!Robot.Drive.Done)   //Solange RunMethode nicht abgeschlossen ist in while warten       
                    {
                        /* ToDo Messungen durchführen */
                    }

                    //4. Drehung
                    Robot.Drive.RunTurn(parcourAngle, speedParcour, accelerationParcour);
                    while (!Robot.Drive.Done) ;   //Solange RunMethode nicht abgeschlossen ist in while warten  

                    //neuer Durchgang zulassen indem switch enabled zurückgesetzt wird
                    Form1.switch1enabled = false;
                }
            }
        }
        #endregion

        #region properties
        public Robot Robot { get; set; }
        #endregion
    }
}
