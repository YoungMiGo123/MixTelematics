using MixTelematics.Models;

namespace MixTelematics.Utilities
{
    public class MathUtilityHelper
    {
        public static bool IsPointInBounds(QuadTreeNode node, float x, float y)
        {
            return x >= node.X && x <= node.X + node.Width &&
                   y >= node.Y && y <= node.Y + node.Height;
        }

        public static float CalculateDistance(float x1, float y1, float x2, float y2)
        {
            float dx = x2 - x1;
            float dy = y2 - y1;
            return (float)Math.Sqrt(dx * dx + dy * dy);
        }

        public static double CalculateDistance(Position p1, Position p2)
        {
            double latDiff = p1.Latitude - p2.Latitude;
            double lonDiff = p1.Longitude - p2.Longitude;
            return Math.Sqrt(latDiff * latDiff + lonDiff * lonDiff);
        }
        public static double CalculateDistance(Position point, double lat, double lon)
        {
            double latDiff = point.Latitude - lat;
            double lonDiff = point.Longitude - lon;
            return Math.Sqrt(latDiff * latDiff + lonDiff * lonDiff);
        }
        public static bool IsPositionInNode(QuadTreeNode node, VehiclePosition position)
        {
            var isPosInNode = position.Latitude >= node.X && position.Latitude <= node.X + node.Width &&
                   position.Longitude >= node.Y && position.Longitude <= node.Y + node.Height;
            return isPosInNode;
        }
    }
}
