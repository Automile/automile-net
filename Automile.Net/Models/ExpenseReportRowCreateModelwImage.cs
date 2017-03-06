using System;
using System.Collections.Generic;

namespace Automile.Net
{
    public class ExpenseReportRowCreateModelwImage
    {
        public int ExpenseReportId { get; set; }
        public decimal? AmountInCurrency { get; set; }
        public decimal? VATInCurrency { get; set; }
        public string ISO4217CurrencyCode { get; set; }
        public string Notes { get; set; }
        public ApiCategoryType Category { get; set; }
        public DateTime ExpenseReportRowDateUtc { get; set; }

        public List<ExpenseReportRowContentCreateModelwImage> ExpenseReportRowContent { get; set; }
    }
}