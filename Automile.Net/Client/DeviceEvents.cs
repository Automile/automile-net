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
        /// Get all device events (earlier called IMEIEvents)
        /// </summary>
        /// <returns></returns>
        public IEnumerable<IMEIEventModel> GetDeviceEvents()
        {
            var response = client.GetAsync("/v1/resourceowner/imeievents").Result;
            response.EnsureSuccessStatusCodeWithProperExceptionMessage();
            return JsonConvert.DeserializeObject<List<IMEIEventModel>>(response.Content.ReadAsStringAsync().Result);
        }

        /// <summary>
        /// Get a specific MIL (Mileage Indicator Lamp) event
        /// </summary>
        /// <param name="deviceId"></param>
        /// <returns></returns>
        public IMEIEventMILModel GetDeviceEventMILById(int deviceEventId)
        {
            var response = client.GetAsync($"/v1/resourceowner/imeievents/mil/{deviceEventId}").Result;
            response.EnsureSuccessStatusCodeWithProperExceptionMessage();
            return JsonConvert.DeserializeObject<IMEIEventMILModel>(response.Content.ReadAsStringAsync().Result);
        }

        /// <summary>
        /// Get a specific DTC (Diagnostic Trouble Code) event
        /// </summary>
        /// <param name="deviceId"></param>
        /// <returns></returns>
        public IMEIEventDTCModel GetDeviceEventDTCById(int deviceEventId)
        {
            var response = client.GetAsync($"/v1/resourceowner/imeievents/dtc/{deviceEventId}").Result;
            response.EnsureSuccessStatusCodeWithProperExceptionMessage();
            return JsonConvert.DeserializeObject<IMEIEventDTCModel>(response.Content.ReadAsStringAsync().Result);
        }

        /// <summary>
        /// Get a specific status event
        /// </summary>
        /// <param name="deviceId"></param>
        /// <returns></returns>
        public IMEIEventStatusModel GetDeviceEventStatusById(int deviceEventId)
        {
            var response = client.GetAsync($"/v1/resourceowner/imeievents/status/{deviceEventId}").Result;
            response.EnsureSuccessStatusCodeWithProperExceptionMessage();
            return JsonConvert.DeserializeObject<IMEIEventStatusModel>(response.Content.ReadAsStringAsync().Result);
        }
    }
}
