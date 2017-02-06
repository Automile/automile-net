using System.ComponentModel.DataAnnotations;


namespace Automile.Net
{
    public class PlaceEditModel
    {
        [Required(ErrorMessage = "You need to supply a place name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "You need to supply a radius")]
        public int Radius { get; set; }

        [Required(ErrorMessage = "You need to supply a position point")]
        public PositionPointModel PositionPoint { get; set; }

        public string Description { get; set; }

        public ApiTripType? TripType { get; set; }

        public ApiTripTypeTrigger? TripTypeTrigger { get; set; }

        public int? DrivesBetweenAnotherPlaceId { get; set; }
    }
}