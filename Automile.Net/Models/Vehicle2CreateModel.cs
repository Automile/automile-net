using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace Automile.Net
{
    public class Vehicle2CreateModel
    {
        public string NumberPlate { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public short? ModelYear { get; set; }
        public string BodyStyle { get; set; }
        public int? OwnerContactId { get; set; }
        public int? OwnerCompanyId { get; set; }

        [Required]
        public int? CreateRelationshipToId { get; set; }

        [Required]
        public VehicleRelationshipType? VehicleRelationshipType { get; set; }

        // New props
        public string UserVehicleIdentificationNumber { get; set; }
        //public string NumberPlate { get; set; }
        //public string Make { get; set; }
        //public string Model { get; set; }
        //public int ModelYear { get; set; }
        //public string BodyStyle { get; set; }
        public ApiMainFuelType? FuelType { get; set; }
        public ApiTripType? DefaultTripType { get; set; }
        //public int OwnerContactId { get; set; }
        //public int? OwnerCompanyId { get; set; }
        
        public bool AllowAutomaticUpdates { get; set; }
        public ApiPrivacyPolicyType? DefaultPrivacyPolicyType { get; set; }
        public string Nickname { get; set; }

        public string Tags { get; set; }
        public int? CategoryColor { get; set; }
    }
}
