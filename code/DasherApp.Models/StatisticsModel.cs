using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DasherApp.Models
{
    public class StatisticsModel
    {
        public double TotalEarned { get; set; }
        public double TotalMileage { get; set; }
        public OutputModel HighestEarningDay { get; set; }

        public StatisticsModel()
        {
            HighestEarningDay= new OutputModel();   
        }
    }
}
