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
        /// Get a number of health indicators about a specific vehicle
        /// </summary>
        /// <param name="vehicleId"></param>
        /// <returns>The detailed model for the vehicle</returns>
        public VehicleHealth GetVehicleHealthByVehicleId(int vehicleId)
        {
            var response = client.GetAsync($"/v1/resourceowner/vehiclehealth/{vehicleId}").Result;
            response.EnsureSuccessStatusCodeWithProperExceptionMessage();
            return JsonConvert.DeserializeObject<VehicleHealth>(response.Content.ReadAsStringAsync().Result);
        }

        /// <summary>
        /// Get a number of health indicators about a specific vehicle over a specific period
        /// </summary>
        /// <param name="vehicleId"></param>
        /// <param name="dateperiod"></param>
        /// <returns>The detailed model for the vehicle</returns>
        public VehicleHealth GetVehicleHealthByVehicleId(string dateperiod, int vehicleId)
        {
            var response = client.GetAsync($"/v1/resourceowner/vehiclehealth/{vehicleId}").Result;
            response.EnsureSuccessStatusCodeWithProperExceptionMessage();
            return JsonConvert.DeserializeObject<VehicleHealth>(response.Content.ReadAsStringAsync().Result);
        }

    }
}
