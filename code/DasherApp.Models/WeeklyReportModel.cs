using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DasherApp.Models
{
    public class WeeklyReportModel
    {
        public int WeekId { get; set; }
        public double Total { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
