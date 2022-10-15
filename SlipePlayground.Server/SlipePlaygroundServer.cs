using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SlipeServer.Server;
using SlipeServer.Server.Loggers;
using SlipeServer.Server.Resources;
using SlipeServer.Server.Resources.Providers;
using SlipeServer.Server.ServerBuilders;

namespace SlipePlayground.Server
{
    public class SlipePlaygroundServer
    {
        private readonly MtaServer server;

        public SlipePlaygroundServer()
        {
            this.server = new MtaServer(x =>
            {
                x.AddDefaults(exceptBehaviours: ServerBuilderDefaultBehaviours.MasterServerAnnouncementBehaviour);
                x.AddLogic<TestLogic>();

                x.ConfigureServices(services =>
                {
                    services.AddSingleton<ResourceService>();
                    services.AddSingleton<ILogger, ConsoleLogger>();
                });
            });
        }

        public void Start() => this.server.Start();
    }
}