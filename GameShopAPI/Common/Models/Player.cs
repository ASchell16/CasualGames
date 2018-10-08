using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CSWeek3._1.Models
{
    public class Player
    {
        [Key]
        public int ID { get; set; }
        [MaxLength(50)]
        public string Username { get; set; }

        [DataType("decimal(18,2)")]
        public double Balance { get; set; }

        public ICollection<PlayerItems> Inventory { get; set; }
    }
}