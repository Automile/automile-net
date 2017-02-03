using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automile.Net
{
    public class IMEIEventModel
    {

        public int IMEIEventId { get; set; }
        public string IMEI { get; set; }
        public string EventType { get; set; }
        public System.DateTime TimeStamp { get; set; }

    }
}
