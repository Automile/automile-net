using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Automile.Net.ExpenseReports
{
    public class EmailExpenseReportModel
    {
        public int ExpenseReportId { get; set; }
        public string ToEmail { get; set; }
        public string ISO639LanguageCode { get; set; }
    }
}