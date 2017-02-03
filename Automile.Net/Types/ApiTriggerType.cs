namespace Automile.Net
{
    public enum ApiTriggerType : byte
    {
        FirmwareConfigurationUpdate = 0,
        FirstTripWelcomeMessage = 1,
        MILStatusOnOff = 2,
        DTCCodes = 3,
        DeviceConnect = 4,
        DeviceDisconnect = 5,
        DiagnosticError = 6,
        DiagnosticError2 = 7,
        DeviceStillNotConnected = 8,
        EngineCoolantTemperatureThresholdReached = 9,
        SpeedNotification = 10,
        VehicleInformationFound = 11,
        BatteryShutdown = 12,
        Geofence = 13,
        MonthlyTripJournalReport = 14,
        TripEnd = 15,
        TripStart = 16,
        OdometerEnd = 17,
        Accident = 18,
        VehicleInspectionPeriodStartReminder = 20,
        VehicleInspectionInPeriodReminder = 21,
        SummaryOfFirstTrips = 22,
        OdometerEvent = 24,
        WeatherForecast = 25,
        PendingDTCCodes = 26,
        TripWithUnknownDriver = 36,
    }
}
