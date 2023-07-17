namespace MixTelematics.Models
{
    public class VehiclePosition
    {
        public int PositionId { get; set; }
        public string VehicleRegistration { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public ulong RecordedTimeUTC { get; set; }

        public override string ToString()
        {
            return $"Position ID: {PositionId} \n" +
            $"Registration: {VehicleRegistration} \n" +
            $"Latitude: {Latitude} \n" +
            $"Longitude: {Longitude} \n" +
            $"Recorded Time (UTC): {RecordedTimeUTC} \n";

        }
    }
}
