using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace SimpleHttpServer {

    class SimpleHttpServer {

        private static int httpPort = 8080;     //Auswahl des TCP Ports des HTTP Servers für die Anfrage 
                                                //vom Client --> 8080 soll gewählt werden
        public static void Main() {
            //IPAddress ipAddress = Dns.GetHostEntry("localhost").AddressList[0];
            Console.WriteLine("Welcome to C# on Windows Embedded Systems");
            // Listener erzeugen
            TcpListener listen = new TcpListener(IPAddress.Any, httpPort);
            //TcpListener listen = new TcpListener(ipAddress, httpPort);
            listen.Start();
            while (true)
            {
                //Console.WriteLine("Warte auf Verbindung auf Port " + listen.LocalEndpoint + "...");
                TcpClient client = listen.AcceptTcpClient();
                //Console.WriteLine("Http Handler für " + client.Client.RemoteEndPoint + " erzeugen und starten");
                // Http Handler erzeugen
                HttpHandler handler = new HttpHandler(client);
                new Thread(handler.Do).Start();
            }
        }
    }
}
