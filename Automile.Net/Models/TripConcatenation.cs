using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automile.Net
{

    public class TripConcatenation
    {
        public int TripId { get; set; }

        public int? VehicleId { get; set; }

        public string VehicleName { get; set; }

        public List<int> MergedFromTripIds { get; set; }

        public List<TripConcatenationSpeedGroup> SpeedGroups { get; set; }

        public List<TripConcatenationSpeedPoint> SpeedPoints { get; set; }

        public List<TripConcatenationPoint> RawPoints { get; set; }

        public List<TripConcatenationSimplePoint> SnappedToRoadPoints { get; set; }

        public List<TripConcatenationEvent> DrivingEvents { get; set; }

        public List<TripConcatenationData> SpeedData { get; set; }

        public List<TripConcatenationData> SpeedLimitData { get; set; }

        public List<TripConcatenationData> RPMData { get; set; }

        public DateTime StartDateTime { get; set; }

        public DateTime EndDateTime { get; set; }

        public short? TripTimeZone { get; set; }

        public string StartFormattedAddress { get; set; }

        public string EndFormattedAddress { get; set; }

        public string StartCustomAddress { get; set; }

        public string EndCustomAddress { get; set; }

        public decimal Distance { get; set; }

        public decimal? FuelConsumption { get; set; }

        public int LengthInMinutes { get; set; }

        public int? DriverContactId { get; set; }

        public string DriverName { get; set; }

        public int? IdleRPMAverage { get; set; }

        public int? IdleTimeInSecondsForAllTrip { get; set; }

        public int? IdleTimeInSecondsFromStart { get; set; }

        public decimal? CO2Emission { get; set; }

        public double? MaxSpeed { get; set; }

        public short? MaxRPM { get; set; }

        public int? ParkedForMinutesUntilNextTrip { get; set; }

        public TripConcatenationStartEndPoint StartPoint { get; set; }

        public TripConcatenationStartEndPoint EndPoint { get; set; }
        public string Notes { get; set; }
        public TripType TripType { get; set; }
        public decimal AverageSpeedInKilometersPerHour { get; set; }
        public string CustomCategory { get; set; }
    }

    public class TripConcatenationData
    {
        public DateTime RecordTimeStamp { get; set; }

        public long RecordTimeStampEpochMs { get; set; }

        public double? Value { get; set; }
    }

    public class TripConcatenationStartEndPoint
    {
        public double Latitude { get; set; }

        public double Longitude { get; set; }
    }

    public class TripConcatenationPoint
    {
        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public DateTime RecordTimeStamp { get; set; }

        public long RecordTimeStampEpochMs { get; set; }

        public double? Speed { get; set; }

        public double? RPM { get; set; }

        public ushort? HeadingDegress { get; set; }
        public byte? Hdop { get; set; }
        public byte? NumberOfSatellites { get; set; }
    }


    public class TripConcatenationSimplePoint
    {
        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public DateTime RecordTimeStamp { get; set; }

        public long RecordTimeStampEpochMs { get; set; }
    }

    public class TripConcatenationEvent
    {
        public TripDrivingEventType TripDrivingEventType { get; set; }

        public double? Latitude { get; set; }

        public double? Longitude { get; set; }

        public DateTime RecordTimeStamp { get; set; }

        public long RecordTimeStampEpochMs { get; set; }
    
    }

    public class TripConcatenationSpeedGroup
    {
        public Guid SpeedGroup { get; set; }

        public bool? SpeedingForMoreThan30Seconds { get; set; }

        public double? DistanceOfSpeeding { get; set; }

        public int? DistanceInSeconds { get; set; }

        public byte ThresholdType { get; set; }

        public List<TripConcatenationSpeedPoint> SpeedPoints { get; set; }
    }

    public class TripConcatenationSpeedPoint
    {

        public double Speed { get; set; }

        public double SpeedLimit { get; set; }

        public double? Latitude { get; set; }

        public double? Longitude { get; set; }

        public DateTime RecordTimeStamp { get; set; }

        public long RecordTimeStampEpochMs { get; set; }
    }
}
