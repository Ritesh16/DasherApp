namespace DasherApp.Model
{
    public class WeekDayEarningModel
    {
        public DayOfWeek DayOfWeek { get; set; }
        public double Amount { get; set; }
        public double TotalDashes { get; set; }
        public double TotalTimeSpend { get; set; }
        public double HourlyRate { get; set; }
    }
}
