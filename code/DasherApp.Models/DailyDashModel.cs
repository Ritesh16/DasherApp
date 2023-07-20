namespace DasherApp.Models
{
    public class DailyDashModel
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public double Amount { get; set; }
        public double Mileage { get; set; }
        public string Restaurant { get; set; }
        public string Location { get; set; }
        public bool IsActive { get; set; }
        public double HourlyRate { get; set; }
    }
}