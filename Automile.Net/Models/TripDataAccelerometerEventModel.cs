using System;
using System.Collections.Generic;

namespace Automile.Net
{
    public class TripDataAccelerometerEventModel
    {
        public TripDataAccelerometerEventModel()
        {
            AccelerometerEvents = new List<AccelerometerEventModel>();
            AccelerometerEventsSummary = new List<AccelerometerEventSummaryModel>();
        }

        public List<AccelerometerEventModel> AccelerometerEvents { get; set; }
        public List<AccelerometerEventSummaryModel> AccelerometerEventsSummary { get; set; } 
    }

    public class AccelerometerEventModel
    {
        public Guid? EventId { get; set; }
        public double? AccelerationX { get; set; }
        public double? AccelerationY { get; set; }
        public double? AccelerationZ { get; set; }
        public int SampleNumber { get; set; }
        public TripAccelerometerEventType AccelerometerEventType { get; set; }
        public DateTime RecordTimeStamp { get; set; }
        public int? IndexRelativeTimeToEvent { get; set; }        
    }

    public class AccelerometerEventDetailsModel
    {
        public Guid? EventId { get; set; }
        public double? AccelerationX { get; set; }
        public double? AccelerationY { get; set; }
        public double? AccelerationZ { get; set; }
        public int SampleNumber { get; set; }
        public TripAccelerometerEventType AccelerometerEventType { get; set; }
        public DateTime RecordTimeStamp { get; set; }
        public int? IndexRelativeTimeToEvent { get; set; }
    }

    public class AccelerometerEventSummaryModel
    {
        public Guid? EventId { get; set; }
        public TripAccelerometerEventType AccelerometerEventType { get; set; }
        public DateTime RecordTimeStamp { get; set; }
    }
}