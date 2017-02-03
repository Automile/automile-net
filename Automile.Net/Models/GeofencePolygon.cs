using System.Collections.Generic;

namespace Automile.Net
{
    public class GeofencePolygon
    {
        public GeofencePolygon(IEnumerable<GeographicPosition> coordinates = null)
        {
            if (coordinates != null)
                Coordinates = coordinates;
        }

        public IEnumerable<GeographicPosition> Coordinates { get; set; }
        public class GeographicPosition
        {
            public double Latitude { get; set; }
            public double Longitude { get; set; }
        }
    }
}
