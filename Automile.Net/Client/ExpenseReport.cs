using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Automile.Net
{
    public partial class AutomileClient
    {
        /// <summary>
        /// Get all expense reports
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ExpenseReportModel> GetExpenseReports(int? tripId = null, int? vehicleId = null)
        {
            var response = client.GetAsync($"/v1/resourceowner/expensereport?tripId={tripId}&vehicleId={vehicleId}").Result;
            response.EnsureSuccessStatusCodeWithProperExceptionMessage();
            return JsonConvert.DeserializeObject<List<ExpenseReportModel>>(response.Content.ReadAsStringAsync().Result);
        }

        /// <summary>
        /// Get the details about a specific expense report
        /// </summary>
        /// <param name="taskId"></param>
        /// <returns></returns>
        public ExpenseReportModel GetExpenseReportById(int expenseReportId)
        {
            var response = client.GetAsync($"/v1/resourceowner/expensereport/{expenseReportId}").Result;
            response.EnsureSuccessStatusCodeWithProperExceptionMessage();
            return JsonConvert.DeserializeObject<ExpenseReportModel>(response.Content.ReadAsStringAsync().Result);
        }

        /// <summary>
        /// Create an expense reports
        /// </summary>
        /// <param name="ExpenseReportCreateModel"></param>
        /// <returns></returns>
        public ExpenseReportModel CreateExpenseReport(ExpenseReportCreateModel model)
        {

            string stringPayload = JsonConvert.SerializeObject(model);
            var content = new StringContent(stringPayload, Encoding.UTF8, "application/json");
            var response = client.PostAsync("/v1/resourceowner/expensereport", content).Result;
            response.EnsureSuccessStatusCodeWithProperExceptionMessage();
            var urlToCreatedExpenseReport = response.Headers.GetValues("Location").First();
            var expensereportModelResult = client.GetAsync(urlToCreatedExpenseReport).Result;
            expensereportModelResult.EnsureSuccessStatusCodeWithProperExceptionMessage();
            return JsonConvert.DeserializeObject<ExpenseReportModel>(expensereportModelResult.Content.ReadAsStringAsync().Result);
        }

        /// <summary>
        /// Updates the given expense report
        /// </summary>
        /// <response code="200">The expense report was saved</response>
        /// <response code="500">Internal server error</response>
        /// <response code="400">Bad request, could occur for a number of cases, see returned message</response>
        /// <response code="403">Request is forbidden, could occur for a number of reasons, see returned message</response>
        /// <response code="404">Not found, the expense report you tried to update can't be found</response>
        /// <param name="expenseReportId">The expense report id</param>
        /// <param name="model">The new expense report model</param>
        /// <returns></returns>
        /// <remarks>This will update the given expense report id with a new model.</remarks>
        public void EditExpenseReport(int expenseReportId, ExpenseReportEditModel model, ExpenseReportRowEditModel modelRow, ExpenseReportRowContentCreateModel modelRowContent )
        {
            string stringPayload = JsonConvert.SerializeObject(model);
            var content = new StringContent(stringPayload, Encoding.UTF8, "application/json");
            var response = client.PutAsync($"/v1/resourceowner/expensereport/{expenseReportId}", content).Result;
            response.EnsureSuccessStatusCodeWithProperExceptionMessage();

            string stringPayloadRow = JsonConvert.SerializeObject(modelRow);
            var contentRow = new StringContent(stringPayloadRow, Encoding.UTF8, "application/json");
            var responseRow = client.PutAsync($"/v1/resourceowner/expensereport/{expenseReportId}", contentRow).Result;
            responseRow.EnsureSuccessStatusCodeWithProperExceptionMessage();

            string stringPayloadRowContent = JsonConvert.SerializeObject(modelRowContent);
            var contentRowCont = new StringContent(stringPayloadRowContent, Encoding.UTF8, "application/json");
            var responseRowContent = client.PutAsync($"/v1/resourceowner/expensereport/{expenseReportId}", contentRowCont).Result;
            responseRowContent.EnsureSuccessStatusCodeWithProperExceptionMessage();

        }

        /// <summary>
        /// Export an expense report in pdf format
        /// </summary>
        /// /// <param name="EmailExpenseReportModel"></param>
        /// <returns>The expense report attached in an email</returns>
        public HttpStatusCode EmailExpenseReport(int ExpenseReportId,EmailExpenseReportModel model)
        {
            string stringPayload = JsonConvert.SerializeObject(model);
            var content = new StringContent(stringPayload, Encoding.UTF8, "application/json");
            var response = client.PostAsync($"/v1/resourceowner/expensereport/export/{ExpenseReportId}", content).Result;
            response.EnsureSuccessStatusCodeWithProperExceptionMessage();
            return response.StatusCode;
        }

        /// <summary>
        /// Export an expense reports in pdf format
        /// </summary>
        /// /// <param name="EmailExpenseReportsModel"></param>
        /// <returns>The expense report attached in an email</returns>
        public HttpStatusCode EmailExpenseReports(EmailExpenseReportsModel model)
        {
            string stringPayload = JsonConvert.SerializeObject(model);
            var content = new StringContent(stringPayload, Encoding.UTF8, "application/json");
            var response = client.PostAsync($"/v1/resourceowner/expensereport/export", content).Result;
            response.EnsureSuccessStatusCodeWithProperExceptionMessage();
            return response.StatusCode;
        }

        /// <summary>
        /// Deletes the Expense Report
        /// </summary>
        /// <param name="expenseReportId"></param>
        public HttpStatusCode DeleteExpenseReport(int expenseReportId)
        {
            var response = client.DeleteAsync($"/v1/resourceowner/expensereport/{expenseReportId}").Result;
            response.EnsureSuccessStatusCodeWithProperExceptionMessage();
            return response.StatusCode;
        }

    }
}
