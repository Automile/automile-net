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
        /// Get's all fleets the user is authorized to
        /// </summary>
        /// <returns></returns>
        public IEnumerable<CompanyModel> GetFleets()
        {
            var response = client.GetAsync("/v1/resourceowner/companies").Result;
            response.EnsureSuccessStatusCodeWithProperExceptionMessage();
            return JsonConvert.DeserializeObject<List<CompanyModel>>(response.Content.ReadAsStringAsync().Result);
        }

        /// <summary>
        /// Get details about a specific fleet
        /// </summary>
        /// <param name="fleetId"></param>
        /// <returns>The detailed model for the fleet</returns>
        public CompanyDetailModel GetFleetById(int fleetId)
        {
            var response = client.GetAsync($"/v1/resourceowner/companies/{fleetId}").Result;
            response.EnsureSuccessStatusCodeWithProperExceptionMessage();
            return JsonConvert.DeserializeObject<CompanyDetailModel>(response.Content.ReadAsStringAsync().Result);
        }

        /// <summary>
        /// Creates a new fleet and returns the model for the newly created fleet
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public CompanyDetailModel CreateFleet(CompanyCreateModel model)
        {
            string stringPayload = JsonConvert.SerializeObject(model);
            var content = new StringContent(stringPayload, Encoding.UTF8, "application/json");
            var response = client.PostAsync($"/v1/resourceowner/companies", content).Result;
            response.EnsureSuccessStatusCodeWithProperExceptionMessage();
            var urlToCreatedFleet = response.Headers.GetValues("Location").First();
            var fleetModelResponse = client.GetAsync(urlToCreatedFleet).Result;
            fleetModelResponse.EnsureSuccessStatusCodeWithProperExceptionMessage();
            return JsonConvert.DeserializeObject<CompanyDetailModel>(fleetModelResponse.Content.ReadAsStringAsync().Result);
        }

        /// <summary>
        /// Edit a fleet
        /// </summary>
        /// <param name="fleetId"></param>
        /// <param name="model"></param>
        public void EditFleet(int fleetId, CompanyEditModel model)
        {
            string stringPayload = JsonConvert.SerializeObject(model);
            var content = new StringContent(stringPayload, Encoding.UTF8, "application/json");
            var response = client.PutAsync($"/v1/resourceowner/companies/{fleetId}", content).Result;
            response.EnsureSuccessStatusCodeWithProperExceptionMessage();
        }


        /// <summary>
        /// Delete a fleet
        /// </summary>
        /// <param name="vehicleId"></param>
        public void DeleteFleet(int fleetId)
        {
            var response = client.DeleteAsync($"/v1/resourceowner/companies/{fleetId}").Result;
            response.EnsureSuccessStatusCodeWithProperExceptionMessage();
        }

    }

}
