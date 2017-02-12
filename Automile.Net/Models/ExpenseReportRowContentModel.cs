

namespace Automile.Net
{
    public class ExpenseReportRowContentModel
    {
        public int ExpenseReportRowContentId { get; set; }
        public int ExpenseReportRowId { get; set; }
        public ApiContentType ContentType { get; set; }
        public string ContentFileName { get; set; }
    }
}