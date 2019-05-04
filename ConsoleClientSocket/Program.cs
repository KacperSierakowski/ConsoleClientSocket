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


            //Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            //IPEndPoint iPEnd = new IPEndPoint(IPAddress.Parse("192.168.1.103"), 8888);
            //socket.Connect(iPEnd);
            //string message;
            //do
            //{
            //    Console.WriteLine("Write a message:");
            //    message = Console.ReadLine();
            //    try
            //    {
            //        socket.Send(System.Text.Encoding.UTF8.GetBytes(message));

            //        byte[] piggybackData = new byte[2];
            //        socket.Receive(piggybackData);
            //        Console.WriteLine("Piggyback data :" + System.Text.Encoding.UTF8.GetString(piggybackData));
            //    }
            //    catch (Exception e)
            //    {
            //        Console.WriteLine("Connection aborted. " + e.ToString());
            //    }
            //} while (message.Length > 0);



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
