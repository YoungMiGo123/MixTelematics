using MixTelematics.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MixTelematics.Utilities
{
    public class Constants
    {
        public const float MinLatitude = -90f;
        public const float MaxLatitude = 90f;
        public const float MinLongitude = -180f;
        public const float MaxLongitude = 180f;
        public static List<Position> GetStartingCoordinates()
        {
            List<Position> coordinates = new()
            {
                new() { Latitude = 34.544909f, Longitude = -102.100843f },
                new() { Latitude = 32.345544f, Longitude = -99.123124f },
                new() { Latitude = 33.234235f, Longitude = -100.214124f },
                new() { Latitude = 35.195739f, Longitude = -95.348899f },
                new() { Latitude = 31.895839f, Longitude = -97.789573f },
                new() { Latitude = 32.895839f, Longitude = -101.789573f },
                new() { Latitude = 34.115839f, Longitude = -100.225732f },
                new() { Latitude = 32.335839f, Longitude = -99.992232f },
                new() { Latitude = 33.535339f, Longitude = -94.792232f },
                new() { Latitude = 32.234235f, Longitude = -100.222222f }
            };
            return coordinates;
        }
    }
}
