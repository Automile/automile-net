using System.Collections.Generic;


namespace Automile.Net.VehicleInspection
{
    public class VehicleDefectTypeModel
    {
        public ApiVehicleDefectType DefectType { get; set; }
        public Dictionary<string, string> LocalizedName { get; set; }
    }
}