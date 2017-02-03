using System.Collections.Generic;

namespace Automile.Net
{
    public class VehickeMakesModel
    {
        public List<VehicleMakeModel> VehicleMakes { get; set; }
    }

    public class VehicleMakeModel
    {
        public string Make { get; set; }
        public string MakeUrl { get; set; }
    }

    public class VehicleModelsModel
    {
        public List<VehicleModelModel> VehicleModels { get; set; }
    }

    public class VehicleModelModel
    {
        public string Make { get; set; }
        public string Model { get; set; }
        //public int ModelYear { get; set; }
    }
}
