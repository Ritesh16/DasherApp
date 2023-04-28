using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DasherApp.Models
{
    public class WeekDayEarningModel
    {
        public DayOfWeek DayOfWeek { get; set; }
        public double Amount { get; set; }
        public double TotalDashes { get; set; }
    }
}
