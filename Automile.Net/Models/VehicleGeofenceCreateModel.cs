using System;
using System.ComponentModel.DataAnnotations;

namespace Automile.Net
{
    public class VehicleGeofenceCreateModel
    {
        [Required]
        public int VehicleId { get; set; }

        [Required]
        public int GeofenceId { get; set; }

        public DateTime? ValidFrom { get; set; }
        public DateTime? ValidTo { get; set; }
    }

    public class VehiclePalceCreateModel
    {
        [Required]
        public int VehicleId { get; set; }

        [Required]
        public int PlaceId { get; set; }        
    }
}