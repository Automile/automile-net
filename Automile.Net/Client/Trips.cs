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
            response.EnsureSuccessStatusCodeWithProperExceptionMessage();
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
            response.EnsureSuccessStatusCodeWithProperExceptionMessage();
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
            response.EnsureSuccessStatusCodeWithProperExceptionMessage();
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
            response.EnsureSuccessStatusCodeWithProperExceptionMessage();
            return JsonConvert.DeserializeObject<List<VehicleSpeedModel>>(response.Content.ReadAsStringAsync().Result);
        }

        /// <summary>
        /// Get the RPM of all recorded points in the trip
        /// </summary>
        /// <param name="tripId"></param>
        /// <returns></returns>
        public IEnumerable<RPMModel> GetTripRPM(int tripId)
        {
            var response = client.GetAsync($"/v1/resourceowner/trips/{tripId}/rpm").Result;
            response.EnsureSuccessStatusCodeWithProperExceptionMessage();
            return JsonConvert.DeserializeObject<List<RPMModel>>(response.Content.ReadAsStringAsync().Result);
        }

        /// <summary>
        /// Get the ambient temperature of all recorded points in the trip
        /// </summary>
        /// <param name="tripId"></param>
        /// <returns></returns>
        public IEnumerable<AmbientAirTemperatureModel> GetTripAmbientTemperature(int tripId)
        {
            var response = client.GetAsync($"/v1/resourceowner/trips/{tripId}/ambienttemperature").Result;
            response.EnsureSuccessStatusCodeWithProperExceptionMessage();
            return JsonConvert.DeserializeObject<List<AmbientAirTemperatureModel>>(response.Content.ReadAsStringAsync().Result);
        }

        /// <summary>
        /// Get the fuel level of all recorded levels in the trip (if car supports this feature)
        /// </summary>
        /// <param name="tripId"></param>
        /// <returns></returns>
        public IEnumerable<FuelLevelInputModel> GetTripFuelLevel(int tripId)
        {
            var response = client.GetAsync($"/v1/resourceowner/trips/{tripId}/ambienttemperature").Result;
            response.EnsureSuccessStatusCodeWithProperExceptionMessage();
            return JsonConvert.DeserializeObject<List<FuelLevelInputModel>>(response.Content.ReadAsStringAsync().Result);
        }

        /// <summary>
        /// Get the engine coolant temperature recorded points in the trip
        /// </summary>
        /// <param name="tripId"></param>
        /// <returns></returns>
        public IEnumerable<EngineCoolantTemperatureModel> GetTripEngineCoolantTemperature(int tripId)
        {
            var response = client.GetAsync($"/v1/resourceowner/trips/{tripId}/enginecoolanttemperature").Result;
            response.EnsureSuccessStatusCodeWithProperExceptionMessage();
            return JsonConvert.DeserializeObject<List<EngineCoolantTemperatureModel>>(response.Content.ReadAsStringAsync().Result);
        }

        /// <summary>
        /// Get the raw pid recorded points in the trip
        /// </summary>
        /// <param name="tripId"></param>
        /// <returns></returns>
        public IEnumerable<PIDModel> GetTripPIDRaw(int tripId, int pidId)
        {
            var response = client.GetAsync($"/v1/resourceowner/trips/{tripId}/pid/{pidId}").Result;
            response.EnsureSuccessStatusCodeWithProperExceptionMessage();
            return JsonConvert.DeserializeObject<List<PIDModel>>(response.Content.ReadAsStringAsync().Result);
        }

        /// <summary>
        /// Get the latitude and longitude records in the trip, supports both ongoing and completed trips
        /// </summary>
        /// <param name="tripId"></param>
        /// <param name="snapToRoad">Set to true if you want to receive latitude and longitude that are adjusted to the actual closest road</param>
        /// <returns></returns>
        public IEnumerable<TripGeoModel> GeoTripLatitudeLongitude(int tripId, int everyNthRecord = 1, bool snapToRoad = true)
        {
            var response = client.GetAsync($"/v1/resourceowner/trips/{tripId}/geo?everyNthRecord={everyNthRecord}&snapToRoad={snapToRoad}").Result;
            response.EnsureSuccessStatusCodeWithProperExceptionMessage();
            return JsonConvert.DeserializeObject<List<TripGeoModel>>(response.Content.ReadAsStringAsync().Result);
        }

        /// <summary>
        /// Updates the given trip with a trip type (category) and trip tags
        /// </summary>
        /// <param name="tripId"></param>
        /// <param name="model"></param>
        public void EditTrip(int tripId, TripEditModel model)
        {
            string stringPayload = JsonConvert.SerializeObject(model);
            var content = new StringContent(stringPayload, Encoding.UTF8, "application/json");
            var response = client.PutAsync($"/v1/resourceowner/trips/{tripId}", content).Result;
            response.EnsureSuccessStatusCodeWithProperExceptionMessage();
        }

        /// <summary>
        /// Updates the last trip with trip notes, applies to the current checked-in vehicle
        /// </summary>
        /// <param name="model"></param>
        public void AddNoteToLastTrip(TripAddNoteModel model)
        {
            string stringPayload = JsonConvert.SerializeObject(model);
            var content = new StringContent(stringPayload, Encoding.UTF8, "application/json");
            var response = client.PutAsync($"/v1/resourceowner/trips/addnotestolasttrip", content).Result;
            response.EnsureSuccessStatusCodeWithProperExceptionMessage();
        }


        /// <summary>
        /// Set's the driver for the specified trip
        /// </summary>
        /// <param name="tripId"></param>
        /// <param name="contactId"></param>
        public void SetDriverOnTrip(int tripId, int contactId)
        {
            var response = client.PutAsync($"/v1/resourceowner/trips/setdriverontrip?tripId={tripId}&contactId={contactId}", null).Result;
            response.EnsureSuccessStatusCodeWithProperExceptionMessage();
        }

        /// <summary>
        /// Mark trips as synchronized, synchronized trips will not be returned when fetching trips
        /// </summary>
        /// <param name="model"></param>
        public void AddNoteToLastTrip(TripSynchronized model)
        {
            string stringPayload = JsonConvert.SerializeObject(model);
            var content = new StringContent(stringPayload, Encoding.UTF8, "application/json");
            var response = client.PostAsync($"/v1/resourceowner/trips/synchronized", content).Result;
            response.EnsureSuccessStatusCodeWithProperExceptionMessage();
        }


        /// <summary>
        /// Get the completed details about the trip including driving events, speeding and idling
        /// </summary>
        /// <param name="tripId"></param>
        /// <returns></returns>
        public TripConcatenation GetCompletedTripDetails(int tripId)
        {
            var response = client.GetAsync($"/v1/resourceowner/trips/{tripId}/details").Result;
            response.EnsureSuccessStatusCodeWithProperExceptionMessage();
            return JsonConvert.DeserializeObject<TripConcatenation>(response.Content.ReadAsStringAsync().Result);
        }

        /// <summary>
        /// Get the completed advanced details about the trip including driving events, speeding, idling, speed and rpm data series
        /// </summary>
        /// <param name="tripId"></param>
        /// <returns></returns>
        public TripConcatenation GetCompletedTripDetailsAdvanced(int tripId)
        {
            var response = client.GetAsync($"/v1/resourceowner/trips/{tripId}/advanced").Result;
            response.EnsureSuccessStatusCodeWithProperExceptionMessage();
            return JsonConvert.DeserializeObject<TripConcatenation>(response.Content.ReadAsStringAsync().Result);
        }
    }
}
