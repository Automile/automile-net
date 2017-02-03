using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Automile.Net
{
    public class IMEIConfigDetailModel
    {
        public int IMEIConfigId { get; set; }
        public string IMEI { get; set; }
        public int? VehicleId { get; set; }
        public ApiIMEIDeviceType? DeviceType { get; set; }
    }
}
