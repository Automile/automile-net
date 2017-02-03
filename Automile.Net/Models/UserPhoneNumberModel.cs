using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Automile.Net
{
    public class UserPhoneNumberModel
    {
        public string UserName { get; set; }

        public string PhoneNumber { get; set; }
        public Guid UserGuid { get; set; }
    }
}