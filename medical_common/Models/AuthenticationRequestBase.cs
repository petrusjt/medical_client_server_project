using System;
using System.Collections.Generic;
using System.Text;

namespace medical_common.Models
{
    public class AuthenticationRequestBase
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
