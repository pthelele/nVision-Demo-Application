using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using nVision.Api.Models.models;

namespace nVision.Api.Models.responses
{
    public class AccountResponse
    {
        public IEnumerable<Account> Accounts { get; set; }
    }
}