using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automile.Net
{
    public class IMEIConfigCreateModel
    {
        [Required]
        public string IMEI { get; set; }
        [Required]
        public int VehicleId { get; set; }
        [Required]
        public string SerialNumber { get; set; }

        public IMEIDeviceType? IMEIDeviceType { get; set; }
    }
}
