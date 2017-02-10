using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automile.Net
{
    public class VehicleHealth
    {
        public int VehicleId { get; set; }
        public int? PeriodFrom { get; set; }
        public int? PeriodTo { get; set; }
        public BatteryEventStatusType LastBatteryStatus { get; set; }
        public BatteryEvent LastBatteryWarning { get; set; }
        public List<BatteryEvent> BatteryEventsForSelectedPeriod { get; set; }
        public MILEvent LastMILEvent { get; set; }
        public List<MILEvent> MILEventsForSelectedPeriod { get; set; }
        public DTCEvent LastDTCEvent { get; set; }
        public DTCEvent LastPendingDTCEvent { get; set; }

        public List<DTCEvent> DTCEventsForSelectedPeriod { get; set; }
        public List<DTCEvent> PendingDTCEventsForSelectedPeriod { get; set; }

        public static BatteryEventStatusType GetBatteryStatusTypeFromEventType(int eventType)
        {
            switch (eventType)
            {
                case 132:
                    return BatteryEventStatusType.Low;
                case 144:
                    return BatteryEventStatusType.Critical;
                case 145:
                    return BatteryEventStatusType.Shutdown;
                case 146:
                    return BatteryEventStatusType.Normal;
                default:
                    throw new ApplicationException("Unsupported battery status type");
            }
        }
    }


    public enum BatteryEventStatusType : byte
    {
        Normal,
        Low,
        Critical,
        Shutdown
    }
    public enum MileageIndicatorEventStatusType : byte
    {
        Off,
        On
    }
    public class BatteryEvent
    {
        public DateTime Occured { get; set; }

        public double? Latitude { get; set; }

        public double? Longitude { get; set; }

        public BatteryEventStatusType BatteryStatus { get; set; }
    }

    public class MILEvent
    {
        public DateTime Occured { get; set; }

        public MileageIndicatorEventStatusType MILStatus { get; set; }

        public int? MILDistance { get; set; }

        public decimal? CLRDistanceUntilToday { get; set; }

        public byte? NumberOfDTCs { get; set; }

        public double? Latitude { get; set; }

        public double? Longitude { get; set; }
    }

    public class DTCEvent
    {
        public DateTime Occured { get; set; }

        public List<DTCEventDetail> DTCEventDetails { get; set; }

        public double? Latitude { get; set; }

        public double? Longitude { get; set; }
    }
    public class DTCEventDetail
    {
        public string DTC { get; set; }

        public string FaultLocation { get; set; }

        public string ProbableCause { get; set; }
    }



}
