using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

using System.ComponentModel.DataAnnotations.Schema;

namespace Week1Database
{
    class Program
    {
        static void Main(string[] args)
        {
            DatabaseContext db = new DatabaseContext();
            GameSession session = new GameSession();

            session.Start = DateTime.UtcNow;
            session.End = DateTime.UtcNow;
            foreach (var player in db.Players)
            {
                session.PlayerID = player.ID;

                //player.Email = "fake@fake.com";
                Console.WriteLine(player.FirstName + " " + player.LastName);
            }
            db.Sessions.Add(session);
            db.SaveChanges();
            Console.WriteLine(session.ID);

            session.End += TimeSpan.FromHours(10);
            db.SaveChanges();

            foreach (GameSession sess in db.Sessions)
            {
                Console.WriteLine(sess.Player.Username + ":" + 
                                 (sess.End - sess.Start).TotalMinutes);  
            }
            Console.ReadLine();
        }
    }

    //Model - Class that will be mapped onto database tables
    public class Player
    {
        //Attributes to apply restrictions to data
        [Key]
        public int ID { get; set; }
        [Required]
        [MinLength(2), MaxLength(25)]
        public string FirstName { get; set; }
        [Required]
        [MinLength(2), MaxLength(25)]
        public string LastName { get; set; }
        [Required]
        [MinLength(2), MaxLength(25)]
        public string Username { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public ICollection<GameSession> Sessions { get; set; }
    }

    // Game Sessions
    public class GameSession
    {
        [Key]
        public int ID { get; set; }
        // UTC
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        
        public Player Player { get; set; }

        //[ForeignKey("ID")]
        public int PlayerID { get; set; }
    }



    //Context -> Conections, Access to Tables, applies CRUD operations
    public class DatabaseContext : DbContext
    {
        //Tables
        public DbSet<Player> Players { get; set; }
        public DbSet<GameSession> Sessions { get; set; }
        public DatabaseContext()
            : base("DbConnection")//Connection String name stored in the App.config
        {

        }
    }
}
