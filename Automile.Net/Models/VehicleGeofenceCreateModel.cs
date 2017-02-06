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

    public class VehiclePlaceCreateModel
    {
        [Required]
        public int VehicleId { get; set; }

        [Required]
        public int PlaceId { get; set; }

        public string Description { get; set; }

        public ApiTripType? TripType { get; set; }

        public ApiTripTypeTrigger? TripTypeTrigger { get; set; }

        [Required(ErrorMessage = "You need to supply a radius")]
        public int Radius { get; set; }

        public int? DrivesBetweenAnotherPlaceId { get; set; }
    }

    public class VehiclePlaceEditModel
    {
        public string Description { get; set; }

        public ApiTripType? TripType { get; set; }

        public ApiTripTypeTrigger? TripTypeTrigger { get; set; }

        [Required(ErrorMessage = "You need to supply a radius")]
        public int Radius { get; set; }

        public int? DrivesBetweenAnotherPlaceId { get; set; }
    }
}