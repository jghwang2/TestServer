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
                config.Name = option["name"].ToString();

                foreach (var listen in option["listeners"])
                {
                    var listener = new ListenOptions();
                    listener.Ip = listen["ip"].ToString();
                    listener.Port = (int)listen["port"];
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
                options.Listeners = new List<ListenOptions>();

                foreach(var listen in config.Listeners)
                {
                    options.AddListener(new ListenOptions
                    {
                        Ip = listen.Ip,
                        Port = listen.Port
                    });
                };
            }).Build();

        server.StartAsync();

        while(true) { }
    }
};