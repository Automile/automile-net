using System;


namespace Automile.Net
{
    public class TriggerModel
    {
        public int TriggerId { get; set; }
        public int IMEIConfigId { get; set; }
        public ApiTriggerType TriggerType { get; set; }
        public ApiDestinationType DestinationType { get; set; }
        public string DestinationData { get; set; }
        public string TriggerTypeData { get; set; }
        public DateTime? ValidFrom { get; set; }
        public DateTime? ValidTo { get; set; }
        public DateTime? MutedUntilDateTime { get; set; }
        public int? MutedForAdditionalSeconds { get; set; }
        public DateTime CreatedAt { get; set; }
        public string TriggerTypeData2 { get; set; }
    }
}
