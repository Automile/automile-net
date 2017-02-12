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
        /// Get's all publish susbcribe records
        /// </summary>
        /// <returns></returns>
        public IEnumerable<PublishSubscribeModel> GetPublishSubscribe()
        {
            var response = client.GetAsync("/v1/resourceowner/publishsubscribe").Result;
            response.EnsureSuccessStatusCodeWithProperExceptionMessage();
            return JsonConvert.DeserializeObject<List<PublishSubscribeModel>>(response.Content.ReadAsStringAsync().Result);
        }

        /// <summary>
        /// Get details about a specific publish subscribe record
        /// </summary>
        /// <param name="fleetId"></param>
        /// <returns>The detailed model for the fleet</returns>
        public PublishSubscribeModel GetPublishSubscribeById(int publishSubscribeId)
        {
            var response = client.GetAsync($"/v1/resourceowner/publishsubscribe/{publishSubscribeId}").Result;
            response.EnsureSuccessStatusCodeWithProperExceptionMessage();
            return JsonConvert.DeserializeObject<PublishSubscribeModel>(response.Content.ReadAsStringAsync().Result);
        }

        /// <summary>
        /// Creates a new subscription with bearer token authentication
        /// </summary>
        /// <param name="publishToUrl">URL to receive HTTP post</param>
        /// <param name="bearerToken">The bearer token</param>
        /// <param name="vehicleId">Optional if you want only to subscribe to a specific vehicle</param>
        /// <returns></returns>
        public PublishSubscribeModel CreatePublishSubscribe(string publishToUrl, PublishSubscribeAuthenticationData_Bearer bearerToken, int? vehicleId = null)
        {
            PublishSubscribeCreateModel model = CreatePublishSubscribeCreateModel(publishToUrl, ApiPublishSubscribeAuthenticationType.BearerToken, vehicleId);
            model.AuthenticationData = Newtonsoft.Json.JsonConvert.SerializeObject(bearerToken);
            return CreatePublishSubscribe(model);
        }

        /// <summary>
        /// Creates a new subscription with basic authentication (username and password)
        /// </summary>
        /// <param name="publishToUrl">URL to receive HTTP post</param>
        /// <param name="basicUsernamePassword">The username and password information for the basic authentication</param>
        /// <param name="vehicleId">Optional if you want only to subscribe to a specific vehicle</param>
        /// <returns></returns>
        public PublishSubscribeModel CreatePublishSubscribe(string publishToUrl, PublishSubscribeAuthenticationData_Basic basicUsernamePassword, int? vehicleId = null)
        {
            PublishSubscribeCreateModel model = CreatePublishSubscribeCreateModel(publishToUrl, ApiPublishSubscribeAuthenticationType.BasicUsernameAndPassword, vehicleId);
            model.AuthenticationData = Newtonsoft.Json.JsonConvert.SerializeObject(basicUsernamePassword);
            return CreatePublishSubscribe(model);
        }

        /// <summary>
        /// Creates a new subscription with Salesforce specific authentication
        /// </summary>
        /// <param name="publishToUrl">URL to receive HTTP post</param>
        /// <param name="salesforce">The Salesforce authenatication parameters</param>
        /// <param name="vehicleId">Optional if you want only to subscribe to a specific vehicle</param>
        /// <returns></returns>
        public PublishSubscribeModel CreatePublishSubscribe(string publishToUrl, PublishSubscribeAuthenticationData_Salesforce salesforce, int? vehicleId = null)
        {
            PublishSubscribeCreateModel model = CreatePublishSubscribeCreateModel(publishToUrl, ApiPublishSubscribeAuthenticationType.Salesforce, vehicleId);
            model.AuthenticationData = Newtonsoft.Json.JsonConvert.SerializeObject(salesforce);
            return CreatePublishSubscribe(model);
        }

        /// <summary>
        /// Creates a new subscription with anonymous authentication
        /// </summary>
        /// <param name="publishToUrl">URL to receive HTTP post</param>
        /// <param name="vehicleId">Optional if you want only to subscribe to a specific vehicle</param>
        /// <returns></returns>
        public PublishSubscribeModel CreatePublishSubscribe(string publishToUrl, int? vehicleId = null)
        {
            PublishSubscribeCreateModel model = CreatePublishSubscribeCreateModel(publishToUrl, ApiPublishSubscribeAuthenticationType.NoneAnonymous, vehicleId);
            return CreatePublishSubscribe(model);
        }

        /// <summary>
        /// Creates a new subscription with bearer token authentication
        /// </summary>
        /// <param name="publishToUrl">URL to receive HTTP post</param>
        /// <param name="bearerToken">The bearer token</param>
        /// <param name="vehicleId">Optional if you want only to subscribe to a specific vehicle</param>
        /// <returns></returns>
        public void EditPublishSubscribe(int publishSubscribeId, string publishToUrl, PublishSubscribeAuthenticationData_Bearer bearerToken, int? vehicleId = null)
        {
            PublishSubscribeEditModel model = CreatePublishSubscribeEditModel(publishToUrl, ApiPublishSubscribeAuthenticationType.BearerToken, vehicleId);
            model.AuthenticationData = Newtonsoft.Json.JsonConvert.SerializeObject(bearerToken);
            EditPublishSubscribe(publishSubscribeId, model);
        }

        /// <summary>
        /// Creates a new subscription with basic authentication (username and password)
        /// </summary>
        /// <param name="publishToUrl">URL to receive HTTP post</param>
        /// <param name="basicUsernamePassword">The username and password information for the basic authentication</param>
        /// <param name="vehicleId">Optional if you want only to subscribe to a specific vehicle</param>
        /// <returns></returns>
        public void EditPublishSubscribe(int publishSubscribeId, string publishToUrl, PublishSubscribeAuthenticationData_Basic basicUsernamePassword, int? vehicleId = null)
        {
            PublishSubscribeEditModel model = CreatePublishSubscribeEditModel(publishToUrl, ApiPublishSubscribeAuthenticationType.BasicUsernameAndPassword, vehicleId);
            model.AuthenticationData = Newtonsoft.Json.JsonConvert.SerializeObject(basicUsernamePassword);
            EditPublishSubscribe(publishSubscribeId, model);
        }

        /// <summary>
        /// Creates a new subscription with Salesforce specific authentication
        /// </summary>
        /// <param name="publishToUrl">URL to receive HTTP post</param>
        /// <param name="salesforce">The Salesforce authenatication parameters</param>
        /// <param name="vehicleId">Optional if you want only to subscribe to a specific vehicle</param>
        /// <returns></returns>
        public void EditPublishSubscribe(int publishSubscribeId, string publishToUrl, PublishSubscribeAuthenticationData_Salesforce salesforce, int? vehicleId = null)
        {
            PublishSubscribeEditModel model = CreatePublishSubscribeEditModel(publishToUrl, ApiPublishSubscribeAuthenticationType.Salesforce, vehicleId);
            model.AuthenticationData = Newtonsoft.Json.JsonConvert.SerializeObject(salesforce);
            EditPublishSubscribe(publishSubscribeId, model);
        }

        /// <summary>
        /// Creates a new subscription with anonymous authentication
        /// </summary>
        /// <param name="publishToUrl">URL to receive HTTP post</param>
        /// <param name="vehicleId">Optional if you want only to subscribe to a specific vehicle</param>
        /// <returns></returns>
        public void EditPublishSubscribe(int publishSubscribeId, string publishToUrl, int? vehicleId = null)
        {
            PublishSubscribeEditModel model = CreatePublishSubscribeEditModel(publishToUrl, ApiPublishSubscribeAuthenticationType.NoneAnonymous, vehicleId);
            EditPublishSubscribe(publishSubscribeId, model);
        }


        /// <summary>
        /// Delete a publish subscribe record
        /// </summary>
        /// <param name="publishSubscribeId"></param>
        public void DeletePublishSubscribe(int publishSubscribeId)
        {
            var response = client.DeleteAsync($"/v1/resourceowner/publishsubscribe/{publishSubscribeId}").Result;
            response.EnsureSuccessStatusCodeWithProperExceptionMessage();
        }

        private void EditPublishSubscribe(int publishSubscribeId, PublishSubscribeEditModel model)
        {
            string stringPayload = JsonConvert.SerializeObject(model);
            var content = new StringContent(stringPayload, Encoding.UTF8, "application/json");
            var response = client.PutAsync($"/v1/resourceowner/publishsubscribe/{publishSubscribeId}", content).Result;
            response.EnsureSuccessStatusCodeWithProperExceptionMessage();
        }

        private PublishSubscribeModel CreatePublishSubscribe(PublishSubscribeCreateModel model)
        {
            string stringPayload = JsonConvert.SerializeObject(model);
            var content = new StringContent(stringPayload, Encoding.UTF8, "application/json");
            var response = client.PostAsync($"/v1/resourceowner/publishsubscribe", content).Result;
            response.EnsureSuccessStatusCodeWithProperExceptionMessage();
            var urlToCreatedPublishSubscribe = response.Headers.GetValues("Location").First();
            var publishSubscribeModel = client.GetAsync(urlToCreatedPublishSubscribe).Result;
            publishSubscribeModel.EnsureSuccessStatusCodeWithProperExceptionMessage();
            return JsonConvert.DeserializeObject<PublishSubscribeModel>(publishSubscribeModel.Content.ReadAsStringAsync().Result);
        }

        private PublishSubscribeCreateModel CreatePublishSubscribeCreateModel(string publishToUrl, ApiPublishSubscribeAuthenticationType authType, 
             int? vehicleId = null)
        {
            PublishSubscribeCreateModel model = new PublishSubscribeCreateModel();
            model.PublishToUrl = publishToUrl;
            model.AuthenticationType = authType;
            model.VehicleId = vehicleId;
            model.PublishType = ApiPublishType.JsonDefault;

            return model;
        }

        private PublishSubscribeEditModel CreatePublishSubscribeEditModel(string publishToUrl, ApiPublishSubscribeAuthenticationType authType,
           int? vehicleId = null)
        {
            PublishSubscribeEditModel model = new PublishSubscribeEditModel();
            model.PublishToUrl = publishToUrl;
            model.AuthenticationType = authType;
            model.VehicleId = vehicleId;
            model.PublishType = ApiPublishType.JsonDefault;

            return model;
        }

    }

}
