using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Diagnostics;

namespace Uebung9_Testat2
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [MTAThread]
        static void Main()
        {
            //Prozesse Fahrbefehl Server (Drive Server) und Http Server erzeugen und starten
            Process robotHttpServer = new Process();
            Process robotDriveServer = new Process();
            robotHttpServer.StartInfo.FileName = @"Temp\RobotHttpServer\RobotHttpServer.exe";    //muss noch abgeklärt werden ob dieser Pfad und Name richtig ist
            robotHttpServer.Start();
            robotDriveServer.StartInfo.FileName = @"Temp\Uebung9_DriveServer\Uebung9_DriveServer.exe";
            robotDriveServer.Start();
        }
    }
}