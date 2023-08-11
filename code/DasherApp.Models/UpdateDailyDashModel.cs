namespace DasherApp.Models
{
    public class UpdateDailyDashModel
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public double Amount { get; set; }
        public double Mileage { get; set; }
        public string Location { get; set; }
    }
}
