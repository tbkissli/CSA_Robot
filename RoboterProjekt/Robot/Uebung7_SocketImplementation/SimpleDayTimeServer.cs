using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RobotCtrl;
using System.Threading;

using System.Net.Sockets;
using System.IO;
using System.Net;

namespace Uebung7_SocketImplementation
{
    class SimpleDayTimeServer
    {

        #region dayTime Task Method
        public void dayTime()
        {
            TcpListener listen = new TcpListener(IPAddress.Any, 13);
            listen.Start();

            SimpleDayTimeHandler simpleDayTimeHandler = new SimpleDayTimeHandler();

            for (;;)   //Endlosloop des Tasks
            {
                Console.WriteLine("Warte auf Verbindung auf Port " +
                listen.LocalEndpoint + "...");
                TcpClient client = listen.AcceptTcpClient();

                //Client und Roboter an Handler übergeben
                simpleDayTimeHandler.Client = client;
                simpleDayTimeHandler.Robot = Robot;

                //Erzeugen
                Thread dayTimeHandlerTask = new Thread(new ThreadStart(simpleDayTimeHandler.dayTimeHandler));
                //Thread background setzen, damit beim Schliessen des GUI's die Tasks beendet werden
                dayTimeHandlerTask.IsBackground = true;
                //Starten
                dayTimeHandlerTask.Start();
            }
        }
        #endregion

        #region properties
        public Robot Robot { get; set; }
        #endregion
    }
}
