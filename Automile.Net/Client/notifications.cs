using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Automile.Net
{
    public partial class AutomileClient
    {
        /// <summary>
        /// Get's all notifications (earlier called triggers)
        /// </summary>
        /// <returns></returns>
        public IEnumerable<TriggerModel> GetNotifications()
        {
            var response = client.GetAsync($"/v1/resourceowner/triggers").Result;
            response.EnsureSuccessStatusCode();
            return JsonConvert.DeserializeObject<List<TriggerModel>>(response.Content.ReadAsStringAsync().Result);
        }

        /// <summary>
        /// Get the detail for a notification (earlier called triggers)
        /// </summary>
        /// <param name="notificationId"></param>
        /// <returns></returns>
        public TriggerDetailModel GetNotificationById(int notificationId)
        {
            var response = client.GetAsync($"/v1/resourceowner/triggers/{notificationId}").Result;
            response.EnsureSuccessStatusCode();
            return JsonConvert.DeserializeObject<TriggerDetailModel>(response.Content.ReadAsStringAsync().Result);
        }

        /// <summary>
        /// Creates a new notification
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public TriggerModel CreateNotification(TriggerCreateModel model)
        {
            string stringPayload = JsonConvert.SerializeObject(model);
            var content = new StringContent(stringPayload, Encoding.UTF8, "application/json");
            var response = client.PostAsync("/v1/resourceowner/triggers", content).Result;
            response.EnsureSuccessStatusCode();
            var urlToCreatedNotification = response.Headers.GetValues("Location").First();
            var notificationModelResponse = client.GetAsync(urlToCreatedNotification).Result;
            notificationModelResponse.EnsureSuccessStatusCode();
            return JsonConvert.DeserializeObject<TriggerModel>(notificationModelResponse.Content.ReadAsStringAsync().Result);
        }

        /// <summary>
        /// Deletes the notification
        /// </summary>
        /// <param name="geofenceId"></param>
        public void DeleteNotification(int notificationId)
        {
            var response = client.DeleteAsync($"/v1/resourceowner/triggers/{notificationId}").Result;
            response.EnsureSuccessStatusCode();
        }

        /// <summary>
        /// Edit notification
        /// </summary>
        /// <param name="notificationId"></param>
        /// <param name="model"></param>
        public void EditNotification(int notificationId, TriggerEditModel model)
        {
            string stringPayload = JsonConvert.SerializeObject(model);
            var content = new StringContent(stringPayload, Encoding.UTF8, "application/json");
            var response = client.PutAsync($"/v1/resourceowner/triggers/{notificationId}", content).Result;
            response.EnsureSuccessStatusCode();
        }

        /// <summary>
        /// Mutes a notification
        /// </summary>
        /// <param name="notificationId"></param>
        /// <param name="secondsFromNow"></param>
        public void MuteNotification(int notificationId, int secondsFromNow)
        {
            TriggerEditMutedUntilModel model = new TriggerEditMutedUntilModel();
            model.SecondsFromNow = secondsFromNow;
            string stringPayload = JsonConvert.SerializeObject(model);
            var content = new StringContent(stringPayload, Encoding.UTF8, "application/json");
            var response = client.PutAsync($"/v1/resourceowner/triggers/mute/{notificationId}", content).Result;
            response.EnsureSuccessStatusCode();
        }

        /// <summary>
        /// Unmutes a notification
        /// </summary>
        /// <param name="notificationId"></param>
        /// <param name="secondsFromNow"></param>
        public void UnmuteNotification(int notificationId)
        {
            var response = client.PutAsync($"/v1/resourceowner/triggers/unmute/{notificationId}", null).Result;
            response.EnsureSuccessStatusCode();
        }

    }
}
