using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Automile.Net
{
    public enum MainFuelType : byte
    {
        Diesel = 0,
        Petrol = 1,
        Ethanol = 2,
        Gas = 3,
        Hybrid = 4,
        Electric = 5,
        Methane = 6,
    }
}
