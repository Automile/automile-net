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
        /// Get all devices (earlier called IMEIConfigs)
        /// </summary>
        /// <returns></returns>
        public IEnumerable<IMEIConfigModel> GetDevices()
        {
            var response = client.GetAsync("/v1/resourceowner/imeiconfigs").Result;
            response.EnsureSuccessStatusCode();
            return JsonConvert.DeserializeObject<List<IMEIConfigModel>>(response.Content.ReadAsStringAsync().Result);
        }

        /// <summary>
        /// Get details for the device
        /// </summary>
        /// <param name="deviceId"></param>
        /// <returns></returns>
        public IMEIConfigDetailModel GetDeviceById(int deviceId)
        {
            var response = client.GetAsync($"/v1/resourceowner/imeiconfigs/{deviceId}").Result;
            response.EnsureSuccessStatusCode();
            return JsonConvert.DeserializeObject<IMEIConfigDetailModel>(response.Content.ReadAsStringAsync().Result);
        }

        /// <summary>
        /// Registers a new device and associates it with a vehicle
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public IMEIConfigDetailModel CreateDevice(IMEIConfigCreateModel model)
        {
            string stringPayload = JsonConvert.SerializeObject(model);
            var content = new StringContent(stringPayload, Encoding.UTF8, "application/json");
            var response = client.PostAsync("/v1/resourceowner/imeiconfigs", content).Result;
            response.EnsureSuccessStatusCode();
            var urlToCreatedDevice = response.Headers.GetValues("Location").First();
            var deviceModel = client.GetAsync(urlToCreatedDevice).Result;
            deviceModel.EnsureSuccessStatusCode();
            return JsonConvert.DeserializeObject<IMEIConfigDetailModel>(deviceModel.Content.ReadAsStringAsync().Result);
        }

        /// <summary>
        /// Edit the device
        /// </summary>
        /// <param name="deviceId"></param>
        /// <param name="model"></param>
        public void EditDevice(int deviceId, IMEIConfigEditModel model)
        {
            string stringPayload = JsonConvert.SerializeObject(model);
            var content = new StringContent(stringPayload, Encoding.UTF8, "application/json");
            var response = client.PutAsync($"/v1/resourceowner/imeiconfigs/{deviceId}", content).Result;
            response.EnsureSuccessStatusCode();
         }

        /// <summary>
        /// Deletes the device
        /// </summary>
        /// <param name="deviceId"></param>
        public void DeleteDevice(int deviceId)
        {
            var response = client.DeleteAsync($"/v1/resourceowner/imeiconfigs/{deviceId}").Result;
            response.EnsureSuccessStatusCode();
        }

    }
}
