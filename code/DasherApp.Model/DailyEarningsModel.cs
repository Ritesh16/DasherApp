namespace DasherApp.Model
{
    public class DailyEarningsModel
    {
        public DateTime Date { get; set; }
        public double Amount { get; set; }
        public double Mileage { get; set; }
        public double TotalMinutes { get; set; }
        public double HourlyRate { get; set; }
    }
}
