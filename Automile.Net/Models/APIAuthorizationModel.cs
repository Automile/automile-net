using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automile.Net
{
    public class APIAuthorizationModel
    {
           public int APIAuthorizationId { get; set;}
           public DateTime IssueDate  { get; set;}
           public int  APIClientId  { get; set;}
           public int  UserId  { get; set;}
           public string ScopesDelimitedBySpaces  { get; set;}
           public DateTime? ExpirationDateUtc { get; set; }
    }
}
