using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automile.Net
{
    public partial class AutomileClient
    {
        /// <summary>
        /// Get's all contacts (drivers) the user is authorized to
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Contact2Model> GetContacts()
        {
            var response = client.GetAsync("/v1/resourceowner/contacts2").Result;
            response.EnsureSuccessStatusCodeWithProperExceptionMessage();
            return JsonConvert.DeserializeObject<List<Contact2Model>>(response.Content.ReadAsStringAsync().Result);
        }

        /// <summary>
        /// Get the details about a specific contact (driver)
        /// </summary>
        /// <param name="contactId"></param>
        /// <returns></returns>
        public Contact2DetailModel GetContactById(int contactId)
        {
            var response = client.GetAsync($"/v1/resourceowner/contacts2/{contactId}").Result;
            response.EnsureSuccessStatusCodeWithProperExceptionMessage();
            return JsonConvert.DeserializeObject<Contact2DetailModel>(response.Content.ReadAsStringAsync().Result);
        }

        /// <summary>
        /// Get the details about you (driver)
        /// </summary>
        /// <param name="contactId"></param>
        /// <returns></returns>
        public Contact2DetailModel GetMe()
        {
            var response = client.GetAsync("/v1/resourceowner/contacts2/me").Result;
            response.EnsureSuccessStatusCodeWithProperExceptionMessage();
            return JsonConvert.DeserializeObject<Contact2DetailModel>(response.Content.ReadAsStringAsync().Result);
        }

    }
}
