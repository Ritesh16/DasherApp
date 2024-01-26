namespace DasherApp.Model.Helper
{
    public class DailyDashFilterParams : PaginationParams
    {
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public string Location { get; set; } = "all";
    }
}
