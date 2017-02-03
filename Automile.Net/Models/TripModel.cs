using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Automile.Net
{
    public class TripModel
    {
        public int TripId { get; set; }
        public DateTime TripStartDateTime { get; set; }
        public DateTime? TripEndDateTime { get; set; }
        public decimal? DistanceKilometers { get; set; }
        public decimal? FuelConsumptionInLiters { get; set; }
        public string TripStartFormattedAddress { get; set; }
        public string TripEndFormattedAddress { get; set; }
        public string TripStartCustomAddress { get; set; }
        public string TripEndCustomAddress { get; set; }
        public int? VehicleId { get; set; }
        public ApiTripType TripType { get; set; }
        public int? DriverContactId { get; set; }

        public bool HasSpeedingViolation { get; set; }
        public bool HasIdlingEvent { get; set; }
        public bool HasAccelerationEvent { get; set; }
        public bool HasAccident { get; set; }
        public bool HasTurningEvent { get; set; }
        public bool HasBrakingEvent { get; set; }

        public int? ParkedForMinutesUntilNextTrip { get; set; }
        public bool HasDrivingEvents { get; set; }
        public string CustomCategory { get; set; }
        public string TripTags { get; set; }
    }    
}
