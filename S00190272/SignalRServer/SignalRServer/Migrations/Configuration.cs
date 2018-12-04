namespace SignalRServer.Migrations
{
    using SignalRServer.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SignalRServer.Models.GameContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(SignalRServer.Models.GameContext context)
        {
            context.Players.AddOrUpdate(new Player[]
            {
                new Player
                {
                    Username = "Alex"
                },

                new Player
                {
                    Username = "Steve"
                },

                new Player
                {
                    Username = "Joe"
                },

                new Player
                {
                    Username = "Bob"
                }
            });

        }
    }
}
