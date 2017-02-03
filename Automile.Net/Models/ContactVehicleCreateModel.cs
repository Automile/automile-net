using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automile.Net
{
    public class ContactVehicleCreateModel
    {

        [Required]
        public int VehicleId { get; set; }

        [Required]
        public int ContactId { get; set; }

    }
}
