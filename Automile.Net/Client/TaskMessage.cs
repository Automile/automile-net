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
        /// The task message details are returned
        /// </summary>
        /// /// <param name="taskMessageId"></param>
        /// <returns></returns>
        public TaskMessageModel GetByTaskMessageId(int taskMessageId)
        {
            var response = client.GetAsync($"/v1/resourceowner/taskmessage/{taskMessageId}").Result;
            response.EnsureSuccessStatusCodeWithProperExceptionMessage();
            return JsonConvert.DeserializeObject<TaskMessageModel>(response.Content.ReadAsStringAsync().Result);
        }

        /// <summary>
        /// Create a task Message
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public TaskMessageCreateModel CreateTaskMessage(TaskMessageCreateModel model)
        {

            string stringPayload = JsonConvert.SerializeObject(model);
            var content = new StringContent(stringPayload, Encoding.UTF8, "application/json");
            var response = client.PostAsync("/v1/resourceowner/taskmessage", content).Result;
            response.EnsureSuccessStatusCodeWithProperExceptionMessage();
            var urlToCreatedTaskMessage = response.Headers.GetValues("Location").First();
            var taskmessageModelResult = client.GetAsync(urlToCreatedTaskMessage).Result;
            taskmessageModelResult.EnsureSuccessStatusCodeWithProperExceptionMessage();
            return JsonConvert.DeserializeObject<TaskMessageCreateModel>(taskmessageModelResult.Content.ReadAsStringAsync().Result);
        }
        /// <summary>
        /// Edit the Task Message
        /// </summary>
        /// <param name="taskMessageId"></param>
        /// <param name="taskMessageModel"></param>
        public void EditTaskMessage(int taskMessageId,TaskMessageEditModel model)
        {
            string stringPayload = JsonConvert.SerializeObject(model);
            var content = new StringContent(stringPayload, Encoding.UTF8, "application/json");
            var response = client.PutAsync($"/v1/resourceowner/taskmessage/{taskMessageId}", content).Result;
            response.EnsureSuccessStatusCodeWithProperExceptionMessage();
        }

    }
}
