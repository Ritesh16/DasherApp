using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DasherApp.Data.Entity
{
    public class DashDetail
    {
        [Key]
        public int Id { get; set; }

        [StringLength(200)]
        public string Restaurant { get; set; }
        public DateTime OrderCreateTime { get; set; }
        public DateTime OrderPickupTime { get; set; }
        public DateTime OrderDeliveryTime { get; set; }        
        public int DailyDashId { get; set; }
        public DateTime RowCreateDate { get; set; }
        public DateTime RowUpdateDate { get; set; }

        [ForeignKey("DailyDashId")]
        public DailyDash DailyDash { get; set; }

    }
}
