using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Automile.Net
{
    public class PublishSubscribeCreateModel
    {
        public string PublishToUrl { get; set; }

        public ApiPublishType PublishType { get; set; }

        public int? VehicleId { get; set; }

        public ApiPublishSubscribeAuthenticationType AuthenticationType { get; set; }

        public string AuthenticationData { get; set; }
    }

}