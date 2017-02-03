using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Automile.Net
{
    public class IMEIEventStatusModel : IMEIEventModelBase
    {
        public string Status { get; set; } // Connet / Disconnect
        //public string Description { get; set; } // The device has been connected to the vehicle

        //public IMEIEventStatusModel(IMEIEvent eventEntity)
        //    : base(eventEntity)
        //{
        //    base.Description = "Device connection status";

        //    Status = "Device Connected";

        //    if(eventEntity.EventType.ToString() == "137")
        //    Status = "Device DisConnected";
            
        //}

    }
}
