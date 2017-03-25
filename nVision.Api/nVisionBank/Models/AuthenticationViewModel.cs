using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace nVisionBank.Models
{
    public class AuthenticationViewModel
    {
        [Required(ErrorMessage = "the card number is required")]
        public string CardNumber { get; set; }

        [Required(ErrorMessage = "the pin code is required")]
        public string Pin { get; set; }
    }
}