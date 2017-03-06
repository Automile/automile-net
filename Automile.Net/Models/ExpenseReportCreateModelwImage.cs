using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automile.Net
{
    public class ExpenseReportCreateModelwImage
    {
        public int? VehicleId { get; set; }
        public int? ContactId { get; set; }
        public int? TripId { get; set; }
        public DateTime ExpenseReportDateUtc { get; set; }

        public List<ExpenseReportRowCreateModelwImage> ExpenseReportRows { get; set; }
    }
}
