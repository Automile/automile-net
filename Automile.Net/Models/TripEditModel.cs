using System;
using System.Collections.Generic;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Automile.Net
{

    public class TripEditModel
    {
        public string CustomCategory { get; set; }

        public ApiTripType TripType { get; set; }

        public List<string> TripTags { get; set; }

        public int? LastEditedByContactId { get; set; }
    }
   
}
