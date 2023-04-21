namespace DasherApp.Models
{
    public class StatisticsModel
    {
        public double TotalEarned { get; set; }
        public double TotalMileage { get; set; }
        public double HourlyRate { get; set; }
        public OutputModel HighestEarningDay { get; set; }
        public OutputModel HighestMileageDay { get; set; }

        public StatisticsModel()
        {
            HighestEarningDay= new OutputModel();   
            HighestMileageDay= new OutputModel();
        }
    }
}
