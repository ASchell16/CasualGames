using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

using System.ComponentModel.DataAnnotations.Schema;

namespace CSweek2EF
{
#if WINDOWS || LINUX
    /// <summary>
    /// The main class.
    /// </summary>
    public static class Program
    {
        
        [STAThread]
        static void Main()
        {
            using (var game = new Game1())
                game.Run();
        }
    }

    public class Player
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [MaxLength(25)]
        public string firstName { get; set; }
        [Required]
        [MaxLength(25)]
        public string lastName { get; set; }
        [Required]
        [MaxLength(25)]
        public string userName { get; set; }
        [Required]
        public String highScore { get; set; }
        [Required]
        public DateTime scoreDate { get; set; }


    }

    public class DatabaseContext : DbContext
    {
        public DbSet<Player> Players { get; set; }

    }
#endif
}
