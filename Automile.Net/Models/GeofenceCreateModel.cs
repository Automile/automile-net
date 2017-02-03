using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Automile.Net
{
    public class GeofenceCreateModel
    {
        [Required(ErrorMessage = "You need to supply a geofence name")]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required(ErrorMessage = "You need to supply a vehicle")]
        public int VehicleId { get; set; }
        public GeofencePolygon GeofencePolygon { get; set; }
        public ApiGeofenceType? GeofenceType { get; set; }
        public List<GeofenceScheduleAddModel> Schedules { get; set; }
    }

    public class GeofenceScheduleAddModel
    {
        public bool Monday { get; set; }
        public bool Tuesday { get; set; }
        public bool Wednesday { get; set; }
        public bool Thursday { get; set; }
        public bool Friday { get; set; }
        public bool Saturday { get; set; }
        public bool Sunday { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
    }
}
