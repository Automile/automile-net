using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automile.Net
{
    public class GeofenceReportModel
    {
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }

        public int? VehicleId { get; set; }

        public int? GeofenceId { get; set; }

        public List<GeofenceRecordReportModel> Result { get; set; }
    }
    public class GeofenceRecordReportModel
    {
        public int TripId { get; set; }

        public int GeofenceId { get; set; }

        public string GeofenceName { get; set; }

        public GeofenceType GeofenceType { get; set; }

        public bool IsInside { get; set; }

        public DateTime EventDateTime { get; set; }

        public VehicleTinyModel VehicleTinyModel { get; set; }

    }
}
