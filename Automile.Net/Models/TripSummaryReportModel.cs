using System;

namespace Automile.Net
{
    public class TripSummaryReportModel
    {
        public int ReportStartPeriod { get; set; }
        public int ReportEndPeriod { get; set; }
        public int? VehicleId { get; set; }
        public TripType TripType { get; set; }
        public decimal? DistanceInKilometers { get; set; }
        public int? TravelTimeInMinutes { get; set; }
        public decimal? FuelInLiters { get; set; }        
    }
}
