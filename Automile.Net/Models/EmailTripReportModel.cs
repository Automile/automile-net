namespace Automile.Net
{
    public class EmailTripReportModel
    {
        public int VehicleId { get; set; }
        public int Period { get; set; }
        public string ToEmail { get; set; }
        public string ISO639LanguageCode { get; set; }

        public bool ExcludeDetailsForPersonalTrips { get; set; }

        public bool ExcludeEnvironmentalAndFuelData { get; set; }
    }
}
