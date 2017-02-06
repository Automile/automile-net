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
        /// Get details about a specific relationship between the geofence and the vehicle
        /// </summary>
        /// <param name="vehicleGeofenceId"></param>
        /// <returns>The detailed model for the relationship</returns>
        public VehicleGeofenceModel GetVehicleGeofenceById(int vehicleGeofenceId)
        {
            var response = client.GetAsync($"/v1/resourceowner/vehiclegeofence/{vehicleGeofenceId}").Result;
            response.EnsureSuccessStatusCodeWithProperExceptionMessage();
            return JsonConvert.DeserializeObject<VehicleGeofenceModel>(response.Content.ReadAsStringAsync().Result);
        }

        /// <summary>
        /// Get's all relationsships betwen geofences and vehicles
        /// </summary>
        /// <param name="geofenceId"></param>
        /// <returns></returns>
        public IEnumerable<VehicleGeofenceModel> GetVehicleGeofencesByGeofenceId(int geofenceId)
        {
            var response = client.GetAsync($"/v1/resourceowner/vehiclegeofence?geofenceId={geofenceId}").Result;
            response.EnsureSuccessStatusCodeWithProperExceptionMessage();
            return JsonConvert.DeserializeObject<List<VehicleGeofenceModel>>(response.Content.ReadAsStringAsync().Result);
        }

        /// <summary>
        /// Creates a relationship between a vehicle and a geofence and returns the newly created relationship
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public VehicleGeofenceModel CreateVehicleGeofence(VehicleGeofenceCreateModel model)
        {
            string stringPayload = JsonConvert.SerializeObject(model);
            var content = new StringContent(stringPayload, Encoding.UTF8, "application/json");
            var response = client.PostAsync($"/v1/resourceowner/vehiclegeofence", content).Result;
            response.EnsureSuccessStatusCodeWithProperExceptionMessage();
            var urlToCreatedVehicleGeofence = response.Headers.GetValues("Location").First();
            var vehicleGeofenceModelResponse = client.GetAsync(urlToCreatedVehicleGeofence).Result;
            vehicleGeofenceModelResponse.EnsureSuccessStatusCodeWithProperExceptionMessage();
            return JsonConvert.DeserializeObject<VehicleGeofenceModel>(vehicleGeofenceModelResponse.Content.ReadAsStringAsync().Result);
        }


        /// <summary>
        /// Edit a relationship between a vehicle and a geofence
        /// </summary>
        /// <param name="vehicleGeofenceId"></param>
        /// <param name="model"></param>
        public void EditVehicleGeofence(int vehicleGeofenceId, VehicleGeofenceEditModel model)
        {
            string stringPayload = JsonConvert.SerializeObject(model);
            var content = new StringContent(stringPayload, Encoding.UTF8, "application/json");
            var response = client.PutAsync($"/v1/resourceowner/vehiclegeofence/{vehicleGeofenceId}", content).Result;
            response.EnsureSuccessStatusCodeWithProperExceptionMessage();
        }

        /// <summary>
        /// Delete a vehicle, this requires any given device that has been associated to the vehicle to first be moved.
        /// </summary>
        /// <param name="vehicleGeofenceId"></param>
        public void DeleteVehicleGeofence(int vehicleGeofenceId)
        {
            var response = client.DeleteAsync($"/v1/resourceowner/vehiclegeofence/{vehicleGeofenceId}").Result;
            response.EnsureSuccessStatusCodeWithProperExceptionMessage();
        }
    }
}
