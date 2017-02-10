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
        /// Get details about a specific relationship between the company and the contact
        /// </summary>
        /// <param name="fleetContactId"></param>
        /// <returns>The detailed model for the relationship</returns>
        public CompanyContactDetailModel GetFleetContactById(int fleetContactId)
        {
            var response = client.GetAsync($"/v1/resourceowner/companycontact/{fleetContactId}").Result;
            response.EnsureSuccessStatusCodeWithProperExceptionMessage();
            return JsonConvert.DeserializeObject<CompanyContactDetailModel>(response.Content.ReadAsStringAsync().Result);
        }

        /// <summary>
        /// Get all relationships between fleets and contacts
        /// </summary>
        /// <returns>The detailed model for the relationship</returns>
        public IEnumerable<CompanyContactDetailModel> GetFleetContacts()
        {
            var response = client.GetAsync("/v1/resourceowner/companycontact").Result;
            response.EnsureSuccessStatusCodeWithProperExceptionMessage();
            return JsonConvert.DeserializeObject<List<CompanyContactDetailModel>>(response.Content.ReadAsStringAsync().Result);
        }

        /// <summary>
        /// Get's all relationsships between a specific fleet and it's contacts
        /// </summary>
        /// <param name="fleetId"></param>
        /// <returns></returns>
        public IEnumerable<CompanyContactDetailModel> GetFleetContactsByFleetId(int fleetId)
        {
            var response = client.GetAsync($"/v1/resourceowner/companycontact?companyId={fleetId}").Result;
            response.EnsureSuccessStatusCodeWithProperExceptionMessage();
            return JsonConvert.DeserializeObject<List<CompanyContactDetailModel>>(response.Content.ReadAsStringAsync().Result);
        }

        /// <summary>
        /// Creates a relationship between a fleet and a contact and returns the newly created relationship
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public CompanyContactDetailModel CreateFleetContact(CompanyContactCreateModel model)
        {
            string stringPayload = JsonConvert.SerializeObject(model);
            var content = new StringContent(stringPayload, Encoding.UTF8, "application/json");
            var response = client.PostAsync($"/v1/resourceowner/companycontact", content).Result;
            response.EnsureSuccessStatusCodeWithProperExceptionMessage();
            var urlToCreatedFleetContact = response.Headers.GetValues("Location").First();
            var fleetContactModel = client.GetAsync(urlToCreatedFleetContact).Result;
            fleetContactModel.EnsureSuccessStatusCodeWithProperExceptionMessage();
            return JsonConvert.DeserializeObject<CompanyContactDetailModel>(fleetContactModel.Content.ReadAsStringAsync().Result);
        }

        /// <summary>
        /// Edit a relationship between a fleet and a contact
        /// </summary>
        /// <param name="vehicleGeofenceId"></param>
        /// <param name="model"></param>
        public void EditFleetContact(int fleetContactId, CompanyContactEditModel model)
        {
            string stringPayload = JsonConvert.SerializeObject(model);
            var content = new StringContent(stringPayload, Encoding.UTF8, "application/json");
            var response = client.PutAsync($"/v1/resourceowner/companycontact/{fleetContactId}", content).Result;
            response.EnsureSuccessStatusCodeWithProperExceptionMessage();
        }

        /// <summary>
        /// Delete a relationship between a fleet and a contact
        /// </summary>
        /// <param name="vehicleGeofenceId"></param>
        public void DeleteFleetContact(int fleetContactId)
        {
            var response = client.DeleteAsync($"/v1/resourceowner/companycontact/{fleetContactId}").Result;
            response.EnsureSuccessStatusCodeWithProperExceptionMessage();
        }
    }
}
