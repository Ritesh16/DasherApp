using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Principal;

namespace DasherApp.Data.Entity
{
    [Table("Location")]
    public class Location
    {
        [Key]
        public int Id { get; set; }
        
        [StringLength(100)]
        public string Name { get; set; }
        public DateTime RowCreateDate { get; set; }
        public DateTime RowUpdateDate { get; set; }

        public ICollection<DailyDash> DailyDashes { get; set; }
    }
}
