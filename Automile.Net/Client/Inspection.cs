using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
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
        /// Get a vehicle inspection
        /// </summary>
        /// <response code="200">The vehicle inspection is returned</response>
        /// <response code="500">Internal server error</response>
        /// <returns>A vehicle inspection</returns>
        /// <remarks>Only returns vehicle inspetions that the user have access to</remarks>
        public VehicleInspectionModel GetByInspectionId(int vehicleInspectionId)
        {
            var response = client.GetAsync($"/v1/resourceowner/vehicleinspection/{vehicleInspectionId}").Result;
            response.EnsureSuccessStatusCodeWithProperExceptionMessage();
            return JsonConvert.DeserializeObject<VehicleInspectionModel>(response.Content.ReadAsStringAsync().Result);
        }

        /// <summary>
        /// Get all vehicle inspections that the user has access to
        /// </summary>
        /// <response code="200">The vehicle inspections are returned</response>
        /// <response code="500">Internal server error</response>
        /// <returns>A list of vehicle inspections</returns>
        /// <remarks>Only returns vehicle inspetions that the user have access to</remarks>
        public IEnumerable<VehicleInspectionModel> GetByInspectionIdVehicleAndDate(int? vehicleInspectionId = null,
                                     int? vehicleId = null,
                                     DateTime? fromDate = null,
                                     DateTime? toDate = null,
                                     bool excludeArchived = true)
        {
            var response = client.GetAsync($"/v1/resourceowner/vehicleinspection?vehicleInspectionId={vehicleInspectionId}&vehicleId={vehicleId}&fromDate={fromDate}&toDate={toDate}&excludeArchived={excludeArchived}").Result;
            response.EnsureSuccessStatusCodeWithProperExceptionMessage();
            return JsonConvert.DeserializeObject<List<VehicleInspectionModel>>(response.Content.ReadAsStringAsync().Result);
        }


        /// <summary>
        /// Creates a new vehicle inspection
        /// </summary>
        /// <response code="200">A link in the header is returned to the newly created vehicle inspection</response>
        /// <response code="400">Bad request, could occur for a number of cases, see returned message</response>
        /// <response code="403">Request is forbidden, could occur for a number of reasons, see returned message</response>
        /// <response code="500">Internal server error</response>
        /// <param name="model">The vehicle inspection model</param>
        /// <remarks>This will create a new vehicle inspection and make the association you set.</remarks>
        /// <returns>A header link containing the URL to the newly created resource</returns>
        public VehicleInspectionModel CreateInspection(VehicleInspectionCreateModel model)
        {
            string stringPayload = JsonConvert.SerializeObject(model);
            var content = new StringContent(stringPayload, Encoding.UTF8, "application/json");
            var response = client.PostAsync("/v1/resourceowner/vehicleinspection", content).Result;
            response.EnsureSuccessStatusCodeWithProperExceptionMessage();
            var urlToCreatedInspection = response.Headers.GetValues("Location").First();
            var inspectionModelResult = client.GetAsync(urlToCreatedInspection).Result;
            inspectionModelResult.EnsureSuccessStatusCodeWithProperExceptionMessage();
            return JsonConvert.DeserializeObject<VehicleInspectionModel>(inspectionModelResult.Content.ReadAsStringAsync().Result);
        }

        /// <summary>
        /// Creates a new vehicle inspection from Image Path
        /// </summary>
        /// <response code="200">A link in the header is returned to the newly created vehicle inspection</response>
        /// <response code="400">Bad request, could occur for a number of cases, see returned message</response>
        /// <response code="403">Request is forbidden, could occur for a number of reasons, see returned message</response>
        /// <response code="500">Internal server error</response>
        /// <param name="model">The vehicle inspection model</param>
        /// <remarks>This will create a new vehicle inspection and make the association you set.</remarks>
        /// <returns>A header link containing the URL to the newly created resource</returns>
        public VehicleInspectionModel CreateInspection(VehicleInspectionCreateModelwImage model)
        {
            foreach (var VehicleDefect in model.VehicleDefects)
            {
                foreach (var DefectAttachment in VehicleDefect.VehicleDefectAttachments)
                {
                    using (Image image = Image.FromFile(DefectAttachment.ImagePath))
                    {
                        using (MemoryStream m = new MemoryStream())
                        {
                            image.Save(m, image.RawFormat);
                            byte[] imageBytes = m.ToArray();

                            DefectAttachment.ImagePath = Convert.ToBase64String(imageBytes);
                        }
                    }
                }
            }

            VehicleInspectionCreateModel modelCreate = new VehicleInspectionCreateModel
            {
                VehicleId = model.VehicleId,
                InspectionDateUtc = model.InspectionDateUtc,
                VehicleDefects = new List<VehicleDefectCreateModel>()
            };

            foreach(var vehicleDefect in model.VehicleDefects)
            {
                VehicleDefectCreateModel vehicledefectCreate = new VehicleDefectCreateModel();

                vehicledefectCreate.DefectType = vehicleDefect.DefectType;
                vehicledefectCreate.Notes = vehicleDefect.Notes;
                vehicledefectCreate.VehicleDefectStatus = vehicleDefect.VehicleDefectStatus;
                vehicledefectCreate.VehicleDefectAttachments = new List<VehicleDefectAttachmentCreateModel>();

                foreach(var defectAttachment in vehicleDefect.VehicleDefectAttachments)
                {
                    VehicleDefectAttachmentCreateModel defectAttachmentCreate = new VehicleDefectAttachmentCreateModel();
                    defectAttachmentCreate.AttachmentType = defectAttachment.AttachmentType;
                    defectAttachmentCreate.Data = defectAttachment.ImagePath;
                    vehicledefectCreate.VehicleDefectAttachments.Add(defectAttachmentCreate);
                }
                vehicledefectCreate.VehicleDefectComments = vehicleDefect.VehicleDefectComments;
                modelCreate.VehicleDefects.Add(vehicledefectCreate);
            }

            string stringPayload = JsonConvert.SerializeObject(modelCreate);
            var content = new StringContent(stringPayload, Encoding.UTF8, "application/json");
            var response = client.PostAsync("/v1/resourceowner/vehicleinspection", content).Result;
            response.EnsureSuccessStatusCodeWithProperExceptionMessage();
            var urlToCreatedInspection = response.Headers.GetValues("Location").First();
            var inspectionModelResult = client.GetAsync(urlToCreatedInspection).Result;
            inspectionModelResult.EnsureSuccessStatusCodeWithProperExceptionMessage();
            return JsonConvert.DeserializeObject<VehicleInspectionModel>(inspectionModelResult.Content.ReadAsStringAsync().Result);
        }

        /// <summary>
        /// Updates the given vehicle inspection with new model
        /// </summary>
        /// <response code="200">The vehicle inspection was saved</response>
        /// <response code="400">Bad request, could occur for a number of cases, see returned message</response>        
        /// <response code="403">Request is forbidden, could occur for a number of reasons, see returned message</response>
        /// <response code="404">Not found, the vehicle inspection you tried to update can't be found</response>
        /// <response code="500">Internal server error</response>
        /// <param name="vehicleInspectionId">The vehicle inspection id</param>
        /// <param name="model">The new vehicle inspection model</param>
        /// <remarks>This will update the given vehicle id with a new model.</remarks>
        public void EditInspection(int vehicleInspectionId, VehicleInspectionEditModel model)
        {
            string stringPayload = JsonConvert.SerializeObject(model);
            var content = new StringContent(stringPayload, Encoding.UTF8, "application/json");
            var response = client.PutAsync($"/v1/resourceowner/vehicleinspection/{vehicleInspectionId}", content).Result;
            response.EnsureSuccessStatusCodeWithProperExceptionMessage();
        }

        /// <summary>
        /// Export a vehicle inspection in pdf format via email
        /// </summary>
        /// <response code="200">Success status if the operation was successfull and an email has been sent</response>
        /// <response code="400">Bad request, could occur for a number of cases, see returned message</response>
        /// <response code="403">Request is forbidden, could occur for a number of reasons, see returned message</response>
        /// <response code="500">Internal server error</response>
        /// <param name="vehicleInspectionId">The VehicleInspectionId of the Vehicle Inspection to export</param>
        /// <param name="model">The model containing reciving email address and language of the email</param>
        /// <remarks>Only vehicle inspections that the user has access rights to are accessible.</remarks>
        /// <returns>200  Success status if validated and email has been sent.</returns>
        public HttpStatusCode ExportVehicleInspection(int vehicleInspectionId, VehicleInspectionExportModel model)
        {
            string stringPayload = JsonConvert.SerializeObject(model);
            var content = new StringContent(stringPayload, Encoding.UTF8, "application/json");
            var response = client.PostAsync($"/v1/resourceowner/vehicleinspection/export/{vehicleInspectionId}", content).Result;
            response.EnsureSuccessStatusCodeWithProperExceptionMessage();
            return response.StatusCode;
        }
    }
}
