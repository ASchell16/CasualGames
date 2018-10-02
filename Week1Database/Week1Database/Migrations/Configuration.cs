namespace Week1Database.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Week1Database.DatabaseContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(Week1Database.DatabaseContext context)
        {
            foreach (var player in context.Players)
                context.Players.Remove(player);

            context.SaveChanges();

            List<Player> players = new List<Player>();

            players.Add(
                new Player()
                {
                    FirstName = "Mary",
                    LastName = "Sue",
                    Username = "msue",
                    Email = "msue@itsligo.ie"
                });

            context.Players.AddOrUpdate(players.ToArray());
        }
    }
}
