using System;
using System.ComponentModel.DataAnnotations;


namespace Automile.Net
{
    public class TriggerEditModel
    {
        [Required]
        public int IMEIConfigId { get; set; }

        public ApiTriggerType TriggerType { get; set; }
        public string TriggerTypeData { get; set; }
        public string TriggerTypeData2 { get; set; }
        public DateTime? ValidFrom { get; set; }
        public DateTime? ValidTo { get; set; }
        public DateTime? MutedUntilDateTime { get; set; }
        public ApiDestinationType DestinationType { get; set; }

        [Required]
        public string DestinationData { get; set; }
        public ApiDeliveryType DeliveryType { get; set; }
    }
}
