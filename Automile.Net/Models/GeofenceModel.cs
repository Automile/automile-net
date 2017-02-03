using System;
using System.Collections.Generic;


namespace Automile.Net
{
    public class GeofenceModel
    {
        public int GeofenceId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }        
        public GeofencePolygon GeofencePolygon { get; set; }
        public bool IsEditable { get; set; }
        public ApiGeofenceType GeofenceType { get; set; }

        public List<GeofenceScheduleModel> Schedules { get; set; }
    }

    public class GeofenceScheduleModel
    {
        public int GeofenceScheduleId { get; set; }

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
