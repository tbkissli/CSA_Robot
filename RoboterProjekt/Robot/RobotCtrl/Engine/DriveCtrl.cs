//------------------------------------------------------------------------------
// C #   I N   A C T I O N   ( C S A )
//------------------------------------------------------------------------------
// Repository:
//    $Id: MotorCtrl.cs 973 2015-11-10 13:12:03Z zajost $
//------------------------------------------------------------------------------
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace RobotCtrl
{

    public class DriveCtrl : IDisposable
    {

        #region members
        private int ioAddress;
        #endregion


        #region constructor & destructor
        public DriveCtrl(int IOAddress)
        {
            this.ioAddress = IOAddress;
            Reset();
        }

        public void Dispose()
        {
            Reset();
        }
        #endregion


        #region properties
        /// <summary>
        /// Schaltet die Stromversorgung der beiden Motoren ein oder aus.
        /// </summary>
        public bool Power
        {
            set { DriveState = (value) ? DriveState | 0x03 : DriveState & ~0x03; }
        }


        /// <summary>
        /// Liefert den Status ob der rechte Motor ein-/ausgeschaltet ist bzw. schaltet den rechten Motor ein-/aus.
        /// Die Information dazu steht im Bit0 von DriveState.
        /// </summary>
        public bool PowerRight
        {
            get
            {
                if ((DriveState & 0x01) == 0x01)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            set
            {
                DriveState = (value) ? DriveState | 0x01 : DriveState & ~0x01;
                //if (value)
                //{
                //    DriveState = DriveState | 0x01;
                //}
                //else
                //{
                //    DriveState = DriveState & ~0x01;
                //}
            }
        }


        /// <summary>
        /// Liefert den Status ob der linke Motor ein-/ausgeschaltet ist bzw. schaltet den linken Motor ein-/aus.
        /// </summary>
        public bool PowerLeft
        {
            get
            {
                if ((DriveState & 0x02) == 0x02)
                {
                    return true;     
                }
                else
                {
                    return false;
                }
            }
            set
            {
                //DriveState = (value) ? DriveState | 0x02 : DriveState & ~0x02;
                if (value)
                {
                    DriveState = DriveState | 0x02;
                }
                else
                {
                    DriveState = DriveState & ~0x02;
                }
            }
        }


        /// <summary>
        /// Bietet Zugriff auf das Status-/Controlregister
        /// </summary>
        public int DriveState
        {
            get { return IOPort.Read(Constants.IODriveCtrl); } //Gibt den Status des Drive Ctrl Registers zurück
            set
            {
                IOPort.Write(Constants.IODriveCtrl, value); //Schreibt einen neuen Wert in das Drive Ctrl Register
                                                            //Schaltet damit Stromversorgung der Motoren ein oder aus
            } 
        }
        #endregion


        #region methods
        /// <summary>
        /// Setzt die beiden Motorencontroller (LM629) zurück, 
        /// indem kurz die Reset-Leitung aktiviert wird.
        /// </summary>
        public void Reset()
        {
            //Gemäss Pseudocode aus Uebung 5
            DriveState = 0x00;
            Thread.Sleep(5);    //5ms warten
            DriveState = 0x80;
            Thread.Sleep(5);    //5ms warten
            DriveState = 0x00;
            Thread.Sleep(5);    //5ms warten
        }
        #endregion

    }
}
