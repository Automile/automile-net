using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automile.Net
{
    public partial class AutomileClient
    {
        /// <summary>
        /// The task message details are returned
        /// </summary>
        /// <returns></returns>
        public TaskMessageModel GetByTaskMessageId(int taskMessageId)
        {
            var response = client.GetAsync($"/v1/resourceowner/taskmessage/{taskMessageId}").Result;
            response.EnsureSuccessStatusCodeWithProperExceptionMessage();
            return JsonConvert.DeserializeObject<TaskMessageModel>(response.Content.ReadAsStringAsync().Result);
        }

    }
}
