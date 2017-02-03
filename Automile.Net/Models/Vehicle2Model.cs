using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Automile.Net
{
    public class Vehicle2Model
    {
        public int VehicleId { get; set; }
        public string VehicleIdentificationNumber { get; set; }
        public string NumberPlate { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int? OwnerContactId { get; set; }
        public int? OwnerCompanyId { get; set; }
        public decimal? CurrentOdometerInKilometers { get; set; }

        public string UserVehicleIdentificationNumber { get; set; }
        public int? ModelYear { get; set; }
        public string BodyStyle { get; set; }
        public ApiMainFuelType? FuelType { get; set; }
        public ApiTripType? DefaultTripType { get; set; }
        public bool AllowAutomaticUpdates { get; set; }
        public ApiPrivacyPolicyType? DefaultPrivacyPolicyType { get; set; }
        public int? CheckedInContactId { get; set; }
        public bool IsEditable { get; set; }
        public string MakeImageUrl { get; set; }
        public int? TransferIntervalInSeconds { get; set; }
        public bool? SampleHarshEvents { get; set; }
        public List<string> Features { get; set; }
        public bool? AllowSpeedRecording { get; set; }
        public string Nickname { get; set; }

        public int? CategoryColor { get; set; }
        public string Tags { get; set; }
    }
}
