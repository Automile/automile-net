using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Automile.Net
{
    public class TriggerCreateModel
    {
        [Required]
        public int IMEIConfigId { get; set; }
    
        public ApiTriggerType TriggerType { get; set; }
        public string TriggerTypeData { get; set; }
        public string TriggerTypeData2 { get; set; }
        public DateTime? ValidFrom { get; set; }
        public DateTime? ValidTo { get; set; }
        public ApiDestinationType DestinationType { get; set; }

        [Required(ErrorMessage = "DestinationData is required")]
        public string DestinationData { get; set; }
        public ApiDeliveryType DeliveryType { get; set; }
    }
}
