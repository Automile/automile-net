

namespace Automile.Net
{
    public class LeadActivityCreateModel
    {
        public int LeadId { get; set; }
        public ApiLeadActionType LeadActionType { get; set; }
        public string ActionValue { get; set; }
    }
}