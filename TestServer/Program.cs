using System;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SuperSocket;
using SuperSocket.ProtoBase;
using TestServer;

static class Program
{
    static void Main()
    {
        LogicThread[] logic = new LogicThread[4];
        var server = SuperSocketHostBuilder.Create<StringPackageInfo, CommandLinePipelineFilter>()
            .UsePackageHandler(async (s, p) =>
            {
                await Task.Run(() =>
                {
                    return;
                });
            })
            .ConfigureLogging((hostCtx, loggingBuilder) =>
            {
                loggingBuilder.AddConsole();
            })
            .BuildAsServer();

        server.StartAsync();

        for (int i = 0; i < 4; i++)
        {
            logic[i] = new LogicThread();
            logic[i].Start();
        }

        while(true) { }
    }
};