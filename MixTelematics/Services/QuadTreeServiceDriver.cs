using MixTelematics.Models;
using MixTelematics.Utilities;

namespace MixTelematics.Services
{

    public class QuadTreeServiceDriver
    {
        List<Position> _startingCoordinates => Constants.GetStartingCoordinates();

        public async Task HandleFindClosestPositionsAsync(string pathToFile)
        {
            var vehiclePositions = await Task.Run(() => FileUtilityHelper.ReadBinaryDataFile(pathToFile)).ContinueWith(x => 
            {
                Logger.Log("Executing find nearest vehicles algorithm in Async"); 
                return x.Result; 
            }
            );

            var timeTracker = new TimeTracker();
            timeTracker.Start();

            QuadTree quadTree = new();

            quadTree.BuildTree(vehiclePositions, Constants.MinLongitude, Constants.MinLatitude, Constants.MaxLongitude, Constants.MaxLatitude);

            var tasks = new Task[]
            {
               Task.Run(() => quadTree.FindNearestPosition(_startingCoordinates[0].Latitude, _startingCoordinates[0].Longitude)).ContinueWith(x => Logger.Log(_startingCoordinates[0],x.Result)),
               Task.Run(() => quadTree.FindNearestPosition(_startingCoordinates[1].Latitude, _startingCoordinates[1].Longitude)).ContinueWith(x => Logger.Log(_startingCoordinates[1],x.Result)),
               Task.Run(() => quadTree.FindNearestPosition(_startingCoordinates[2].Latitude, _startingCoordinates[2].Longitude)).ContinueWith(x => Logger.Log(_startingCoordinates[2],x.Result)),
               Task.Run(() => quadTree.FindNearestPosition(_startingCoordinates[3].Latitude, _startingCoordinates[3].Longitude)).ContinueWith(x => Logger.Log(_startingCoordinates[3],x.Result)),
               Task.Run(() => quadTree.FindNearestPosition(_startingCoordinates[4].Latitude, _startingCoordinates[4].Longitude)).ContinueWith(x => Logger.Log(_startingCoordinates[4],x.Result)),
               Task.Run(() => quadTree.FindNearestPosition(_startingCoordinates[5].Latitude, _startingCoordinates[5].Longitude)).ContinueWith(x => Logger.Log(_startingCoordinates[5],x.Result)),
               Task.Run(() => quadTree.FindNearestPosition(_startingCoordinates[6].Latitude, _startingCoordinates[6].Longitude)).ContinueWith(x => Logger.Log(_startingCoordinates[6],x.Result)),
               Task.Run(() => quadTree.FindNearestPosition(_startingCoordinates[7].Latitude, _startingCoordinates[7].Longitude)).ContinueWith(x => Logger.Log(_startingCoordinates[7],x.Result)),
               Task.Run(() => quadTree.FindNearestPosition(_startingCoordinates[8].Latitude, _startingCoordinates[8].Longitude)).ContinueWith(x => Logger.Log(_startingCoordinates[8],x.Result)),
               Task.Run(() => quadTree.FindNearestPosition(_startingCoordinates[9].Latitude, _startingCoordinates[9].Longitude)).ContinueWith(x => Logger.Log(_startingCoordinates[9],x.Result)),
            };

            Task.WaitAll(tasks);

            timeTracker.End();

            Logger.Log($"Total Time taken: {timeTracker.TotalTimeTaken()}\nCompleted Successfully");
        }
        public void HandleFindClosestPositions(string pathToFile)
        {
            Logger.Log("Starting now, reading binary file: ");

            var vehiclePositions = FileUtilityHelper.ReadBinaryDataFile(pathToFile);

            Logger.Log("Executing find nearest vehicles algorithm in Sync");

            var timeTracker = new TimeTracker();
            timeTracker.Start();

            QuadTree quadTree = new();

            quadTree.BuildTree(vehiclePositions, Constants.MinLongitude, Constants.MinLatitude, Constants.MaxLongitude, Constants.MaxLatitude);

            foreach (var coordinate in _startingCoordinates)
            {
                var nearestPosition = quadTree.FindNearestPosition(coordinate.Latitude, coordinate.Longitude);
                Logger.Log(coordinate, nearestPosition);
            }

            timeTracker.End();

            Logger.Log($"Total Time taken: {timeTracker.TotalTimeTaken()}\nCompleted Successfully");

        }


    }
}
