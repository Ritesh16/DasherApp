﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DasherApp.Data.Entity
{
    public class DailyDash
    {
        [Key]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public double Amount { get; set; }
        public double Mileage { get; set; }
        public int LocationId { get; set; }
        public int TotalDelivery { get; set; }
        public bool IsActive { get; set; }
        public DateTime RowCreateDate { get; set; }
        public DateTime RowUpdateDate { get; set; }
        
        [ForeignKey("LocationId")]
        public Location Location { get; set; }
        public DailyDash()
        {
            IsActive = true;
            LocationId = 1;
        }
    }
}
