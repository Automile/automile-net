using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automile.Net
{
    public enum IMEIDeviceType : byte
    {
        [Description("Automile Box 1 (2G)")]
        AutomileBox_750 = 0,
        [Description("Automile Box 2 (3G)")]
        AutomileBox_860 = 1,
        [Description("Automile AnyTrack")]
        AutomileAnyTrack_1 = 2,
        [Description("Automile Mobile Tracking")]
        AutomileMobile = 3
    }
}
