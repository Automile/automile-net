using System.Collections.Generic;

namespace Automile.Net
{
    public class CompanyScopesModel
    {
        public int CompanyId { get; set; }
        public List<int> VehicleIds { get; set; }
        public string[] Scopes { get; set; }
    }
}