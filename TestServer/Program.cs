using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SuperSocket;
using SuperSocket.ProtoBase;
using TestServer;

static class Program
{
    static void Main()
    {
        var config = new ServerOptions();
        config.Listeners = new List<ListenOptions>();
        using (StreamReader file = File.OpenText("config.json"))
        {
            using (JsonTextReader reader = new JsonTextReader(file))
            {
                var json = (JObject)JToken.ReadFrom(reader);
                var option = json["serverOptions"];
                if (option == null) return;

                config.Name = option["name"]?.ToString();
                var listerList = option["listeners"];
                if(listerList == null) return;

                foreach (var listen in listerList)
                {
                    if(listen == null) continue;

                    var listener = new ListenOptions();
                    listener.Ip = listen["ip"]?.ToString();
                    var port = listen["port"];
                    if (port == null) return;

                    listener.Port = (int)port;
                    config.AddListener(listener);
                }

                if (config.Listeners.Count == 0)
                    return;
            }
        }

        LogicThread[] logic = new LogicThread[4];
        for (int i = 0; i < 4; i++)
        {
            logic[i] = new LogicThread();
            logic[i].Start();
        }

        var server = SuperSocketHostBuilder.Create<StringPackageInfo, CommandLinePipelineFilter>()
            .UsePackageHandler(async (s, p) =>
            {
                await Task.Delay(0);
            })
            .ConfigureSuperSocket(options =>
            {
                options.Name = config.Name;
                options.MaxPackageLength = config.MaxPackageLength;
                options.ReceiveBufferSize = config.ReceiveBufferSize;
                options.ReceiveTimeout = config.ReceiveTimeout;
                options.SendBufferSize = config.SendBufferSize;
                options.SendTimeout = config.SendTimeout;

                options.Listeners = new List<ListenOptions>();
                foreach(var listen in config.Listeners)
                {
                    options.AddListener(new ListenOptions
                    {
                        Ip = listen.Ip,
                        Port = listen.Port,
                        BackLog = listen.BackLog,
                        NoDelay = listen.NoDelay,
                        Security = listen.Security,
                        CertificateOptions = listen.CertificateOptions,
                    });
                };
            }).Build();

        server.StartAsync();

        while(true) { }
    }
};