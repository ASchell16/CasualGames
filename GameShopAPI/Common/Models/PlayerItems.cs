using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CSWeek3._1.Models
{
    public class PlayerItems
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public int PlayerID { get; set; }
        [Required]
        public int ItemID { get; set;  }
        public int Quantity { get; set; }

        public Player Player { get; set; }
        public Item Item { get; set; }

    }
}