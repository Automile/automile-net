using System;
using System.Collections.Generic;

namespace Automile.Net.ExpenseReports
{
    public class ExpenseReportRowModel
    {
        public int ExpenseReportRowId { get; set; }
        public int ExpenseReportId { get; set; }
        public decimal? AmountInCurrency { get; set; }
        public decimal? VATInCurrency { get; set; }
        public string ISO4217CurrencyCode { get; set; }
        public string Notes { get; set; }
        public DateTime ExpenseReportRowDateUtc { get; set; }
        public List<ExpenseReportRowContentModel> ExpenseReportRowContent { get; set; }
        public ApiCategoryType Category { get; set; }
    }
}