using System;

namespace Automile.Net
{
    public class EmailExpenseReportsModel
    {
        public int VehicleId { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public string ToEmail { get; set; }
        public string ISO639LanguageCode { get; set; }

    }
}