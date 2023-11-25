using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DasherApp.Data.Entity
{
    public class Restaurant
    {
        [Key]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public DateTime OrderCreateTime { get; set; }
        public DateTime OrderPickupTime { get; set; }
        public DateTime OrderDeliveryTime { get; set; }
        
        [StringLength(200)]
        public string Name { get; set; }
        public int LocationId { get; set; }
        public DateTime RowCreateDate { get; set; }
        public DateTime RowUpdateDate { get; set; }
        
        [ForeignKey("LocationId")]
        public Location Location { get; set; }
    }
}
