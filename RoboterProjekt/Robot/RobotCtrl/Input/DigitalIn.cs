﻿//------------------------------------------------------------------------------
// C #   I N   A C T I O N   ( C S A )
//------------------------------------------------------------------------------
// Repository:
//    $Id: DigitalIn.cs 1024 2016-10-11 12:06:49Z chj-hslu $
//------------------------------------------------------------------------------
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace RobotCtrl
{

    /// <summary>
    /// Mit Hilfe diese Klasse kann auf die 4 Eingänge (Schalter) des Roboters zugegeriffen werden.
    /// </summary>
    public class DigitalIn : IDisposable
    {
        #region members
        private Thread thread;
        private bool disposed;
        private bool run;
        public event EventHandler DigitalInChanged;
        #endregion


        #region constructor & destructor
        /// <summary>
        /// Initialisiert den DigitalIn.
        /// </summary>
        /// <param name="port">der IO-Port für den Zugriff auf die Eingänge</param>
        public DigitalIn(int port)
        {
            Port = port;
            disposed = false;

            this.thread = new Thread(Run);      //worker Thread für das Polling der Schalter
            this.thread.IsBackground = true;    //Wenn main Thread stirbt werden Threads, welche IsBackgroud=true 
                                                //haben auch beendet, daher immer machen
            this.thread.Start();
        }


        /// <summary>
        /// Stoppt den Polling-Thread
        /// </summary>
        public void Dispose()
        {
            if (!disposed)
            {
                run = false;
                thread.Join();
                disposed = true;
            }
        }
        #endregion


        #region properties
        /// <summary>
        /// Liefert bzw. setzt den IO-Port für den Zugriff auf die Eingänge des Roboters.
        /// </summary>
        public int Port { get; set; }


        /// <summary>
        /// Liest Daten vom IO-Port. Es können keine Daten geschrieben werden!
        /// </summary>
        public int Data
        {
            get { return IOPort.Read(Port); }   //Diese Funktion gibt die Daten des Ports zurück  
        }
        #endregion


        #region methods
        /// <summary>
        /// Erzeugt das DigitalInChanged Event.
        /// </summary>
        /// <param name="e"></param>
        protected void OnDigitalInChanged(EventArgs e)
        {
            if (DigitalInChanged != null)
            {
                DigitalInChanged(this, e);
            }
        }


        /// <summary>
        /// Bietet Zugriff auf die einzelnen Eingänge per Index
        /// </summary>
        /// <param name="bit">das gewünschte Bit [0..3]</param>
        /// <returns>den Zustand des entsprechenden Input-Bits.</returns>
        public virtual bool this[int bit]
        {
            get { return (Data & (1 << bit)) != 0; }  //Gibt den Zustand (true oder false) des Bits zurück
        }

        /// <summary>
        /// Thread um die Eingänge periodisch abzufragen. Der Roboter kann leider keine Interrupts
        /// generieren, falls ein Schalter betätigt wird. Somit muss gepollt werden.
        /// </summary>
        private void Run()
        {
            int oldData = -1;
            int newData;
            run = true;
            while (run)
            {
                newData = Data;     //Daten vom Port lesen über das Data Property
                if (oldData != newData)     //Abfrage ob sich am Port etwas geändert hat
                {
                    OnDigitalInChanged(EventArgs.Empty);  //Falls eine Änderung detektiert wurde 
                                                          //, das Event DigitalInChanged feuern.
                    oldData = newData;                    //aktueller Port abspeichern, damit 
                                                          //nacher wieder verglichen werden kann
                }

                Thread.Sleep(50);       //Pollingzeit --> alle 50ms wird der Port Digital ausgelesen --> 
                                        //Schalter werden damit abgefragt
            }
        }
        #endregion
    }
}