using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Automile.Net
{
    public class TransportstyrelsenInfoModel
    {
        public bool HasInformation { get; set; }

        public string Make { get; set; }

        public string Model { get; set; }

        public string MakeImageUrl { get; set; }

        public short? ModelYear { get; set; }

        public string BodyStyle { get; set; }

        public MainFuelType? FuelType { get; set; }

        public TransmissionType? TransmissionType { get; set; }

        public bool TrailerHitch { get; set; }
    }
}