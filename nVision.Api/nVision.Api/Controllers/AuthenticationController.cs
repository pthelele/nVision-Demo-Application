using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using nVision.Api.Models;
using nVision.Api.Models.interfaces;
using nVision.Api.Models.responses;
using Newtonsoft.Json;

namespace nVision.Api.Controllers
{
    public class AuthenticationController : ApiController
    {
        private readonly IAuthenticateWorkFlow _authentication;

        public AuthenticationController(IAuthenticateWorkFlow authentication)
        {
            _authentication = authentication;
        }

        [HttpPost]
        public AuthenticationResponse Authenticate([FromBody] string authenticationdetails)
        {
            var authenticationModel = JsonConvert.DeserializeObject<AuthenticationViewModel>(authenticationdetails);
            var response = _authentication.Authwnticate(authenticationModel.CardNumber,
                authenticationModel.Pin);
            return response;
        }
    }
}
