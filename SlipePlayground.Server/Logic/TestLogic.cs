using Microsoft.Extensions.Logging;
using SlipeServer.Packets.Lua.Camera;
using SlipeServer.Server;
using SlipeServer.Server.Elements;
using SlipeServer.Server.Resources;
using SlipeServer.Server.Services;
using System.Numerics;

namespace SlipePlayground.Server.Logic
{
    public class TestLogic
    {
        private readonly DebugLog debugLog;

        public TestLogic(
            MtaServer server,
            ResourceService resourceService,
            ILogger logger,
            DebugLog debugLog,
            LuaEventService eventService)
        {
            this.debugLog = debugLog;

            logger.LogInformation("Test Logic started");
            resourceService.StartResource("SlipePlayground.Client");

            server.PlayerJoined += HandlePlayerJoin;

            eventService.AddEventHandler("TestRpc", (x) =>
            {
                Console.WriteLine("POO");
            });
        }

        private void HandlePlayerJoin(Player player)
        {
            player.Spawn(new Vector3(0, 0, 3), 90, 7, 0, 0);
            player.Camera.Fade(CameraFade.In);
            player.Camera.Target = player;

            this.debugLog.SetVisibleTo(player, true);
        }
    }
}