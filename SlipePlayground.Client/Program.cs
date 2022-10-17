using SlipeLua.Client.IO;
using SlipeLua.Client.Peds;
using SlipeLua.Client.Rpc;
using SlipeLua.Shared.Attributes;
using SlipeLua.Shared.Rpc;

namespace SlipePlayground.Client
{
    public class Program
    {

        [ClientEntryPoint]
        public static void Main(string[] args)
        {
            ChatBox.WriteLine("Hello world!");

            LocalPlayer.Instance.Alpha = 150;
            RpcManager.Instance.TriggerRPC("TestRpc", new SingleCastRpc<string>("Message from client"));
            RpcManager.Instance.RegisterRPC<SingleCastRpc<string>>("ServerTestRpc", x =>
            {
                ChatBox.WriteLine(x.Value);
            });
        }
    }
}
