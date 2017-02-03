using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automile.Net
{
    public class CompanyContactDetailModel
    {
        public int CompanyContactId { get; set; }
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public int ContactId { get; set; }
        public string ContactName { get; set; }
        public DateTime? LastModified { get; set; }
        public DateTime Created { get; set; }
        public string[] Scopes { get; set; }
    }
}
