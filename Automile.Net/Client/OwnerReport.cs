using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Automile.Net
{
    public partial class AutomileClient
    {
        /// <summary>
        /// The trip summary report are returned
        /// </summary>
        /// /// <param name="dateperiod"></param>
        /// <returns></returns>
        public IEnumerable<TripSummaryReportModel> GetTripSummaryReport(string dateperiod)
        {
            var response = client.GetAsync($"/v1/resourceowner/reports/tripsummary/{dateperiod}").Result;
            response.EnsureSuccessStatusCodeWithProperExceptionMessage();
            return JsonConvert.DeserializeObject<IEnumerable<TripSummaryReportModel>>(response.Content.ReadAsStringAsync().Result);
        }
       
        /// <summary>
        /// Get a trip summary report filtered by vehicle
        /// </summary>
        /// /// <param name="dateperiod"></param>
        /// /// <param name="vehicleId"></param>
        /// <returns></returns>
        public IEnumerable<TripSummaryReportModel> GetTripSummaryReportByVehicleId(string dateperiod, int vehicleId)
        {
            var response = client.GetAsync($"/v1/resourceowner/reports/tripsummary/{dateperiod}/{vehicleId}").Result;
            response.EnsureSuccessStatusCodeWithProperExceptionMessage();
            return JsonConvert.DeserializeObject<IEnumerable<TripSummaryReportModel>>(response.Content.ReadAsStringAsync().Result);
        }

        /// <summary>
        /// Get vehicles summary report
        /// </summary>
        /// /// <param name="dateperiod"></param>
        /// <returns>The vehicles summary report is returned</returns>
        public VehiclesSummaryModel GetVehiclesSummaryReport(string dateperiod)
        {
            var response = client.GetAsync($"/v1/resourceowner/reports/vehiclessummary/{dateperiod}").Result;
            response.EnsureSuccessStatusCodeWithProperExceptionMessage();
            return JsonConvert.DeserializeObject<VehiclesSummaryModel>(response.Content.ReadAsStringAsync().Result);
        }
       
        /// <summary>
        /// Get a vehicle summary report
        /// </summary>
        /// /// <param name="dateperiod"></param>
        /// /// <param name="vehicleId"></param>
        /// <returns></returns>
        public VehicleSummaryModel GetVehicleSummaryReportByVehicleId(string dateperiod, int vehicleId)
        {
            var response = client.GetAsync($"/v1/resourceowner/reports/vehiclesummary/{dateperiod}/{vehicleId}").Result;
            response.EnsureSuccessStatusCodeWithProperExceptionMessage();
            return JsonConvert.DeserializeObject<VehicleSummaryModel>(response.Content.ReadAsStringAsync().Result);
        }

        /// <summary>
        /// Email a trip journal report to a desired email address
        /// </summary>
        /// /// <param name="EmailTripReportModel"></param>
        /// <returns>A summary of all trips made in the period emailed to desired email address</returns>
        public HttpStatusCode EmailTripReport(EmailTripReportModel model)
        {
            string stringPayload = JsonConvert.SerializeObject(model);
            var content = new StringContent(stringPayload, Encoding.UTF8, "application/json");
            var response = client.PostAsync("/v1/resourceowner/reports/emailtripreport", content).Result;
            response.EnsureSuccessStatusCodeWithProperExceptionMessage();
            return response.StatusCode;
        }

        /// <summary>
        /// Get Log of GeoFences the user is authorized to
        /// </summary>
        /// // /// <param name=""></param>
        /// <returns></returns>
        public GeofenceReportModel GetGeofenceLog(int? vehicleId = null,
                                     int? geofenceId = null,
                                     DateTime? fromDate = null,
                                     DateTime? toDate = null)
        {
            var response = client.GetAsync($"/v1/resourceowner/reports/geofencelog?vehicleId={vehicleId}&geofenceId={geofenceId}&fromDate={fromDate}&toDate={toDate}").Result;
            response.EnsureSuccessStatusCodeWithProperExceptionMessage();
            return JsonConvert.DeserializeObject<GeofenceReportModel>(response.Content.ReadAsStringAsync().Result);
        }
    }
}
