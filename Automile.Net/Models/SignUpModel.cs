using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automile.Net
{
    public class SignUpRequestModel
    {
        public string Email { get; set; }

    }

    public class SignUpResponseModel
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public string APIClientIdentifier { get; set; }

        public string APIClientSecret { get; set; }
    }
}
