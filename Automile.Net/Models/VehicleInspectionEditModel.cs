using System.Collections.Generic;


namespace Automile.Net.VehicleInspection
{
    public class VehicleInspectionEditModel
    {
        public int VehicleId { get; set; }
        public ApiVehicleInspectionStatusType? InspectionStatusType { get; set; }
        public List<VehicleDefectEditModel> VehicleDefects { get; set; }
    }

    public class VehicleDefectEditModel
    {
        public int? VehicleDefectId { get; set; }        
        public ApiVehicleDefectType? DefectType { get; set; }
        public string Notes { get; set; }

        public ApiVehicleDefectStatusType? DefectStatusType { get; set; }
        public List<VehicleDefectAttachmentEditModel> VehicleDefectAttachments { get; set; }
        public List<VehicleDefectCommentEditModel> VehicleDefectComments { get; set; }
    }

    public class VehicleDefectCommentEditModel
    {
        public int? VehicleDefectCommentId { get; set; }
        public string Comment { get; set; }        
    }

    public class VehicleDefectAttachmentEditModel
    {
        public int? VehicleDefectAttachmentId { get; set; }
        public byte AttachmentType { get; set; }        
        public string Data { get; set; }
    }
}