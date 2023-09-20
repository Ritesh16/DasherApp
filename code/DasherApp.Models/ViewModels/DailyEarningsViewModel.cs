namespace DasherApp.Models.ViewModels
{
    public class DailyEarningsViewModel: BaseViewModel
    {
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public PagedListModel<DailyEarningsModel> DailyEarnings { get; set; }
        public DailyEarningsViewModel()
        {
            FromDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            ToDate = DateTime.Now;
            DailyEarnings = new PagedListModel<DailyEarningsModel>();
        }
    }
}
