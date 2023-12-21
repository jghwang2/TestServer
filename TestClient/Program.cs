using System;
using System.Net.Sockets;

static class Program
{
    static async void Main()
    {
        var client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        await client.ConnectAsync()
    }
};