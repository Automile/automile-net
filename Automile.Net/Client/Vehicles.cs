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
        /// Get's all vehicles the user is authorized to
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Vehicle2Model> GetVehicles()
        {
            var response = client.GetAsync("/v1/resourceowner/vehicles2").Result;
            response.EnsureSuccessStatusCode();
            return JsonConvert.DeserializeObject<List<Vehicle2Model>>(response.Content.ReadAsStringAsync().Result);
        }

        /// <summary>
        /// Get details about a specific vehicle
        /// </summary>
        /// <param name="vehicleId"></param>
        /// <returns>The detailed model for the vehicle</returns>
        public Vehicle2DetailModel GetVehicleById(int vehicleId)
        {
            var response = client.GetAsync($"/v1/resourceowner/vehicles2/{vehicleId}").Result;
            response.EnsureSuccessStatusCode();
            return JsonConvert.DeserializeObject<Vehicle2DetailModel>(response.Content.ReadAsStringAsync().Result);
        }

        /// <summary>
        ///  Get position and status of all vehicles that the user has access to
        /// </summary>
        /// <returns>A list of status models for each vehicle</returns>
        public IEnumerable<VehicleStatusModel> GetStatusForVehicles()
        {
            var response = client.GetAsync($"/v1/resourceowner/vehicles2/status").Result;
            response.EnsureSuccessStatusCode();
            return JsonConvert.DeserializeObject<List<VehicleStatusModel>>(response.Content.ReadAsStringAsync().Result);
        }

        /// <summary>
        /// Edit a vehicle
        /// </summary>
        /// <param name="vehicleId"></param>
        /// <param name="model"></param>
        public void EditVehicle(int vehicleId, Vehicle2EditModel model)
        {
            string stringPayload = JsonConvert.SerializeObject(model);
            var content = new StringContent(stringPayload, Encoding.UTF8, "application/json");
            var response = client.PutAsync($"/v1/resourceowner/vehicles2/{vehicleId}", content).Result;
            response.EnsureSuccessStatusCode();
        }

        /// <summary>
        /// Check-in to a vehicle
        /// </summary>
        /// <param name="model"></param>
        public void CheckInToVehicle(VehicleCheckInModel model)
        {
            string stringPayload = JsonConvert.SerializeObject(model);
            var content = new StringContent(stringPayload, Encoding.UTF8, "application/json");
            var response = client.PutAsync($"/v1/resourceowner/vehicles2/checkin", content).Result;
            response.EnsureSuccessStatusCode();
        }

        /// <summary>
        /// Check-out from a vehicle
        /// </summary>
        public void CheckOut()
        {
            var response = client.PostAsync($"/v1/resourceowner/vehicles2/checkout", null).Result;
            response.EnsureSuccessStatusCode();
        }

        /// <summary>
        /// Delete a vehicle, this requires any given device that has been associated to the vehicle to first be moved.
        /// </summary>
        /// <param name="vehicleId"></param>
        public void DeleteVehicle(int vehicleId)
        {
            var response = client.DeleteAsync($"/v1/resourceowner/vehicles2/{vehicleId}").Result;
            response.EnsureSuccessStatusCode();
        }

         /// <summary>
         /// Creates a new vehicle and returns the model for the newly created vehicle
         /// </summary>
         /// <param name="model"></param>
         /// <returns></returns>
        public VehicleDetailModel CreateVehicle(Vehicle2CreateModel model)
        {
            string stringPayload = JsonConvert.SerializeObject(model);
            var content = new StringContent(stringPayload, Encoding.UTF8, "application/json");
            var response = client.PostAsync($"/v1/resourceowner/vehicles2", content).Result;
            response.EnsureSuccessStatusCode();
            var urlToCreatedVehicle = response.Headers.GetValues("Location").First();
            var vehicleModelResponse = client.GetAsync(urlToCreatedVehicle).Result;
            vehicleModelResponse.EnsureSuccessStatusCode();
            return JsonConvert.DeserializeObject<VehicleDetailModel>(vehicleModelResponse.Content.ReadAsStringAsync().Result);
        }
    }
}
