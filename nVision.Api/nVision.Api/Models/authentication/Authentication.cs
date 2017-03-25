using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using nVision.Api.Models.dataaccess;
using nVision.Api.Models.interfaces;
using nVision.Api.Models.responses;

namespace nVision.Api.Models.authentication
{
    public class Authentication : IAuthenticateWorkFlow
    {
        private DatabeseContext _context;

        public Authentication()
        {
            _context = new DatabeseContext();
        }

        public AuthenticationResponse Authwnticate(string cardNumber, string pin)
        {
            var card = _context.Cards.FirstOrDefault(c => c.CardNumber == cardNumber);
            if (card != null)
            {
                if (!card.Bloacked)
                {

                    if (card.Pin == pin)
                    {
                        return new AuthenticationResponse
                        {
                            Blocked = card.Bloacked, ResponseMessage = "success", Status = true ,
                            CardId = card.Id
                            
                        };
                    }
                    else
                    {
                        card.NumberOfFailedLogging++;
                        if (card.NumberOfFailedLogging >= 3)
                        {
                            card.Bloacked = true;
                        }
                        _context.Cards.AddOrUpdate(card);
                        _context.SaveChanges();
                        return new AuthenticationResponse { Blocked = card.Bloacked, ResponseMessage = card.Bloacked ? "sorry your card is blocked please visist the branch" :
                            "Invalid pin", Status = false };
                    }
                }
                return new AuthenticationResponse { Blocked = true, ResponseMessage = "sorry your card is blocked please visist the branch", Status = false };
            }
            return new AuthenticationResponse { Blocked = true, ResponseMessage = "Card does not exisist", Status = false };
        }
    }
}