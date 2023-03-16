namespace DasherApp.Models
{
    public class FilterModel
    {
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }

        public string Location { get; set; }

        public FilterModel()
        {
            ToDate = DateTime.Now;
            FromDate = new DateTime(ToDate.Year, ToDate.Month, 1);
        }
    }
}
