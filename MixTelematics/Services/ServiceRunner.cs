using MixTelematics.Utilities;

namespace MixTelematics.Services
{
    public class ServiceRunner
    {
        public static async Task Execute()
        {
            Logger.Log("Before we start, please confirm would you like to run the program synchronously or asynchronously ? \n Enter S or A respectively for each choice");

            if (Logger.ReadInput()?.Equals("s", StringComparison.OrdinalIgnoreCase) ?? true)
            {
                Run();
            }
            else
            {
                await RunAsync();
            }
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
