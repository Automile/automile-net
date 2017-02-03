using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automile.Net
{
    public class CompanyVehicleEditModel
    {
        [Required]
        public int CompanyId { get; set; }
        [Required]
        public int VehicleId { get; set; }
    }
}
