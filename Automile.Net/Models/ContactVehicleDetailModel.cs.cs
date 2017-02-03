using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automile.Net
{
    public class ContactVehicleDetailModel
    {
        public int ContactVehicleId { get; set; }
        public int VehicleId { get; set; }
        public string NumberPlate { get; set; }
        public string MakeModelName { get; set; }
        public int ContactId { get; set; }
        public string ContactName { get; set; }
        public DateTime? LastModified { get; set; }
        public DateTime Created { get; set; }
        public IEnumerable<string> Scopes { get; set; }
    }
}
