using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Automile.Net
{
    public class CreatePinModel
    {
        public string UserName { get; set; }
        public string MobilePhoneNumber { get; set; }
        public Guid? UserGuid { get; set; }
        public string Culture { get; set; }
    }
}