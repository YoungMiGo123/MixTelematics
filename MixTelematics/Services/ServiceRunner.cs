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
            var quadTreeServiceDriver = new QuadTreeServiceDriver();
            var path = @"..\..\..\VehiclePositions.dat";
            await quadTreeServiceDriver.HandleFindClosestPositionsAsync(path);
        }
        public static async Task Run()
        {
            var quadTreeServiceDriver = new QuadTreeServiceDriver();
            var path = @"..\..\..\VehiclePositions.dat";
            await quadTreeServiceDriver.HandleFindClosestPositionsV2(path);
        }
    }
}
