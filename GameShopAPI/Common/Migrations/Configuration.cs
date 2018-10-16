namespace Common.Migrations
{
    using Common.Models;
    using CSWeek3._1.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CSWeek3_1Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(CSWeek3_1Context context)
        {
            // Creates new list of items for database 
            var items = new List<Item>
            {
                new Item(){
                    Name = "Small Health",
                    Cost = 50,
                    Category = ItemCategory.Health,
                    iconUrl = "~/Content/Images/health_icon.png" },
                new Item(){
                    Name = "Small Stamina",
                    Cost = 50,
                    Category = ItemCategory.Stamina,
                    iconUrl = "~/Content/Images/stamina_icon.png" },
                new Item(){
                    Name = "Small Magic",
                    Cost = 50,
                    Category = ItemCategory.Magic,
                    iconUrl = "~/Content/Images/magic_icon.png"},

            };

            // for all items in item list add to the database
            foreach (var item in items)
            {
                context.Items.AddOrUpdate(x => x.Name, item);
            }

            // Force to save items first then add vendors
            context.SaveChanges();
            
            // creates new list of vendors
            var vendors = new List<Vendor>()
            {
                new Vendor()
                {
                    Name = "Bragg The Rich",
                    IconName = "BraggFace",
                }
            };

            // for all vendors in vendor list add to batabase
            foreach (var vendor in vendors)
            {
                context.Vendors.AddOrUpdate(x => x.Name, vendor);
            }

            // Create new List of vendor items
            var vendorItems = new List<VendorItem>();

            // for all vendors in vendor list
            foreach (var vendor in vendors)
            {
                // for all items in item list
                foreach (var item in items)
                {
                    // add item id and vendor id to vendor items
                    vendorItems.Add(new VendorItem() { VendorID = vendor.ID, ItemID = item.ID });
                }
            }

            // for all items in vendoritems add the items to a database
            foreach (var vendor in vendorItems)
            {
                context.VendorItems.AddOrUpdate(x => new { x.ItemID, x.VendorID }, vendor);
            }

        }
    }
}
