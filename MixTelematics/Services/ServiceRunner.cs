using MixTelematics.Utilities;

namespace MixTelematics.Services
{
    public class ServiceRunner
    {
        public static async Task Execute()
        {
            await RunAsync();
        }
        public static async Task RunAsync()
        {
            var quadTreeServiceDriver = new QuadTreeServiceDriver();
            var path = @"..\..\..\VehiclePositions.dat";
            await quadTreeServiceDriver.HandleFindClosestPositionsAsync(path);
        }
        public static void Run()
        {
            var quadTreeServiceDriver = new QuadTreeServiceDriver();
            var path = @"..\..\..\VehiclePositions.dat";
            quadTreeServiceDriver.HandleFindClosestPositions(path);
        }
    }
}
