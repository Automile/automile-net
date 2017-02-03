using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automile.Net
{
    public class UserModel
    {
        public int UserId { get; set; }
        public Guid UserGuid { get; set; }
        public string UserName { get; set; }
        public int ContactId { get; set; }

    }
}
