using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace Automile.Net
{
    public class CustomUserCreateWithoutPasswordModel
    {
        [Required(ErrorMessage = "You need to supply a username")]
        public string UserName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        [Required(ErrorMessage = "You need to supply an e-mail address")]
        [EmailAddress(ErrorMessage="You need to supply a valid e-mail address")]
        public string EmailAddress { get; set; }

        public string MobilePhoneNumber { get; set; }

        public string Description { get; set; }

        public string Culture { get; set; }

        //[Required(ErrorMessage = "You need to supply an IMEI")]
        public string IMEI { get; set; }

        //[Required(ErrorMessage = "You need to supply a serial number")]
        public string SerialNumber { get; set; }

        public ApiUnitType? UnitType { get; set; }
    }
}
