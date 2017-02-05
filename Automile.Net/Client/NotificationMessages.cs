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
        /// Get's all notification messages sent in the past
        /// </summary>
        /// <returns></returns>
        public IEnumerable<TriggerMessageHistoryModel> GetNotificationMessages()
        {
            var response = client.GetAsync("/v1/resourceowner/triggermessageshistory").Result;
            response.EnsureSuccessStatusCodeWithProperExceptionMessage();
            return JsonConvert.DeserializeObject<List<TriggerMessageHistoryModel>>(response.Content.ReadAsStringAsync().Result);
        }

        /// <summary>
        /// Get notification messages sent in the past for a specific notification
        /// </summary>
        /// <param name="fleetId"></param>
        /// <returns></returns>
        public IEnumerable<TriggerMessageHistoryModel> GetNotificationMessagesByNotificationId(int notificationId)
        {
            var response = client.GetAsync($"/v1/resourceowner/triggermessageshistory/{notificationId}").Result;
            response.EnsureSuccessStatusCodeWithProperExceptionMessage();
            return JsonConvert.DeserializeObject<List<TriggerMessageHistoryModel>>(response.Content.ReadAsStringAsync().Result);
        }
    }

}
