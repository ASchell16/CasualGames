namespace CSWeek3._1.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Collections.Generic;
    using CSWeek3._1.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<CSWeek3._1.Models.CSWeek3_1Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(CSWeek3._1.Models.CSWeek3_1Context context)
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

            List<Player> players = new List<Player>
            {
                new Player(){
                    Username = "ASchell",
                    Balance = 100,
                },
                new Player(){
                    Username = "JJ",
                    Balance = 200,
                },
                new Player(){
                    Username = "GG",
                    Balance = 300.25,
                },

            };

            foreach (var player in players)
            {
                context.Players.AddOrUpdate(x => x.Username, player);
            };

            List<PlayerItems> playerItems = new List<PlayerItems>();
            foreach (var player in players)
            { 
                foreach (var item in items)
                {
                    PlayerItems pItems = new PlayerItems();
                    pItems.PlayerID = player.ID;
                    pItems.ItemID = item.ID;
                    pItems.Quantity = 10;

                    playerItems.Add(pItems);
                }
            };

            foreach (var playeritem in playerItems)
            {
                context.PlayerItems.AddOrUpdate(x => new { x.PlayerID, x.ItemID}, 
                                                playeritem);
            };


        }
    }
}
