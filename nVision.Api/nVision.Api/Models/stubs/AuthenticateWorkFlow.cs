using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using nVision.Api.Models.interfaces;
using nVision.Api.Models.responses;

namespace nVision.Api.Models.stubs
{
    public class AuthenticateWorkFlow : IAuthenticateWorkFlow
    {
        public AuthenticationResponse Authwnticate(string cardNumber, string pin)
        {
            return new AuthenticationResponse();
        }
    }
}