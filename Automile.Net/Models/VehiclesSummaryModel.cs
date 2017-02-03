using System.Collections.Generic;

namespace Automile.Net
{
    public class VehiclesSummaryModel
    {
        public VehiclesSummaryModel()
        {
            DistanceReports = new List<DistanceReportModel>();
            FuelReports = new List<FuelReportModel>();
            TravelTimeReports = new List<TravelTimeReportModel>();
            CO2Reports = new List<CO2ReportModel>();
            IdleTimeReports = new List<IdleTimeReportModel>();
        }

        public List<DistanceReportModel> DistanceReports { get; set; }
        public List<FuelReportModel> FuelReports { get; set; }
        public List<TravelTimeReportModel> TravelTimeReports { get; set; }
        public List<CO2ReportModel> CO2Reports { get; set; }
        public List<IdleTimeReportModel> IdleTimeReports { get; set; }

        public class DistanceReportModel : VehicleSummaryReportBase
        {
            public decimal? BusinessDistanceInKilometers { get; set; }
            public decimal? PersonalDistanceInKilometers { get; set; }
            public decimal? OtherDistanceInKilometers { get; set; }

        }

        public class FuelReportModel : VehicleSummaryReportBase
        {
            public decimal? BusinessFuelInLiters { get; set; }
            public decimal? PersonalFuelInLiters { get; set; }
            public decimal? OtherFuelInLiters { get; set; }
        }

        public class TravelTimeReportModel : VehicleSummaryReportBase
        {
            public int? BusinessTravelTimeInMinutes { get; set; }
            public int? PersonalTravelTimeInMinutes { get; set; }
            public int? OtherTravelTimeInMinutes { get; set; }
        }

        public class CO2ReportModel : VehicleSummaryReportBase
        {
            public decimal? BusinessCO2InGrams { get; set; }
            public decimal? PersonalCO2InGrams { get; set; }
            public decimal? OtherCO2InGrams { get; set; }
        }

        public class IdleTimeReportModel : VehicleSummaryReportBase
        {
            public int? BusinessIdleTimeInMinutes { get; set; }
            public int? PersonalIdleTimeInMinutes { get; set; }
            public int? OtherIdleTimeInMinutes { get; set; }

        }
    }

    public class VehicleSummaryReportBase
    {
        public int Period { get; set; }
    }
}
