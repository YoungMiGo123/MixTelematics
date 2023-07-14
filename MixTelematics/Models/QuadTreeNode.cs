namespace MixTelematics.Models
{
    public class QuadTreeNode
    {
        public QuadTreeNode Parent { get; set; }
        public QuadTreeNode[] Children { get; set; }
        public List<VehiclePosition> VehiclePositions { get; set; }
        public float X { get; set; }
        public float Y { get; set; }
        public float Width { get; set; }
        public float Height { get; set; }
    }
}
