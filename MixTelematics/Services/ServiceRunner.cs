using MixTelematics.Utilities;

namespace MixTelematics.Services
{
    public class ServiceRunner
    {
        public static async Task Execute()
        {
            Logger.Log("Quad Tree V2 Optimized Approach");
            await RunAsyncV2();
        }
        public static async Task RunAsyncV2()
        {
            var quadTreeServiceDriver = new TreeServiceDriver();
            await quadTreeServiceDriver.HandleFindClosestPositionsAsyncV2();
        }
        public static async Task RunAsync()
        {
            var quadTreeServiceDriver = new TreeServiceDriver();
            await quadTreeServiceDriver.HandleFindClosestPositionsAsync();
        }
        public static async Task Run()
        {
            var quadTreeServiceDriver = new TreeServiceDriver();
            await quadTreeServiceDriver.HandleFindClosestPositionsV2();
        }
    }
}
