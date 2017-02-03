using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Automile.Net
{
    public class UserCreateModel
    {
        [Required(ErrorMessage = "You need to supply a username")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "You need to supply a firstname")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "You need to supply a lastname")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "You need to supply an e-mail address")]
        public string EmailAddress { get; set; }

        public string MobilePhoneNumber { get; set; }

        public string Description { get; set; }

        public string Password { get; set; }
    }
}
