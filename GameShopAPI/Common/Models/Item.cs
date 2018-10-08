using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace CSWeek3._1.Models
{
    public enum ItemCategory
    {
         Health,
         Stamina,
         Magic
    }
    public class Item
    {
        public ItemCategory Category { get; set; }
        [Key]
        public int ID { get; set; }
        [DataType("decimal(18,2)")]
        public double Cost { get; set; }
        public string iconUrl { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }



    }
}