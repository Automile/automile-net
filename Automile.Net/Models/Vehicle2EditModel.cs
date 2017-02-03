using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;



namespace Automile.Net
{
    public class Vehicle2EditModel
    {
        public string NumberPlate { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public short? ModelYear { get; set; }
        public string BodyStyle { get; set; }
        public int? OwnerContactId { get; set; }
        public int? OwnerCompanyId { get; set; }
        public string UserVehicleIdentificationNumber { get; set; }
        public ApiMainFuelType? FuelType { get; set; }
        public ApiTripType? DefaultTripType { get; set; }
        public bool AllowAutomaticUpdates { get; set; }
        public string FrontTyre { get; set; }
        public string RearTyre { get; set; }
        public string FrontWheelRim { get; set; }
        public string RearWheelRim { get; set; }
        public bool? TrailerHitch { get; set; }
        public decimal OdometerInKilometers { get; set; }
        public bool HasOdometerChanged { get; set; }
        public ApiPrivacyPolicyType? DefaultPrivacyPolicyType { get; set; }
        public bool? UpdateFromTransportstyrelsen  { get; set; }
        public bool? AllowSpeedRecording { get; set; }
        public string Nickname { get; set; }
        public string Tags { get; set; }

        /// <summary>
        /// Supported colors (hex value), 
        /// 3652794 (#37BCBA),
        /// 2591227 (#2789FB),
        /// 11430900 (#AE6BF4),
        /// 16478657 (#FB71C1),
        /// 16735053 (#FF5B4D),
        /// 16752644 (#FFA004),
        /// 16772393 (#FFED29),
        /// 13228106 (#C9D84A),
        /// 6597394 (#64AB12),
        /// 12096370 (#B89372)
        /// </summary>
        public int? CategoryColor { get; set; }
    }
}
