using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using CSWeek3._1.Models;

namespace Common.Models
{
    public class VendorItem
    {
        //PK
        [Key]
        public int ID { get; set; }
        //FK
        [Required]
        public int VendorID { get; set; }
        [Required]
        public int ItemID { get; set; }
        //Navigation Properties
        [JsonIgnore]
        public Vendor Vendor { get; set; }
        [JsonIgnore]
        public Item Item { get; set; }
    }
}
