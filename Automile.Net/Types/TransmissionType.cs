using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automile.Net
{
    public enum TransmissionType : byte
    {
        Manual = 0,
        Automatic = 1,
        Variomatic = 2,
    }
}
