using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automile.Net
{
    public class VehicleModel
    {
        public int VehicleId { get; set; }
        public string VehicleIdentificationNumber { get; set; }
        public string NumberPlate { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int? OwnerContactId { get; set; }
        public int? OwnerCompanyId { get; set; }

        public decimal? CurrentOdometerInKilometers { get; set; }
    }
}
