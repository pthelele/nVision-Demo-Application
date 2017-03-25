using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using nVision.Api.Models.responses;

namespace nVision.Api.Models.interfaces
{
    public interface IAuthenticateWorkFlow
    {
        AuthenticationResponse Authwnticate(string cardNumber, string pin);
    }
}
