using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Automile.Net
{
    public class CompanyEditModel
    {
        [Required]
        [StringLength(255)]
        public string RegisteredCompanyName { get; set; }
        public string RegistrationNumber { get; set; }
        public string Description { get; set; }
    }
}
