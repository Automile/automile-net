using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Automile.Net
{
    public class IMEIEventMILModel : IMEIEventModelBase
    {

        public bool MilStatus { get; set; }

        public int NumberOfDTCs { get; set; } // of DTCs : Total DTC codes in the vehicle.
        public int MILDistance { get; set; } //distance : Distance travelled while MIL is Activated (km)OperatingSystem
        public int CLRDistance { get; set; }// distance: Distance since diagnostic trouble codes cleared (km)
        public int TripDistance { get; set; } //:Accumulated trip miles since1st time device connection to above MIL info stored (km)
        public int MILTime { get; set; } //: Time run by the engine while MIL is activated (min)
        public int CLRTime { get; set; } //: Time since diagnostic trouble codes cleared (min)
        public int TripTime { get; set; } //:Accumulated Trip time since the 1st time device connection to above MIL info stored ( sec ): 

       

    }
}
