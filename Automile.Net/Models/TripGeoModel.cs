using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automile.Net
{
    public class TripGeoModel
    {
        public DateTime RecordTimeStamp { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public short? HeadingDegrees { get; set; }

        public byte? NumberOfSatellites { get; set; }

        public byte? HDOP { get; set; }
    }
}
