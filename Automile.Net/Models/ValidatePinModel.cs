using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Automile.Net
{
    public class ValidatePinModel
    {
        public string UserName { get; set; }
        public string Pin { get; set; }
        public Guid? UserGuid { get; set; }
    }
}