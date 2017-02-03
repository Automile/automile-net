using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Automile.Net
{
    public class PIDModel
    {
        [JsonConverter(typeof(ByteArrayConverter))]
        public byte[] Data { get; set; }

        public DateTime RecordTimeStamp { get; set; }
        public double? Value { get; set; }
    }
}
