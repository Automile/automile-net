using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Automile.Net
{
    public class IMEIEventDTCModel : IMEIEventModelBase
    {
        public List<DTC> Dtcs { get; set; }

 
      
    }

    public class DTC
    {
        public string DTCCode { get; set; }
        public string FaultLocation { get; set; }
        public string ProbableCause { get; set; }

    }
}
