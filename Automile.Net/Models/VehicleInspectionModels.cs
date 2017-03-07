using System;
using System.Collections.Generic;


namespace Automile.Net
{
    public class VehicleInspectionModel
    {
        public int VehicleInspectionId { get; set; }
        public int VehicleId { get; set; }
        public int CreatedByContactId { get; set; }
        public ApiVehicleInspectionStatusType InspectionStatusType { get; set; }
        public DateTime InspectionDateUtc { get; set; }

        public List<VehicleDefectModel> VehicleDefects { get; set; }
        public List<VehicleInspectionStatusModel> InspectionStatus { get; set; }
    }

    public class VehicleInspectionStatusModel
    {
        public int VehicleInspectionStatusId { get; set; }
        public int VehicleInspectionId { get; set; }
        public int CreatedByContactId { get; set; }
        public ApiVehicleInspectionStatusType InspectionStatusType { get; set; }
        public DateTime StatusDateUtc { get; set; }
    }

    public class VehicleDefectModel
    {
        public int VehicleDefectId { get; set; }
        public int VehicleInspectionId { get; set; }
        public ApiVehicleDefectType DefectType { get; set; }
        public int CreatedByContactId { get; set; }
        public DateTime DefectDateUtc { get; set; }
        public string Notes { get; set; }
        public ApiVehicleDefectStatusType DefectStatusType { get; set; }

        public List<VehicleDefectStatusModel> VehicleDefectStatus { get; set; }
        public List<VehicleDefectAttachmentModel> VehicleDefectAttachments { get; set; }
        public List<VehicleDefectCommentsModel> VehicleDefectComments { get; set; }        
    }

    public class VehicleDefectStatusModel
    {
        public int VehicleDefectStatusId { get; set; }
        public int VehicleDefectId { get; set; }
        public int CreatedByContactId { get; set; }
        public ApiVehicleDefectStatusType DefectStatus { get; set; }
        public DateTime DefectStatusDateUtc { get; set; }
    }

    public class VehicleDefectCommentsModel
    {
        public int VehicleDefectCommentId { get; set; }
        public int VehicleDefectId { get; set; }
        public int CreatedByContactId { get; set; }
        public string Comment { get; set; }
        public DateTime CommentDateUtc { get; set; }
    }

    public class VehicleDefectAttachmentModel
    {
        public int VehicleDefectAttachmentId { get; set; }
        public int VehicleDefectId { get; set; }
        public byte AttachmentType { get; set; }
        public string AttachmentLocation { get; set; }
        public DateTime AttachmentDateUtc { get; set; }
    }
}