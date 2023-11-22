using System.ComponentModel.DataAnnotations;

namespace DasherApp.Model
{
    public class DailyDashStartEndTimeModel
    {
        [Required]
        public TimeSpan StartTime { get; set; }
        [Required]
        public TimeSpan EndTime { get; set; }

        [Range(1, 1000, ErrorMessage = "Please enter Amount.")] 
        public double Amount { get; set; }
        
        [Range(1, 1000, ErrorMessage = "Please enter Mileage.")]
        public double Mileage { get; set; }
        public string Restaurant { get; set; }

    }
}
