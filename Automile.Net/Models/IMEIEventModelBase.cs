using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Automile.Net
{
    public abstract class IMEIEventModelBase
    {
        public string Description { get; set; } 
        public DateTime TimeStamp { get; set; }
        public short? TimeZone { get; set; }
        public string EventType { get; set; }
        public double? PositionLongitude { get; set; }
        public double? PositionLatitude { get; set; }
        public string PositionFormattedAddress { get; set; }
        public int? CellTower { get; set; }
        public short? CellTowerTimeZone { get; set; }
        public string VehicleIdentificationNumber { get; set; }

        public string IMEI { get; set; }

        public String DeviceSerialNumber { get; set; }

      
    }
}
