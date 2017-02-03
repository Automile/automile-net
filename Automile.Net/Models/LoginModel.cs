using System.ComponentModel.DataAnnotations;

namespace Automile.Net
{
    public class LoginModel
    {
        public string UserName { get; set; }

        public string Password { get; set; }

        public string ClientId { get; set; }

        public string Scopes { get; set; }

        public string RedirectUri { get; set; }
    }
}