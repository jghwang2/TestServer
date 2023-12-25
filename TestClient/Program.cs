using System;
using System.Net;
using System.Net.Sockets;

static class Program
{
    static void Main()
    {
        while (true)
        {
            var command = Console.ReadLine();

            switch(command)
            {
                case "connect":
                    {
                        var client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                        var ipAddr = IPAddress.Parse("172.30.1.46");
                        client.Connect(new IPEndPoint(ipAddr, 2020));

                        if (client.Connected)
                        {
                            Console.WriteLine("Connect Success!");
                        }
                        
                        client.Close();
                        if (false == client.Connected)
                        {
                            Console.WriteLine("Close Success!");
                        }
                    }
                    break;
            }
        }
    }
};