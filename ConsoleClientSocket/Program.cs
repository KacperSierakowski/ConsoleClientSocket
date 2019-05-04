using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleClientSocket
{
    class Program
    {
        public static string WhatIsIpAdress()
        {
            IPHostEntry iPHostEntry;
            string localIp = "?";
            iPHostEntry = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress iPAddress in iPHostEntry.AddressList)
            {
                if (iPAddress.AddressFamily.ToString() == "InterNetwork")
                {
                    localIp = iPAddress.ToString();
                }
            }
            return localIp;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Client");
            Console.WriteLine("Press any key");
            Console.ReadKey();
            string ip = WhatIsIpAdress();
            int port = 8888;
            IPEndPoint iPEnd = new IPEndPoint(IPAddress.Parse(ip), port);
            string filePath = "O:/Pas Oriona/Kariera/Nowy folder/a2253781357_5 — kopia.jpg";
            var client = new TcpClient();
            client.Connect(ip, port);
            Console.WriteLine("Connected to the server!");
            using (var networkStream = client.GetStream())
            using (var fileStream = File.OpenRead(filePath))
            {
                fileStream.CopyTo(networkStream);
            }
            client.Close();
            Console.ReadKey();
        }
    }
}
