using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleClientSocket
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Client");
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint iPEnd = new IPEndPoint(IPAddress.Parse("192.168.1.103"), 8888);
            socket.Connect(iPEnd);

            string message;
            do
            {
                Console.WriteLine("Write a message:");
                message = Console.ReadLine();
                try
                {
                    socket.Send(System.Text.Encoding.UTF8.GetBytes(message));

                    byte[] piggybackData = new byte[2];
                    socket.Receive(piggybackData);
                    Console.WriteLine("Piggyback data :" + System.Text.Encoding.UTF8.GetString(piggybackData));
                }
                catch (Exception e)
                {
                    Console.WriteLine("Connection aborted. " + e.ToString());
                }
            } while (message.Length > 0);



            Console.ReadKey();


        }
    }
}
