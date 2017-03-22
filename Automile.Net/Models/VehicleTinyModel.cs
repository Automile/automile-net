namespace Automile.Net
{
    public class VehicleTinyModel
    {
        public int VehicleId { get; set; }

        public string NumberPlate { get; set; }

        public string Make { get; set; }

        public string Model { get; set; }

        public string FriendlyName { get; set; }

        public MainFuelType? FuelType { get; set; }

        public short? ModelYear { get; set; }
        public string ImageUrlMake { get; set; }
        public string UserFriendlyName { get; set; }

        public static VehicleTinyModel PopulateModel(VehicleModel vehicle)
        {
            VehicleTinyModel model = new VehicleTinyModel();
            model.VehicleId = vehicle.VehicleId;
            model.NumberPlate = vehicle.NumberPlate;
            model.Make = vehicle.Make;
            model.Model = vehicle.Model;
            model.FriendlyName = vehicle.FriendlyName;
            model.UserFriendlyName = vehicle.UserFriendlyName;
            model.FuelType = vehicle.FuelType;
            model.ImageUrlMake = vehicle.ImageUrlMake;
            model.ModelYear = vehicle.ModelYear;
            return model;
        }
    }
}