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
        /// Get all places belonging to all vehicles
        /// </summary>
        /// <returns></returns>
        public IEnumerable<PlaceModel> GetPlaces()
        {
            var response = client.GetAsync("/v1/resourceowner/place").Result;
            response.EnsureSuccessStatusCode();
            return JsonConvert.DeserializeObject<List<PlaceModel>>(response.Content.ReadAsStringAsync().Result);
        }

        /// <summary>
        /// Get the details about a specific place
        /// </summary>
        /// <param name="placeId"></param>
        /// <returns></returns>
        public PlaceModel GetPlaceById(int placeId)
        {
            var response = client.GetAsync($"/v1/resourceowner/place/{placeId}").Result;
            response.EnsureSuccessStatusCode();
            return JsonConvert.DeserializeObject<PlaceModel>(response.Content.ReadAsStringAsync().Result);
        }

        /// <summary>
        /// Creates a place and associates it with the first vehicle and returns the created place
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public PlaceModel CreatePlace(PlaceCreateModel model)
        {
            string stringPayload = JsonConvert.SerializeObject(model);
            var content = new StringContent(stringPayload, Encoding.UTF8, "application/json");
            var response = client.PostAsync("/v1/resourceowner/place", content).Result;
            response.EnsureSuccessStatusCode();
            var urlToCreatedPlace = response.Headers.GetValues("Location").First();
            var placeModelResult = client.GetAsync(urlToCreatedPlace).Result;
            placeModelResult.EnsureSuccessStatusCode();
            return JsonConvert.DeserializeObject<PlaceModel>(placeModelResult.Content.ReadAsStringAsync().Result);
        }

        /// <summary>
        /// Edit place
        /// </summary>
        /// <param name="placeId"></param>
        /// <param name="model"></param>
        public void EditPlace(int placeId, PlaceEditModel model)
        {
            string stringPayload = JsonConvert.SerializeObject(model);
            var content = new StringContent(stringPayload, Encoding.UTF8, "application/json");
            var response = client.PutAsync($"/v1/resourceowner/place/{placeId}", content).Result;
            response.EnsureSuccessStatusCode();
        }

        /// <summary>
        /// Deletes the geofence
        /// </summary>
        /// <param name="placeId"></param>
        public void DeletePlace(int placeId)
        {
            var response = client.DeleteAsync($"/v1/resourceowner/place/{placeId}").Result;
            response.EnsureSuccessStatusCode();
        }



    }
}
