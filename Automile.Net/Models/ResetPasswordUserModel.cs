using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Automile.Net
{
    public class ResetPasswordUserModel
    {
        public string Email { get; set; }
        public ApiResetPasswordType ResetPasswordType { get; set; }
    }
}
