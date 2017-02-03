using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automile.Net
{
    public class IMEIConfigEditModel
    {
        [Required]
        public int VehicleId { get; set; }
        
        public ApiIMEIDeviceType? IMEIDeviceType { get; set; }
    }
}
