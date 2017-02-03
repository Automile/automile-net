using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Automile.Net
{
    public class VehicleEditModel
    {
        public string NumberPlate { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public short? ModelYear { get; set; }
        public string BodyStyle { get; set; }
        public int? OwnerContactId { get; set; }
        public int? OwnerCompanyId { get; set; }
    
    }
}
