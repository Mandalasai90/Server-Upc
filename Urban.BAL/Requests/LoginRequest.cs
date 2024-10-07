using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Urban.BAL.Requests
{
    public class LoginRequest
    {
        public string mobileNumber { get; set; }
    }

    public class VerifyOTPRequest
    {
        public string mobileNumber { get; set; }
        public int otp { get; set; }
    }
}
