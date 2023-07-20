﻿using MixTelematics.Models;
using MixTelematics.Utilities;

namespace MixTelematics.Services
{

    public class TreeServiceDriver
    {
        List<Position> _startingCoordinates => Constants.GetStartingCoordinates();

        public async Task HandleFindClosestPositionsAsync(string pathToFile)
        {
            var timeTracker = new TimeTracker();
            timeTracker.Start();

            var vehiclePositions = await Task.Run(() => FileUtilityHelper.ReadBinaryDataFile(pathToFile)).ContinueWith(x => 
            {
                Logger.Log("Executing find nearest vehicles algorithm in Async"); 
                return x.Result; 
            });

            QuadTree quadTree = new();

            quadTree.BuildTree(vehiclePositions, Constants.MinLongitude, Constants.MinLatitude, Constants.MaxLongitude, Constants.MaxLatitude);
            var vehiclePositionsResults = new List<VehiclePosition>();
            var tasks = new Task<VehiclePosition>[]
            {
               Task.Run(() => quadTree.FindNearestPosition(_startingCoordinates[0].Latitude, _startingCoordinates[0].Longitude)),
               Task.Run(() => quadTree.FindNearestPosition(_startingCoordinates[1].Latitude, _startingCoordinates[1].Longitude)),
               Task.Run(() => quadTree.FindNearestPosition(_startingCoordinates[2].Latitude, _startingCoordinates[2].Longitude)),
               Task.Run(() => quadTree.FindNearestPosition(_startingCoordinates[3].Latitude, _startingCoordinates[3].Longitude)),
               Task.Run(() => quadTree.FindNearestPosition(_startingCoordinates[4].Latitude, _startingCoordinates[4].Longitude)),
               Task.Run(() => quadTree.FindNearestPosition(_startingCoordinates[5].Latitude, _startingCoordinates[5].Longitude)),
               Task.Run(() => quadTree.FindNearestPosition(_startingCoordinates[6].Latitude, _startingCoordinates[6].Longitude)),
               Task.Run(() => quadTree.FindNearestPosition(_startingCoordinates[7].Latitude, _startingCoordinates[7].Longitude)),
               Task.Run(() => quadTree.FindNearestPosition(_startingCoordinates[8].Latitude, _startingCoordinates[8].Longitude)),
               Task.Run(() => quadTree.FindNearestPosition(_startingCoordinates[9].Latitude, _startingCoordinates[9].Longitude)),
            };

            Task.WaitAll(tasks);
            
            var result = string.Join(",", tasks.Select(x => x.Result.PositionId));
            Logger.Log("Nearest Neighbouring Position Ids: ", result);

            timeTracker.End();

            Logger.Log($"Total Time taken: {timeTracker.TotalTimeTaken()}\nCompleted Successfully");
        }
        public async Task HandleFindClosestPositionsV2(string pathToFile)
        {
            Logger.Log("Starting now, reading binary file: ");

            var timeTracker = new TimeTracker();
            timeTracker.Start();

            var vehiclePositions = await Task.Run(() => FileUtilityHelper.ReadBinaryDataFile(pathToFile)).ContinueWith(x =>
            {
                Logger.Log("Executing find nearest vehicles algorithm in Async");
                return x.Result;
            });

            var KDTree = new KDTree(vehiclePositions);
      
            var tasks = new Task<VehiclePosition>[]
            {
               Task.Run(() => { Logger.Log(_startingCoordinates[0]); return KDTree.FindNearestNeighbor(_startingCoordinates[0]); }),
               Task.Run(() => { Logger.Log(_startingCoordinates[1]); return KDTree.FindNearestNeighbor(_startingCoordinates[1]); }),
               Task.Run(() => { Logger.Log(_startingCoordinates[2]); return KDTree.FindNearestNeighbor(_startingCoordinates[2]); }),
               Task.Run(() => { Logger.Log(_startingCoordinates[3]); return KDTree.FindNearestNeighbor(_startingCoordinates[3]); }),
               Task.Run(() => { Logger.Log(_startingCoordinates[4]); return KDTree.FindNearestNeighbor(_startingCoordinates[4]); }),
               Task.Run(() => { Logger.Log(_startingCoordinates[5]); return KDTree.FindNearestNeighbor(_startingCoordinates[5]); }),
               Task.Run(() => { Logger.Log(_startingCoordinates[6]); return KDTree.FindNearestNeighbor(_startingCoordinates[6]); }),
               Task.Run(() => { Logger.Log(_startingCoordinates[7]); return KDTree.FindNearestNeighbor(_startingCoordinates[7]); }),
               Task.Run(() => { Logger.Log(_startingCoordinates[8]); return KDTree.FindNearestNeighbor(_startingCoordinates[8]); }),
               Task.Run(() => { Logger.Log(_startingCoordinates[9]); return KDTree.FindNearestNeighbor(_startingCoordinates[9]); }),
            };

            Task.WaitAll(tasks);

            var result = string.Join(",", tasks.Select(x => x.Result.PositionId));
            Logger.Log("Nearest Neighbouring Position Ids: ", result);
            timeTracker.End();

            Logger.Log($"Total Time taken: {timeTracker.TotalTimeTaken()}\nCompleted Successfully");
        }
        public void HandleFindClosestPositions(string pathToFile)
        {
            var timeTracker = new TimeTracker();
            timeTracker.Start();

            Logger.Log("Starting now, reading binary file: ");

            var vehiclePositions = FileUtilityHelper.ReadBinaryDataFile(pathToFile);

            Logger.Log("Executing find nearest vehicles algorithm in Sync");

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