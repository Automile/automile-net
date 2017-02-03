using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Automile.Net
{

    public class SlackOutgoingPayload
    {
        public string text { get; set; }
        public bool unfurl_links { get; set; } 
    }


    public class SlackPayloadModel
    {
        public string token { get; set; }
        public string team_id { get; set; }
        public string channel_id { get; set; }
        public string channel_name { get; set; }
        public string user_id { get; set; }
        public string user_name { get; set; }
        public string command { get; set; }
        public string text { get; set; }
    }


    public class SlackIncomingWebHook
    {
        public List<SlackAttachment> attachments { get; set; }

    }

    
    public class SlackAttachment
    {
        public string fallback { get; set; }
        public string text { get; set; }
        public string pretext { get; set; }
        public string color { get; set; }
        public List<SlackAttachmentField> fields { get; set; }

    }

    public class SlackAttachmentField
    {
        public string title { get; set; }
        public string value { get; set; }
      
        [JsonProperty(PropertyName = "short")]
        public bool _short { get; set; }


    }

}
