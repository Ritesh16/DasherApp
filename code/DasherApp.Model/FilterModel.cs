namespace DasherApp.Model
{
    public class FilterModel : PaginationModel
    {
        private string _location = "all";
        public bool SearchWithoutDates { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public string Location 
        { 
            get => _location.ToLower();
            set => _location = value;
        }

        public FilterModel()
        {
            Location = "All";
            SearchWithoutDates = true;
            ToDate = DateTime.Now;
            FromDate = new DateTime(ToDate.Year, ToDate.Month, 1);
        }

        public FilterModel(DateTime fromDate)
        {
            Location = "All";
            SearchWithoutDates = true;
            ToDate = DateTime.Now;
            FromDate = fromDate;
        }

        public FilterModel(DateTime fromDate, DateTime toDate, string location)
        {
            Location = location;
            SearchWithoutDates = false;
            ToDate = toDate;
            FromDate = fromDate;
        }
    }
}
