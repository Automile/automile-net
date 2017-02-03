using System;
using System.Collections.Generic;

namespace Automile.Net.ExpenseReports
{
    public class ExpenseReportModel
    {
        public int ExpenseReportId { get; set; }
        public int? ContactId { get; set; }
        public int? VehicleId { get; set; }
        public int? TripId { get; set; }
        public DateTime ExpenseReportDateUtc { get; set; }
        public List<ExpenseReportRowModel> ExpenseReportRows { get; set; }
    }
}