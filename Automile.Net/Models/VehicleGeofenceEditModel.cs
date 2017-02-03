using System;
using System.ComponentModel.DataAnnotations;

namespace Automile.Net
{
    public class VehicleGeofenceEditModel
    {
        public DateTime? ValidFrom { get; set; }
        public DateTime? ValidTo { get; set; }
    }
}