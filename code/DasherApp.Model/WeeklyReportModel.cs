namespace DasherApp.Model
{
    public class WeeklyReportModel
    {
        public int WeekId { get; set; }
        public double Total { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
