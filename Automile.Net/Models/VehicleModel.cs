using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automile.Net
{
    public class VehicleModel
    {
        public int VehicleId { get; set; }
        public string VehicleIdentificationNumber { get; set; }
        public string NumberPlate { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int? OwnerContactId { get; set; }
        public int? OwnerCompanyId { get; set; }
        public decimal? CurrentOdometerInKilometers { get; set; }

        public string FriendlyName
        {
            get
            {
                if (string.IsNullOrWhiteSpace(this.UserFriendlyName) == false)
                    return UserFriendlyName;

                string vehicleName = VehicleId.ToString(CultureInfo.InvariantCulture);

                if (Make != null)
                    vehicleName = Make;

                if (Model != null)
                    vehicleName = vehicleName + " " + Model;

                if (!string.IsNullOrEmpty(NumberPlate))
                    vehicleName = vehicleName + " (" + NumberPlate + ")";

                return vehicleName;
            }
        }
        public string UserFriendlyName { get; set; }

        public Nullable<MainFuelType> FuelType { get; set; }

        public string ImageUrlMake
        {
            get
            {
                string url = "https://content.automile.se/vinlogo/placeholder.png";
                if (!string.IsNullOrEmpty(Make))
                    url = "https://content.automile.se/vinlogo/" + Make.ToLower().Trim().Replace("ë", "e").Replace(" ", "-") + ".png";
                return url;
            }
        }

        public Nullable<short> ModelYear { get; set; }
    }
}
