using System;
using System.Net.Sockets;
using System.IO;
using System.Text;

namespace SimpleHttpServer {

    class HttpHandler {

        private TcpClient client;

        public HttpHandler(TcpClient client) {
            this.client = client;
        }

        public void Do() {
            String filename = @"Temp\RobotHttpServer\daten.txt";
            StreamReader sr = new StreamReader(client.GetStream());
            StreamWriter sw = new StreamWriter(client.GetStream());
            Console.WriteLine("Verbindung zu " + client.Client.RemoteEndPoint);

            String request = sr.ReadLine();
            Console.WriteLine("Anfrage " + request);
            // Datei lesen
            FileStream fs = new FileStream(filename,FileMode.Open,FileAccess.Read);
            StreamReader streamReader = new StreamReader(fs);
            String data = streamReader.ReadToEnd();
            // Datei im HTTP-Format senden
            try
            {
                sw.WriteLine("HTTP/1.1 200 OK");
                sw.WriteLine("Content-type: text/plain");
                sw.WriteLine("Content-length: " + data.Length);
                sw.WriteLine("");   //wichtig 
                sw.WriteLine(data);
                sw.Flush();     //sehr wichtig!!
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                client.Close();
            }

        }
    }
}
