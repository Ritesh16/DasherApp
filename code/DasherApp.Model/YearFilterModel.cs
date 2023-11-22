namespace DasherApp.Model
{
    public class YearFilterModel
    {
        public int Year { get; set; }

        public YearFilterModel()
        {
            Year = DateTime.Now.Year;
        }
    }
}
