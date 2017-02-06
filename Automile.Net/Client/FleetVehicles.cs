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
        /// Get details about a specific relationship between the company and the vehicle
        /// </summary>
        /// <param name="fleetVehicleId"></param>
        /// <returns>The detailed model for the relationship</returns>
        public CompanyVehicleModel GetFleetVehicleById(int fleetVehicleId)
        {
            var response = client.GetAsync($"/v1/resourceowner/companyvehicle/{fleetVehicleId}").Result;
            response.EnsureSuccessStatusCodeWithProperExceptionMessage();
            return JsonConvert.DeserializeObject<CompanyVehicleModel>(response.Content.ReadAsStringAsync().Result);
        }
        
        /// <summary>
        /// Get all relationships between fleets and vehicles
        /// </summary>
        /// <returns>The detailed model for the relationship</returns>
        public IEnumerable<CompanyVehicleModel> GetFleetVehicles()
        {
            var response = client.GetAsync("/v1/resourceowner/companyvehicle").Result;
            response.EnsureSuccessStatusCodeWithProperExceptionMessage();
            return JsonConvert.DeserializeObject<List<CompanyVehicleModel>>(response.Content.ReadAsStringAsync().Result);
        }

        /// <summary>
        /// Get's all relationsships between a specific fleet and it's vehicles
        /// </summary>
        /// <param name="fleetId"></param>
        /// <returns></returns>
        public IEnumerable<CompanyVehicleModel> GetFleetVehiclesByFleetId(int fleetId)
        {
            var response = client.GetAsync($"/v1/resourceowner/companyvehicle?companyId={fleetId}").Result;
            response.EnsureSuccessStatusCodeWithProperExceptionMessage();
            return JsonConvert.DeserializeObject<List<CompanyVehicleModel>>(response.Content.ReadAsStringAsync().Result);
        }

        /// <summary>
        /// Creates a relationship between a fleet and a vehicle and returns the newly created relationship
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public CompanyVehicleModel CreateFleetVehicle(CompanyVehicleCreateModel model)
        {
            string stringPayload = JsonConvert.SerializeObject(model);
            var content = new StringContent(stringPayload, Encoding.UTF8, "application/json");
            var response = client.PostAsync($"/v1/resourceowner/companyvehicle", content).Result;
            response.EnsureSuccessStatusCodeWithProperExceptionMessage();
            var urlToCreatedFleetVehicle = response.Headers.GetValues("Location").First();
            var fleetVehicleModel = client.GetAsync(urlToCreatedFleetVehicle).Result;
            fleetVehicleModel.EnsureSuccessStatusCodeWithProperExceptionMessage();
            return JsonConvert.DeserializeObject<CompanyVehicleModel>(fleetVehicleModel.Content.ReadAsStringAsync().Result);
        }

        /// <summary>
        /// Edit a relationship between a fleet and a vehicle
        /// </summary>
        /// <param name="vehicleGeofenceId"></param>
        /// <param name="model"></param>
        public void EditFleetVehicle(int fleetVehicleId, CompanyVehicleEditModel model)
        {
            string stringPayload = JsonConvert.SerializeObject(model);
            var content = new StringContent(stringPayload, Encoding.UTF8, "application/json");
            var response = client.PutAsync($"/v1/resourceowner/companyvehicle/{fleetVehicleId}", content).Result;
            response.EnsureSuccessStatusCodeWithProperExceptionMessage();
        }

        /// <summary>
        /// Delete a relationship between a fleet and a vehicle
        /// </summary>
        /// <param name="vehicleGeofenceId"></param>
        public void DeleteFleetVehicle(int fleetVehicleId)
        {
            var response = client.DeleteAsync($"/v1/resourceowner/companyvehicle/{fleetVehicleId}").Result;
            response.EnsureSuccessStatusCodeWithProperExceptionMessage();
        }
    }
}
