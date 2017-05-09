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
    class SimpleDayTimeHandler
    {
        #region dayTimeHandler Task Method
        public void dayTimeHandler()
        {
            for (;;)   //Endlosloop des Tasks
            {
                Console.WriteLine("Verbindung zu " +
                    Client.Client.RemoteEndPoint);
                TextWriter tw = new StreamWriter(Client.GetStream());  //Network Stream mit Client wird verbunden
                tw.Write(DateTime.Now.ToString());
                tw.Flush();     //ganz wichtig, damit Daten tatsächlich den Datenenpunkt des Servers verlassen
                //einmal durch die LEDs
                Robot.RobotConsole[Leds.Led1].LedEnabled = true;
                Thread.Sleep(500);
                Robot.RobotConsole[Leds.Led2].LedEnabled = true;
                Thread.Sleep(500);
                Robot.RobotConsole[Leds.Led3].LedEnabled = true;
                Thread.Sleep(500);
                Robot.RobotConsole[Leds.Led4].LedEnabled = true;
                Thread.Sleep(500);
                Robot.RobotConsole[Leds.Led1].LedEnabled = false;
                Robot.RobotConsole[Leds.Led2].LedEnabled = false;
                Robot.RobotConsole[Leds.Led3].LedEnabled = false;
                Robot.RobotConsole[Leds.Led4].LedEnabled = false;
                Client.Close();
                Thread.CurrentThread.Abort();   //Thread abbrechen
            }
        }
        #endregion

        #region properties
        public TcpClient Client { get; set; }

        public Robot Robot { get; set; }
        #endregion
    }
}
