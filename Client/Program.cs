using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            int port = 8002;
            string ipAdrr = "127.0.0.1";
            Socket ClientSocket = new Socket(AddressFamily
                .InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint endp = new IPEndPoint(IPAddress.Parse(ipAdrr), port);
            ClientSocket.Connect(endp);
            Console.WriteLine("Client is Connected");
            while (true)
            {
                string messageFromClient = null;
                Console.WriteLine("Enter the mesage here");
                messageFromClient = Console.ReadLine();
                ClientSocket.Send(System.Text.Encoding.ASCII.GetBytes(messageFromClient), 0, messageFromClient.Length, SocketFlags.None);
                byte[] msgFromServer = new byte[1024];
                int size = ClientSocket.Receive(msgFromServer);
                Console.WriteLine("Server Says:" + System.Text.Encoding.ASCII.GetString(msgFromServer, 0, size));
            }
        }
    }
}