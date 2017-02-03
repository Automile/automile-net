

namespace Automile.Net.ExpenseReports
{
    public class ExpenseReportRowContentModel
    {
        public int ExpenseReportRowContentId { get; set; }
        public int ExpenseReportRowId { get; set; }
        public ApiContentType ContentType { get; set; }
        public string ContentFileName { get; set; }
    }
}