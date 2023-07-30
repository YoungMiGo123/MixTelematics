using MixTelematics.Utilities;

namespace MixTelematics.Models
{
    public class QuadTreeOptimized
    {
        private const int MaxObjectsPerNode = 4; 
        private const int MaxLevels = 3; 

        private QuadTreeNodeOptimized root;
        public QuadTreeOptimized(double minX, double minY, double maxX, double maxY)
        {
            root = new QuadTreeNodeOptimized((minX + maxX) / 2, (minY + maxY) / 2);
        }
        public QuadTreeOptimized(List<VehiclePosition> positions, float minX, float minY, float maxX, float maxY)
        {
            root = new QuadTreeNodeOptimized((minX + maxX) / 2, (minY + maxY) / 2);
            foreach (var position in positions)
            {
                Insert(position);
            }
        }
        public void Insert(VehiclePosition vehiclePosition)
        {
            Insert(root, vehiclePosition, MaxLevels);
        }

        private void Insert(QuadTreeNodeOptimized node, VehiclePosition vehiclePosition, int level)
        {
            if (level == 0)
            {
                node.Vehicles.Add(vehiclePosition);
                return;
            }

            double x = vehiclePosition.Latitude;
            double y = vehiclePosition.Longitude;

            if (x < node.X)
            {
                if (y < node.Y)
                {
                    if (node.NW == null)
                        node.NW = new QuadTreeNodeOptimized(node.X - (node.X - x) / 2, node.Y - (node.Y - y) / 2);

                    Insert(node.NW, vehiclePosition, level - 1);
                }
                else
                {
                    if (node.SW == null)
                        node.SW = new QuadTreeNodeOptimized(node.X - (node.X - x) / 2, node.Y + (y - node.Y) / 2);

                    Insert(node.SW, vehiclePosition, level - 1);
                }
            }
            else
            {
                if (y < node.Y)
                {
                    if (node.NE == null)
                        node.NE = new QuadTreeNodeOptimized(node.X + (x - node.X) / 2, node.Y - (node.Y - y) / 2);

                    Insert(node.NE, vehiclePosition, level - 1);
                }
                else
                {
                    if (node.SE == null)
                        node.SE = new QuadTreeNodeOptimized(node.X + (x - node.X) / 2, node.Y + (y - node.Y) / 2);

                    Insert(node.SE, vehiclePosition, level - 1);
                }
            }

            if (node.Vehicles.Count > MaxObjectsPerNode && level > 0)
            {
                var vehicles = new List<VehiclePosition>(node.Vehicles);
                node.Vehicles.Clear();

                foreach (var vehicle in vehicles)
                {
                    Insert(node, vehicle, level - 1);
                }
            }
        }

        public VehiclePosition FindClosestVehicle(Position originalPosition)
        {
            return FindClosestVehicle(root, originalPosition, double.MaxValue);
        }

        private VehiclePosition FindClosestVehicle(QuadTreeNodeOptimized node, Position originalPosition, double minDistance)
        {
            VehiclePosition closestVehicle = null;
            double distance = double.MaxValue;

            foreach (var vehicle in node.Vehicles)
            {
                double currDistance = MathUtilityHelper.CalculateDistance(originalPosition, vehicle.Latitude, vehicle.Longitude);
                if (currDistance < distance)
                {
                    distance = currDistance;
                    closestVehicle = vehicle;
                }
            }

            if (node.NW != null && minDistance >= distance)
            {
                VehiclePosition nwClosest = FindClosestVehicle(node.NW, originalPosition, minDistance);
                if (nwClosest != null)
                {
                    double nwDistance = MathUtilityHelper.CalculateDistance(originalPosition, nwClosest.Latitude, nwClosest.Longitude);
                    if (nwDistance < distance)
                    {
                        distance = nwDistance;
                        closestVehicle = nwClosest;
                    }
                }
            }

            if (node.NE != null && minDistance >= distance)
            {
                VehiclePosition neClosest = FindClosestVehicle(node.NE, originalPosition, minDistance);
                if (neClosest != null)
                {
                    double neDistance = MathUtilityHelper.CalculateDistance(originalPosition, neClosest.Latitude, neClosest.Longitude);
                    if (neDistance < distance)
                    {
                        distance = neDistance;
                        closestVehicle = neClosest;
                    }
                }
            }

            if (node.SW != null && minDistance >= distance)
            {
                VehiclePosition swClosest = FindClosestVehicle(node.SW, originalPosition, minDistance);
                if (swClosest != null)
                {
                    double swDistance = MathUtilityHelper.CalculateDistance(originalPosition, swClosest.Latitude, swClosest.Longitude);
                    if (swDistance < distance)
                    {
                        distance = swDistance;
                        closestVehicle = swClosest;
                    }
                }
            }

            if (node.SE != null && minDistance >= distance)
            {
                VehiclePosition seClosest = FindClosestVehicle(node.SE, originalPosition, minDistance);
                if (seClosest != null)
                {
                    double seDistance = MathUtilityHelper.CalculateDistance(originalPosition, seClosest.Latitude, seClosest.Longitude);
                    if (seDistance < distance)
                    {
                        closestVehicle = seClosest;
                    }
                }
            }

            return closestVehicle;
        }



    }
}
