using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using nVision.Api.Models.models;

namespace nVision.Api.Models.interfaces
{
    public interface IAccountWorkFlow
    {
        IEnumerable<Account> GetAccounts(string cardNumber);
    }
}
