namespace GameShopAPI.Migrations
{
    using CSWeek3._1.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<GameShopAPI.Models.GameShopAPIContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(GameShopAPI.Models.GameShopAPIContext context)
        {
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
            foreach (var item in items)
            {
                context.Items.AddOrUpdate(x => x.Name, item);
            }
        }
    }
}
