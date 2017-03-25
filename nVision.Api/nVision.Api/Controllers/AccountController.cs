using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using nVision.Api.Models.interfaces;
using nVision.Api.Models.responses;

namespace nVision.Api.Controllers
{
    public class AccountController : ApiController
    {
        private readonly IAccountWorkFlow _accountWorkFlow;

        public AccountController(IAccountWorkFlow accountWorkFlow)
        {
            _accountWorkFlow = accountWorkFlow;
        }

        [HttpGet]
        [ActionName("accounts")]
        public AccountResponse GetAllAccounts(string cardId)
        {
            var accounts = _accountWorkFlow.GetAccounts(cardId);
            return new AccountResponse
            {
                Accounts = accounts
            };
        }
    }
}
