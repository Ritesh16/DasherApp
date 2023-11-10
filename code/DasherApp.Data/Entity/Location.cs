using System.ComponentModel.DataAnnotations;

namespace DasherApp.Data.Entity
{
    public class Location
    {
        [Key]
        public int Id { get; set; }
        
        [StringLength(100)]
        public string Name { get; set; }
        public DateTime RowCreateDate { get; set; }
        public DateTime RowUpdateDate { get; set; }
    }
}
