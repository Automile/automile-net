using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automile.Net
{
 
    /// <summary>
    /// PID05
    /// </summary>
    public class TripDataAccelerometerModel
    {

        public double? XAccelerationInG { get; set; }

        public double? YAccelerationInG { get; set; }

        public double? ZAccelerationInG { get; set; }

        public Byte SampleNumber { get; set; }

        public DateTime RecordTimeStamp { get; set; }

        public bool? IsNormalized { get; set; }

    }
}
