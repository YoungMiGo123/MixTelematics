using MixTelematics.Utilities;

namespace MixTelematics.Models
{

    public class KDTree
    {
        private KDNode root;

        public KDTree(List<VehiclePosition> positions)
        {
            root = BuildTree(positions.ToArray(), 0);
        }
        public VehiclePosition FindNearestNeighbor(Position target)
        {
            KDNode nearestNode = FindNearestNeighbor(root, target, 0);
            return nearestNode?.VehiclePosition ?? new VehiclePosition();
        }
        private KDNode BuildTree(VehiclePosition[] positions, int depth)
        {
            if (positions.Length == 0)
                return null;

            int axis = depth % 2; // Two dimensions: Latitude and Longitude

            int medianIndex = positions.Length / 2;
            SelectSort(positions, medianIndex, axis); 


            var vehiclePosition = positions[medianIndex];

            var medianPosition = new Position() { Latitude = vehiclePosition.Latitude, Longitude = vehiclePosition.Longitude, PositionId = vehiclePosition.PositionId }; 

            var node = new KDNode
            {
                Position = medianPosition,
                VehiclePosition = vehiclePosition,
                Left = BuildTree(positions[0..medianIndex], depth + 1),
                Right = BuildTree(positions[(medianIndex + 1)..], depth + 1)
            };
 
            return node;
        }

        private void SelectSort(VehiclePosition[] positions, int k, int axis)
        {
            int left = 0;
            int right = positions.Length - 1;

            while (left < right)
            {
                int pivotIndex = Partition(positions, left, right, axis);
                if (pivotIndex == k)
                    return;
                else if (pivotIndex < k)
                    left = pivotIndex + 1;
                else
                    right = pivotIndex - 1;
            }
        }
      
        private int Partition(VehiclePosition[] positions, int left, int right, int axis)
        {
            VehiclePosition pivot = positions[right];
            int i = left;

            for (int j = left; j < right; j++)
            {
                if (Compare(positions[j], pivot, axis) < 0)
                {
                    Swap(positions, i, j);
                    i++;
                }
            }

            Swap(positions, i, right);
            return i;
        }
        private int Compare(VehiclePosition p1, VehiclePosition p2, int axis)
        {
            if (axis == 0)
                return p1.Latitude.CompareTo(p2.Latitude);
            else
                return p1.Longitude.CompareTo(p2.Longitude);
        }
        private void Swap(VehiclePosition[] positions, int i, int j)
        {
            var temp = positions[i];
            positions[i] = positions[j];
            positions[j] = temp;
        }


        private KDNode FindNearestNeighbor(KDNode node, Position target, int depth)
        {
            if (node == null)
                return null;

            int axis = depth % 2; // Two dimensions: Latitude and Longitude

            KDNode bestNode, otherNode;
            if (axis == 0)
            {
                if (target.Latitude < node.Position.Latitude)
                {
                    bestNode = FindNearestNeighbor(node.Left, target, depth + 1);
                    otherNode = node.Right;
                }
                else
                {
                    bestNode = FindNearestNeighbor(node.Right, target, depth + 1);
                    otherNode = node.Left;
                }
            }
            else
            {
                if (target.Longitude < node.Position.Longitude)
                {
                    bestNode = FindNearestNeighbor(node.Left, target, depth + 1);
                    otherNode = node.Right;
                }
                else
                {
                    bestNode = FindNearestNeighbor(node.Right, target, depth + 1);
                    otherNode = node.Left;
                }
            }

            if (bestNode == null || MathUtilityHelper.CalculateDistance(target, bestNode.Position) > MathUtilityHelper.CalculateDistance(target, node.Position))
            {
                bestNode = node;
            }

            if (axis == 0)
            {
                if (MathUtilityHelper.CalculateDistance(target, bestNode.Position) > Math.Abs(target.Latitude - node.Position.Latitude))
                {
                    KDNode tempNode = FindNearestNeighbor(otherNode, target, depth + 1);
                    if (tempNode != null && (bestNode == null || MathUtilityHelper.CalculateDistance(target, bestNode.Position) > MathUtilityHelper.CalculateDistance(target, tempNode.Position)))
                    {
                        bestNode = tempNode;
                    }
                }
            }
            else
            {
                if (MathUtilityHelper.CalculateDistance(target, bestNode.Position) > Math.Abs(target.Longitude - node.Position.Longitude))
                {
                    KDNode tempNode = FindNearestNeighbor(otherNode, target, depth + 1);
                    if (tempNode != null && (bestNode == null || MathUtilityHelper.CalculateDistance(target, bestNode.Position) > MathUtilityHelper.CalculateDistance(target, tempNode.Position)))
                    {
                        bestNode = tempNode;
                    }
                }
            }

            return bestNode;
        }

     
    }

}
