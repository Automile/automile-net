

namespace Automile.Net
{
    public class VehicleMetadataModel
    {
        public int VehicleMetadataId { get; set; }
        public string Value { get; set; }
        public ApiVehicleMetadataType Type { get; set; }
    }

    public class VehicleMetadataEditModel
    {
        public int? VehicleMetadataId { get; set; }
        public string Value { get; set; }
        public ApiVehicleMetadataType Type { get; set; }
    }

    public class VehicleMetadataCreateModel
    {
        public string Value { get; set; }
        public ApiVehicleMetadataType Type { get; set; }
    }
}