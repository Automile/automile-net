using System;
using System.Collections.Generic;

namespace Automile.Net
{
    public class ExpenseReportCreateModel
    {
        public int? VehicleId { get; set; }
        public int? ContactId { get; set; }
        public int? TripId { get; set; }
        public DateTime ExpenseReportDateUtc { get; set; }

        public List<ExpenseReportRowCreateModel> ExpenseReportRows { get; set; }
    }
}