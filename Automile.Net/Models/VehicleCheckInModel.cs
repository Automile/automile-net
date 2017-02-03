using System;


namespace Automile.Net
{
    public class VehicleCheckInModel
    {
        public int? ContactId { get; set; }
        public int VehicleId { get; set; }
        public ApiTripType? DefaultTripType { get; set; }
        public DateTime? CheckOutAtUtc { get; set; }

        public ApiDeviceType UserDeviceType { get; set; }
        public string UserDeviceToken { get; set; }
    }
}
