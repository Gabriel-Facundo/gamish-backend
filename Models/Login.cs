using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Login
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class LoginResult
    {
        public long? Id { get; set; }
        public string Username { get; set; }
        public string Status { get; set; }
    }

    public class LoginCheck
    {
        public string Message { get; set; }
        public string Status { get; set; }
    }
}
