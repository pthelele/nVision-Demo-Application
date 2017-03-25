using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace nVision.Api.Models.responses
{
    public class AuthenticationResponse
    {
        public string ResponseMessage { get; set; }
        public bool Status { get; set; }
        public bool Blocked { get; set; }
    }
}