using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Automile.Net
{
    public class CompanyDetailModel
    {
        public int CompanyId { get; set; }
        public string RegisteredCompanyName { get; set; }
        public string RegistrationNumber { get; set; }
        public string Description { get; set; }
        public DateTime? LastModified { get; set; }
        public DateTime Created { get; set; }
    }
}
