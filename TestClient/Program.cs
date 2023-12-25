using System;
using System.Net;
using System.Net.Sockets;

static class Program
{
    static void Main()
    {
        var client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        client.Connect(new IPEndPoint(IPAddress.Loopback, 20000));
    }
};