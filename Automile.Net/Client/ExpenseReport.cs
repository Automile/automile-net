using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public IEnumerable<ExpenseReportModel> GetExpenseReports()
        {
            var response = client.GetAsync("/v1/resourceowner/expensereport").Result;
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

        ///// <summary>
        ///// Create a task
        ///// </summary>
        ///// <param name="model"></param>
        ///// <returns></returns>
        //public TaskDetailModel Create(TaskCreateModel model)
        //{
        //    if (model.ToContactId.HasValue == false)
        //        throw new ArgumentException("You need to enter to which contact / driver the message should be sent to");

        //    string stringPayload = JsonConvert.SerializeObject(model);
        //    var content = new StringContent(stringPayload, Encoding.UTF8, "application/json");
        //    var response = client.PostAsync("/v1/resourceowner/task", content).Result;
        //    response.EnsureSuccessStatusCodeWithProperExceptionMessage();
        //    var urlToCreatedTask = response.Headers.GetValues("Location").First();
        //    var taskModelResult = client.GetAsync(urlToCreatedTask).Result;
        //    taskModelResult.EnsureSuccessStatusCodeWithProperExceptionMessage();
        //    return JsonConvert.DeserializeObject<TaskDetailModel>(taskModelResult.Content.ReadAsStringAsync().Result);
        //}

        ///// <summary>
        ///// Edit task message
        ///// </summary>
        ///// <param name="taskId"></param>
        ///// <param name="model"></param>
        //public void EditTask(int taskId, TaskMessageEditModel model)
        //{
        //    string stringPayload = JsonConvert.SerializeObject(model);
        //    var content = new StringContent(stringPayload, Encoding.UTF8, "application/json");
        //    var response = client.PutAsync($"/v1/resourceowner/task/{taskId}", content).Result;
        //    response.EnsureSuccessStatusCodeWithProperExceptionMessage();
        //}

    }
}
