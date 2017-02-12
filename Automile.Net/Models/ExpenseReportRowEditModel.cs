using System;
using System.Collections.Generic;


namespace Automile.Net
{
    public class ExpenseReportRowEditModel
    {   
        public decimal? AmountInCurrency { get; set; }
        public decimal? VATInCurrency { get; set; }
        public string ISO4217CurrencyCode { get; set; }
        public string Notes { get; set; }
        public DateTime ExpenseReportRowDateUtc { get; set; }
        public ApiCategoryType Category { get; set; }

        public List<ExpenseReportRowContentUpdateEditModel> ExpenseReportRowContent { get; set; }
    }

    public class ExpenseReportRowContentUpdateEditModel
    {
        public int? ExpenseReportRowContentId { get; set; }
        public int ExpenseReportRowId { get; set; }
        public string Data { get; set; }
        public ApiContentType ContentType { get; set; }
    }
}