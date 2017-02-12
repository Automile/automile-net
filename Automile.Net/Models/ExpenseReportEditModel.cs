using System;

namespace Automile.Net
{
    public class ExpenseReportEditModel
    {
        public int? VehicleId { get; set; }
        public int? ContactId { get; set; }
        public int? TripId { get; set; }
        public DateTime ExpenseReportDateUtc { get; set; }
    }
}