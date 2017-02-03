using System;

namespace Automile.Net
{
    public class VehicleStatusModel
    {
        public int VehicleId { get; set; }
        public DateTime? LastPositionUtc { get; set; }
        public double? LastKnownLatitude { get; set; }
        public double? LastKnownLongitude { get; set; }
        public bool IsDriving { get; set; }
        public string MakeImageUrl { get; set; }
        public int? ParkedForNumberOfSeconds { get; set; }
        public int? DrivingForNumberOfSeconds { get; set; }
        public string LastKnownFormattedAddress { get; set; }
        public string LastKnownStreetAddress { get; set; }
        public string LastKnownCity { get; set; }
    }
}
