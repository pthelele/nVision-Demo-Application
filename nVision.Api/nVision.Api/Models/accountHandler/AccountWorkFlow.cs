using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using nVision.Api.Models.interfaces;
using nVision.Api.Models.models;
using nVision.Api.Models.dataaccess;

namespace nVision.Api.Models.accountHandler
{
    public class AccountWorkFlow : IAccountWorkFlow
    {
        private readonly DatabeseContext _context;

        public AccountWorkFlow()
        {
            _context = new DatabeseContext();
        }

        public IEnumerable<Account> GetAccounts(string cardNumber)
        {
            var cardId = Guid.Parse(cardNumber);
            var accounts = _context.Accounts.Where(account => account.CardId == cardId).ToList();
            return accounts;
        }
    }
}