namespace MixTelematics.Models
{
    public class Position
    {
        public int PositionId { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }

        public override string ToString()
        {
            return $"Initial Position: Latitude = {Latitude}, Longitude = {Longitude}";
        }
    }
}
