using System;
using System.Collections.Generic;



namespace Automile.Net
{
    public class Vehicle2DetailModel
    {
        public string VehicleIdentificationNumber { get; set; }
        public string NumberPlate { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int? ModelYear { get; set; }
        public string BodyStyle { get; set; }
        public int? OwnerContactId { get; set; }
        public int? OwnerCompanyId { get; set; }
        public string OwnedByName { get; set; }
        public int NumberOfTrips { get; set; }
        public decimal? DistanceTravelledThisYear { get; set; }
        public decimal? DistanceTravelledLastYear { get; set; }
        public double? LastKnownLatitude { get; set; }
        public double? LastKnownLongitude { get; set; }
        public DateTime? LastKnownGeoTimeStamp { get; set; }    
        public string LastKnownFormattedAddress { get; set; }
        public string LastKnownCustomAddress { get; set; }
        public double? LastKnownSpeed { get; set; }
        public double? LastKnownTemperature { get; set; }
        public DateTime? LastKnownTemperatureTimeStamp { get; set; }
        public double? LastTripEndLatitude { get; set; }
        public double? LastTripEndLongitude { get; set; }
        public DateTime? LastTripStartGeoTimeStamp { get; set; }
        public DateTime? LastTripEndGeoTimeStamp { get; set; }
        public int? ParkedForNumberOfSeconds { get; set; }
        public int? OngoingTripId { get; set; }
        public int? LastTripId { get; set; }
        public string MakeImageUrl { get; set; }
        public decimal? CurrentOdometerInKilometers { get; set; }

        // New props
        public string UserVehicleIdentificationNumber { get; set; }
        public ApiMainFuelType? FuelType { get; set; }
        public ApiTripType? DefaultTripType { get; set; }
        public bool AllowAutomaticUpdates { get; set; }
        public DateTime? AquiredDate { get; set; }
        public decimal? YearlyTax { get; set; }
        public DateTime? LastSyncUtcWithVehicleExternalInformation { get; set; }
        public short? NumberOfOwners { get; set; }
        public string Status1 { get; set; }
        public string RegisteredInISO3166CountryCode { get; set; }
        public bool? AllowAutomaticVehicleExternalInformationUpdate { get; set; }
        public double? CO2Urban { get; set; }
        public double? CO2UrbanExtra { get; set; }
        public double? CO2Combined { get; set; }
        public string FrontTyre { get; set; }
        public string RearTyre { get; set; }
        public string FrontWheelRim { get; set; }
        public string RearWheelRim { get; set; }
        public bool? TrailerHitch { get; set; }
        public double? TrailerHitchMaxLoadKgWithoutBreaks { get; set; }
        public double? TrailerHitchMaxLoadKgWithDefaultDriversLicence { get; set; }
        public double? TrailerHitchMaxLoadKgWithAlternativeDriversLicence { get; set; }
        public DateTime? InspectionPeriodStart { get; set; }
        public DateTime? InspectionPeriodEnd { get; set; }
        public string Owner { get; set; }
        public OwnerType? OwnerType { get; set; }
        public string LeaseCompany { get; set; }
        public string InsuranceCompany { get; set; }
        public short? EngineSizekW { get; set; }
        public short? DisplacementCm3 { get; set; }
        public double? VehicleMatureTax { get; set; }
        public double? VehicleTax { get; set; }
        public byte? MaxNumberOfPassengers { get; set; }
        public double? CurbWeightKg { get; set; }
        public double? GrossWeightKg { get; set; }
        public double? TaxWeightKg { get; set; }
        public double? MaxGrossWeightWithTrailerKg { get; set; }
        public bool? IsImported { get; set; }
        public DateTime? FirstDateRegisteredInCurrentCountry { get; set; }
        public DateTime? VehicleManufacturedDate { get; set; }
        public string PaintColor { get; set; }
        public bool? AllowTripDrivingEventRecording { get; set; }
        public DateTime? InsuranceDate { get; set; }
        public double? TrailerHitchMaxWeightKg { get; set; }
        public DateTime? LastInspectionDate { get; set; }
        public int? CheckedInContactId { get; set; }
        public int? LastTripIdCheckedInContact { get; set; }
        public double? FuelConsumptionCombinedLiters { get; set; }
        public ApiTransmissionType? TransmissionType { get; set; }
        public decimal? PriceExcludingEquipmentLocalCurrency { get; set; }
        public decimal AverageTripDistanceKm { get; set; }
        public double AverigeTripIdleTimeSeconds { get; set; }
        public decimal AverageFuelConsumptionLiter { get; set; }
        public bool IsEditable { get; set; }
        public int? TransferIntervalInSeconds { get; set; }
        public bool? SampleHarshEvents { get; set; }
        public List<string> Features { get; set; }
        public bool? AllowSpeedRecording { get; set; }
        public string Nickname { get; set; }
        public int? CategoryColor { get; set; }
        public string Tags { get; set; }
    }
}
