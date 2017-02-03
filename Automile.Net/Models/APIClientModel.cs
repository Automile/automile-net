using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automile.Net
{
    public class APIClientModel
    {
             public int APIClientId { get; set; } 
             public string APIClientIdentifier { get; set; } 
             public string Name { get; set; } 
             public string ScopesDelimitedBySpaces { get; set; }
             public string ClientType { get; set; } 
    }
}
