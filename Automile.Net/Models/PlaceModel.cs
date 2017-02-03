
namespace Automile.Net
{
    public class PlaceModel
    {
        public int PlaceId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public PositionPointModel PositionPoint { get; set; }
        public ApiTripType? TripType { get; set; }
        public ApiTripTypeTrigger? TripTypeTrigger { get; set; }
        public int? Radius { get; set; }
        public bool IsEditable { get; set; }
    }
}