using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automile.Net
{
    public enum ApiUserDeviceCertType : byte 
    {
        IOSProduction = 0,
        IOSDeveloper = 1,
        IOSEnterpriseProduction = 3,
        IOSEnterpriseDeveloper = 4
    }
}
