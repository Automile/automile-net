using System;

namespace Automile.Net
{
    public class VehicleGeofenceModel
    {
        public int VehicleGeofenceId { get; set; }
        public int VehicleId { get; set; }
        public int GeofenceId { get; set; }
        public DateTime? ValidFrom { get; set; }
        public DateTime? ValidTo { get; set; }
    }

    public class VehiclePlaceModel
    {
        public int VehiclePlaceId { get; set; }
        public int VehicleId { get; set; }
        public int PlaceId { get; set; }        
    }
}