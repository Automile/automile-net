using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automile.Net
{ 
   public class VehicleInspectionCreateModelwImage
{
    public int VehicleId { get; set; }
    public DateTime InspectionDateUtc { get; set; }

    public List<VehicleDefectCreateModelwImage> VehicleDefects { get; set; }
}

public class VehicleDefectCreateModelwImage
{
    public ApiVehicleDefectType DefectType { get; set; }
    public string Notes { get; set; }

    public List<VehicleDefectStatusCreateModel> VehicleDefectStatus { get; set; }
    public List<VehicleDefectAttachmentCreateModelwImage> VehicleDefectAttachments { get; set; }
    public List<VehicleDefectCommentsCreateModel> VehicleDefectComments { get; set; }
}


    public class VehicleDefectAttachmentCreateModelwImage
    {
        public ApiAttachmentType AttachmentType { get; set; }
        public string ImagePath { get; set; }
    }

}
