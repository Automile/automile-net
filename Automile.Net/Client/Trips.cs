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
        /// Get's all vehicles the user is authorized to
        /// </summary>
        /// <returns></returns>
        public IEnumerable<TripModel> GetTrips(int lastNumberOfDays, int? vehicleId, bool synchronized = true)
        {
            UriBuilder builder = new UriBuilder("/v1/resourceowner/trips");
            var query = HttpUtility.ParseQueryString(builder.Query);
            query["lastNumberOfDays"] = lastNumberOfDays.ToString();

            if (vehicleId.HasValue == true)
                query["vehicleId"] = vehicleId.Value.ToString();

            query["synchronized"] = synchronized.ToString();
            builder.Query = query.ToString();

            var response = client.GetAsync(builder.Uri).Result;

            response.EnsureSuccessStatusCode();
            return JsonConvert.DeserializeObject<List<TripModel>>(response.Content.ReadAsStringAsync().Result);
        }
        
    }
}
