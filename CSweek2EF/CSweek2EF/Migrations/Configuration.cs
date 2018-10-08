namespace CSweek2EF.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CSweek2EF.DatabaseContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(CSweek2EF.DatabaseContext context)
        {
            foreach (var player in context.Players)
                context.Players.Remove(player);

            context.SaveChanges();

            List<Player> players = new List<Player>();

            players.Add(
                new Player()
                {
                    firstName = "Mary",
                    lastName = "Sue",
                    userName = "msue",
                    highScore = "8",
                    scoreDate = DateTime.UtcNow
                });
            players.Add(
                new Player()
                {
                    firstName = "Joe",
                    lastName = "Joe",
                    userName = "JJ",
                    highScore = "10",
                    scoreDate = DateTime.UtcNow
                });
            players.Add(
                new Player()
                {
                    firstName = "Dave",
                    lastName = "Dave",
                    userName = "DD",
                    highScore = "100",
                    scoreDate = DateTime.UtcNow
                });
            players.Add(
                new Player()
                {
                    firstName = "Sue",
                    lastName = "Sue",
                    userName = "SS",
                    highScore = "1",
                    scoreDate = DateTime.UtcNow
                });
            players.Add(
                new Player()
                {
                    firstName = "Britanny",
                    lastName = "Britanny",
                    userName = "BB",
                    highScore = "250",
                    scoreDate = DateTime.UtcNow

                });

            context.Players.AddOrUpdate(players.ToArray());
        }
    }
}
