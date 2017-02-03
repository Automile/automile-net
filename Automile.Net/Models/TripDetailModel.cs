using System;


namespace Automile.Net
{
    public class TripDetailModel
    {
        public int TripId { get; set; }
        public string IMEI { get; set; }
        public DateTime TripStartDateTime { get; set; }
        public short? TripStartTimeZone { get; set; }
        public int TripStartODOMeter { get; set; }
        public short? TripNumber { get; set; }
        public byte NumberOfSupportedPIDs { get; set; }
        public string VehicleIdentificationNumber { get; set; }
        public string VechicleProtocol { get; set; }
        public DateTime? TripEndDateTime { get; set; }
        public short? TripEndTimeZone { get; set; }
        public int? TripEndODOMeter { get; set; }
        public string TripStartFormattedAddress { get; set; }
        public string TripEndFormattedAddress { get; set; }
        public string TripStartCustomAddress { get; set; }
        public string TripEndCustomAddress { get; set; }
        public ApiTripType TripType { get; set; }
        public string TripTags { get; set; }
        public int? VehicleId { get; set; }
        public decimal? FuelInLiters { get; set; }
        public decimal? TripLengthInKilometers { get; set; }
        public int? TripLengthInMinutes { get; set; }
        public int? IdleTimeInSecondsAllTrip { get; set; }
        public int? IdleTimeInSecondsFromStart { get; set; }
        public short? IdleRPMMax { get; set; }
        public byte? MaxSpeed { get; set; }
        public short? MaxRPM { get; set; }
        public decimal? CO2EmissionInGrams { get; set; }

        public decimal? OdometerInKilometersAfterTripEnded { get; set; }

        public decimal? AverageSpeedInKilometersPerHour { get; set; }

        public decimal? TripStartOutsideTemperatureInCelsius { get; set; }
        public int? DriverContactId { get; set; }
        public bool HasDrivingEvents { get; set; }
        public string CustomCategory { get; set; }
    }
}
