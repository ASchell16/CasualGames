using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace GameShopAPI.Models
{
    public class GameShopAPIContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public GameShopAPIContext() : base("name=GameShopAPIContext")
        {
        }

        public System.Data.Entity.DbSet<CSWeek3._1.Models.Item> Items { get; set; }

        public System.Data.Entity.DbSet<Common.Models.Vendor> Vendors { get; set; }

        public System.Data.Entity.DbSet<Common.Models.VendorItem> VendorItems { get; set; }
    }
}
