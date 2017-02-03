using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automile.Net
{
    public class VehicleDetailModel
    {
        public string VehicleIdentificationNumber { get; set; }
        public string NumberPlate { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int? ModelYear { get; set; }
        public string BodyStyle { get; set; }
        public int? OwnerContactId { get; set; }
        public int? OwnerCompanyId { get; set; }
        public string OwnedByName { get; set; }
        public int NumberOfTrips { get; set; }
        public decimal? DistanceTravelledThisYear { get; set; }
        public decimal? DistanceTravelledLastYear { get; set; }
        public double? LastKnownLatitude { get; set; }
        public double? LastKnownLongitude { get; set; }
        public DateTime? LastKnownGeoTimeStamp { get; set; }    
        public string LastKnownFormattedAddress { get; set; }
        public string LastKnownCustomAddress { get; set; }
        public double? LastKnownSpeed { get; set; }
        public double? LastKnownTemperature { get; set; }
        public DateTime? LastKnownTemperatureTimeStamp { get; set; }
        public double? LastTripEndLatitude { get; set; }
        public double? LastTripEndLongitude { get; set; }
        public DateTime? LastTripEndGeoTimeStamp { get; set; }
        public int? ParkedForNumberOfSeconds { get; set; }
        public int? OngoingTripId { get; set; }
        public string MakeImageUrl { get; set; }
        public decimal? CurrentOdometerInKilometers { get; set; }        
    }
}
