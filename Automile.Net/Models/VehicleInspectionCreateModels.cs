using System;
using System.Collections.Generic;


namespace Automile.Net
{
    public class VehicleInspectionCreateModel
    {
        public int VehicleId { get; set; }
        public DateTime InspectionDateUtc { get; set; }
        
        public List<VehicleDefectCreateModel> VehicleDefects { get; set; }
    }

    public class VehicleDefectCreateModel
    {
        public ApiVehicleDefectType DefectType { get; set; }
        public string Notes { get; set; }
        
        public List<VehicleDefectStatusCreateModel> VehicleDefectStatus { get; set; }
        public List<VehicleDefectAttachmentCreateModel> VehicleDefectAttachments { get; set; }
        public List<VehicleDefectCommentsCreateModel> VehicleDefectComments { get; set; }
    }

    public class VehicleDefectCommentsCreateModel
    {
        public int VehicleDefectId { get; set; }
        public string Comment { get; set; }
    }

    public class VehicleDefectCommentsEditModel
    {
        public string Comment { get; set; }
    }

    public class VehicleDefectStatusCreateModel
    {
        public ApiVehicleDefectStatusType DefectStatus { get; set; }        
    }

    public class VehicleDefectAttachmentCreateModel
    {
        public ApiAttachmentType AttachmentType { get; set; }
        public string Data { get; set; }
    }
}