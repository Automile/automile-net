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
        /// Get details about a specific relationship between a place and a vehicle
        /// </summary>
        /// <param name="vehicleGeofenceId"></param>
        /// <returns>The detailed model for the relationship</returns>
        public VehiclePlaceModel GetVehiclePlaceById(int vehiclePlaceId)
        {
            var response = client.GetAsync($"/v1/resourceowner/vehicleplace/{vehiclePlaceId}").Result;
            response.EnsureSuccessStatusCodeWithProperExceptionMessage();
            return JsonConvert.DeserializeObject<VehiclePlaceModel>(response.Content.ReadAsStringAsync().Result);
        }

        /// <summary>
        /// Get's all relationsships between places and vehicles
        /// </summary>
        /// <param name="placeId"></param>
        /// <returns></returns>
        public IEnumerable<VehiclePlaceModel> GetVehiclePlacesByPlaceId(int placeId)
        {
            var response = client.GetAsync($"/v1/resourceowner/vehicleplace?placeId={placeId}").Result;
            response.EnsureSuccessStatusCodeWithProperExceptionMessage();
            return JsonConvert.DeserializeObject<List<VehiclePlaceModel>>(response.Content.ReadAsStringAsync().Result);
        }

        /// <summary>
        /// Creates a relationship between a vehicle and a place and returns the newly created relationship
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public VehiclePlaceModel CreateVehiclePlace(VehiclePlaceCreateModel model)
        {
            if (model.TripTypeTrigger.HasValue == true && model.TripTypeTrigger.Value == ApiTripTypeTrigger.DrivesBetween && model.DrivesBetweenAnotherPlaceId.HasValue == false)
                throw new ArgumentException("You need to enter the second place when you select the drives between type, use the DrivesBetweenAnotherPlaceId property");

            if ((model.TripTypeTrigger.HasValue == false || (model.TripTypeTrigger.HasValue == true && model.TripTypeTrigger.Value != ApiTripTypeTrigger.DrivesBetween)) && model.DrivesBetweenAnotherPlaceId.HasValue == true)
                throw new ArgumentException("You can't use DrivesBetweenAnotherPlaceId property if the TripTypeTrigger is null or isnt't equal to DrivesBetween type");

            string stringPayload = JsonConvert.SerializeObject(model);
            var content = new StringContent(stringPayload, Encoding.UTF8, "application/json");
            var response = client.PostAsync($"/v1/resourceowner/vehicleplace", content).Result;
            response.EnsureSuccessStatusCodeWithProperExceptionMessage();
            var urlToCreatedVehiclePlace = response.Headers.GetValues("Location").First();
            var vehiclePlaceModelResponse = client.GetAsync(urlToCreatedVehiclePlace).Result;
            vehiclePlaceModelResponse.EnsureSuccessStatusCodeWithProperExceptionMessage();
            return JsonConvert.DeserializeObject<VehiclePlaceModel>(vehiclePlaceModelResponse.Content.ReadAsStringAsync().Result);
        }

        /// <summary>
        /// Edit a relationship between a vehicle and a geofence
        /// </summary>
        /// <param name="vehicleGeofenceId"></param>
        /// <param name="model"></param>
        public void EditVehiclePlace(int vehiclePlaceId, VehiclePlaceEditModel model)
        {
            if (model.TripTypeTrigger.HasValue == true && model.TripTypeTrigger.Value == ApiTripTypeTrigger.DrivesBetween && model.DrivesBetweenAnotherPlaceId.HasValue == false)
                throw new ArgumentException("You need to enter the second place when you select the drives between type, use the DrivesBetweenAnotherPlaceId property");

            if ((model.TripTypeTrigger.HasValue == false || (model.TripTypeTrigger.HasValue == true && model.TripTypeTrigger.Value != ApiTripTypeTrigger.DrivesBetween)) && model.DrivesBetweenAnotherPlaceId.HasValue == true)
                throw new ArgumentException("You can't use DrivesBetweenAnotherPlaceId property if the TripTypeTrigger is null or isnt't equal to DrivesBetween type");

            string stringPayload = JsonConvert.SerializeObject(model);
            var content = new StringContent(stringPayload, Encoding.UTF8, "application/json");
            var response = client.PutAsync($"/v1/resourceowner/vehicleplace/{vehiclePlaceId}", content).Result;
            response.EnsureSuccessStatusCodeWithProperExceptionMessage();
        }
        
        /// <summary>
        /// Delete a relationship between a vehicle and a place
        /// </summary>
        /// <param name="vehiclePlaceId"></param>
        public void DeleteVehiclePlace(int vehiclePlaceId)
        {
            var response = client.DeleteAsync($"/v1/resourceowner/vehicleplace/{vehiclePlaceId}").Result;
            response.EnsureSuccessStatusCodeWithProperExceptionMessage();
        }
    }
}
