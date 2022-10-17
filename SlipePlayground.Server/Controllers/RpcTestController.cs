using Microsoft.Extensions.Logging;
using SlipeLua.Shared.Rpc;
using SlipeServer.LuaControllers;
using SlipeServer.LuaControllers.Attributes;
using SlipeServer.Server.Services;

namespace SlipePlayground.Server.Controllers
{
    [LuaController("")]
    public class RpcTestController : BaseLuaController
    {
        private readonly ILogger logger;
        private readonly LuaEventService eventService;

        public RpcTestController(ILogger logger, LuaEventService eventService)
        {
            this.logger = logger;
            this.eventService = eventService;
        }

        public void TestRpc(SingleCastRpc<string> rpc)
        {
            //this.logger.LogInformation("{value}", rpc.Value);
        }

        [LuaEvent("slipe-client-ready-rpc")]
        public void HandleReady()
        {
            this.logger.LogInformation("Player {name} is ready", this.Context.Player.Name);
            this.eventService.TriggerEventFor(this.Context.Player, "ServerTestRpc", this.Context.Player, new SingleCastRpc<string>("Message from server"));
        }
    }
}
