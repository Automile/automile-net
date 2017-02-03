using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;



namespace Automile.Net
{
    public class Contact2Model
    {
        public int ContactId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string MobilePhoneNumber { get; set; }
        public string ProfileImageUrl { get; set; }
        public DateTime? CheckedInDateTimeUtc { get; set; }
        public int? CheckedIntoVehicleId { get; set; }
        public bool IsManager { get; set; }

        public List<ApiRoleTypeInCompany> CompanyRoles { get; set; }
        
        /// <summary>
        /// ISO 4217 Currency code
        /// </summary>
        public string CurrencyCode { get; set; }        
    }
}
