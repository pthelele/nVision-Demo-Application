using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace nVision.Api.Models.models
{
    public class Card
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string CardNumber { get; set; }
        public string Pin { get; set; }
        public bool Bloacked { get; set; }
        public int NumberOfFailedLogging { get; set; }
    }
}