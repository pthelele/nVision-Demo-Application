using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using nVision.Api.Models.models;

namespace nVision.Api.Models.dataaccess
{
    public class DatabeseContext : DbContext
    {
        public DatabeseContext() : base("bankConnection")
        {
            
        }
        public DbSet<Card> Cards { get; set; }
    }
}