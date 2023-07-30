using MixTelematics.Utilities;

namespace MixTelematics.Services
{
    public class ServiceRunner
    {
        public static async Task Execute()
        {
             await Run();
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
