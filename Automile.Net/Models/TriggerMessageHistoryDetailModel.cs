using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Automile.Net
{
    public class TriggerMessageHistoryModel
    {
        public int TriggerMessageHistoryId { get; set; }
        public int TriggerId { get; set; }
        public Nullable<System.DateTime> WasSentOn { get; set; }
        public ApiDestinationType DestinationType { get; set; }
        public string DestinationData { get; set; }
        public string MessageData1 { get; set; }
        public string MessageData2 { get; set; }
    }
}
