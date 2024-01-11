namespace DasherApp.Model
{
    public class DailyDashModelV2
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public double Amount { get; set; }
        public double Mileage { get; set; }
        public LocationModel Location { get; set; }
        public bool IsActive { get; set; }
        public double HourlyRate { get; set; }
        public int DeliveryCount { get; set; }
        public List<DashDetailModel> DashDetails { get; set; }

        public DailyDashModelV2()
        {
            DashDetails = new List<DashDetailModel>();
        }
    }
}
