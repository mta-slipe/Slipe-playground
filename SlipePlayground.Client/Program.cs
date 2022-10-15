using SlipeLua.Client.IO;
using SlipeLua.Client.Peds;
using SlipeLua.Shared.Attributes;

namespace SlipePlayground.Client
{
    public class Program
    {

        [ClientEntryPoint]
        public static void Main(string[] args)
        {
            ChatBox.WriteLine("Hello world!");

            LocalPlayer.Instance.Alpha = 150;
        }
    }
}
