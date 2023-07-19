namespace MixTelematics.Models
{
 
    public class KDNode
    {
        public Position Position { get; set; }
        public VehiclePosition VehiclePosition { get; set; }
        public KDNode Left { get; set; }
        public KDNode Right { get; set; }

    }

}
