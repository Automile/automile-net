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
        public IEnumerable<TripModel> GetTrips(int lastNumberOfDays, int? vehicleId = null, bool synchronized = true)
        {
            var response = client.GetAsync($"/v1/resourceowner/trips?lastNumberOfDays={lastNumberOfDays}&vehicleId={vehicleId}&synchronized={synchronized}").Result;
            response.EnsureSuccessStatusCode();
            return JsonConvert.DeserializeObject<List<TripModel>>(response.Content.ReadAsStringAsync().Result);
        }

        /// <summary>
        /// Get the details for the trip
        /// </summary>
        /// <param name="tripId"></param>
        /// <returns></returns>
        public TripDetailModel GetTripById(int tripId)
        {
            var response = client.GetAsync($"/v1/resourceowner/trips/{tripId}").Result;
            response.EnsureSuccessStatusCode();
            return JsonConvert.DeserializeObject<TripDetailModel>(response.Content.ReadAsStringAsync().Result);
        }

        /// <summary>
        /// Get the start and stop latitude and longitude for the trip
        /// </summary>
        /// <param name="tripId"></param>
        /// <returns></returns>
        public TripStartEndGeoModel GetTripStartStopLatitudeLongitude(int tripId)
        {
            var response = client.GetAsync($"/v1/resourceowner/trips/{tripId}/geostartend").Result;
            response.EnsureSuccessStatusCode();
            return JsonConvert.DeserializeObject<TripStartEndGeoModel>(response.Content.ReadAsStringAsync().Result);
        }

        /// <summary>
        /// Get the speed of all recorded points in the trip
        /// </summary>
        /// <param name="tripId"></param>
        /// <returns></returns>
        public IEnumerable<VehicleSpeedModel> GetTripSpeed(int tripId)
        {
            var response = client.GetAsync($"/v1/resourceowner/trips/{tripId}/speed").Result;
            response.EnsureSuccessStatusCode();
            return JsonConvert.DeserializeObject<List<VehicleSpeedModel>>(response.Content.ReadAsStringAsync().Result);
        }

    }
}
