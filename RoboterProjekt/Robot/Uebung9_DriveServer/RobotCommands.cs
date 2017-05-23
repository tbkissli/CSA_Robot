using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RobotCtrl;

namespace Uebung9_Testat2
{
    class RobotCommands
    {
        #region
        private const float acceleration = 0.3f;
        private const float speed = 0.5f;
        #endregion

        #region methods
        // Definierte Strecke geraudeaus fahren, valueL in Metern
        public void TrackLine(float valueL)
        {
            Robot.Drive.RunLine(valueL, speed, acceleration);
        }

        // Definierter Winkel an Ort links drehen, valueA in Grad
        // Vorzeichen beim Winkel (negativ)
        public void TrackTurnLeft(int valueA)
        {
            Robot.Drive.RunTurn(-valueA, speed, acceleration);
        }

        // Definierter Winkel an Ort rechts drehen, valueA in Grad
        // Vorzeichen beim Winkel (positiv)
        public void TrackTurnRight(int valueA)
        {
            Robot.Drive.RunTurn(valueA, speed, acceleration);
        }

        // Entlang eines Kreisbogen nach links fahren
        // valueA in Grad, valueL in Metern
        public void TrackArcLeft(int valueA, float valueL)
        {
            Robot.Drive.RunArcLeft(valueL, valueA, speed, acceleration);
        }

        // Entlang eines Kreisbogen nach rechts fahren
        // valueA in Grad, valueL in Metern
        public void TrackArcRight(int valueA, float valueL)
        {
            Robot.Drive.RunArcRight(valueL, valueA, speed, acceleration);
            while (!Robot.Drive.Done)   //Solange RunMethode nicht abgeschlossen ist in while warten       
            {
                if (Robot.Radar.Distance < maxMeasureDistance)
                {
                    measures3part = measures3part + Robot.Radar.Distance;
                    Debug.WriteLine("Strecke 3 Radar Wert: " + Robot.Radar.Distance);
                    i3part++;
                }
                Thread.Sleep(resolutionMS);
            }
        }
        #endregion

        #region drive Task methode
        public void drive()
        {
            // analog driveparcour
            // oben mit abfrage ob fertig gefahren und ständig messen damit objekte erkennt werden und gestoppt wird.
        }
        #endregion

        #region properties
        public Robot Robot { get; set; }
        
        public string[] CmdArray { get; set; }
        #endregion
    }
}
