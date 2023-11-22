using System.ComponentModel.DataAnnotations;

namespace DasherApp.Model
{
    public class DailyDashAddModel
    {
        [Required]
        public DateTime DateTime { get; set; }
        [Required]
        public string Location { get; set; }
        public bool IsActive { get; set; }

        public List<DailyDashStartEndTimeModel> DashTimes { get; set; }
        
        public DailyDashAddModel()
        {
            DashTimes = new List<DailyDashStartEndTimeModel>();
            DashTimes.Add(new DailyDashStartEndTimeModel());
            DateTime = DateTime.Now;
            IsActive = true;
            Location = "Middletown";
        }
    }
}
