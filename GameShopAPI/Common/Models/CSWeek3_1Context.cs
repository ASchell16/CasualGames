using Common.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CSWeek3._1.Models
{
    public class CSWeek3_1Context : DbContext
    {
        
        public CSWeek3_1Context() : base("name = DbConnection")
        {
        }

        public DbSet<Item> Items { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<PlayerItems> PlayerItems { get; set; }
        public DbSet<Vendor> Vendors { get; set; }
        public DbSet<VendorItem> VendorItems { get; set; }
    }
}
