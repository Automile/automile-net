using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automile.Net
{

    public class PublishSubscribeAuthenticationData_Salesforce
    {
        public string OrganisationId { get; set; }
        public string InstanceUrl { get; set; }
        public string ClientSecret { get; set; }
        public string ClientId { get; set; }
        public string AuthCode { get; set; }
    }

    public class PublishSubscribeAuthenticationData_Basic
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class PublishSubscribeAuthenticationData_Bearer
    {
        public string BearerToken { get; set; }
    }
}
