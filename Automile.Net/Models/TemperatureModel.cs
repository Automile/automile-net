using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Automile.Net
{
    public class TemperatureModel
    {
        public Int16 TemperatureInCelsius { get; set; }

        public DateTime RecordTimeStampUtc { get; set; }

        public float? Latitude { get; set; }

        public float? Longitude { get; set; }

        public string VehicleFriendlyName { get; set; }
    }
}
