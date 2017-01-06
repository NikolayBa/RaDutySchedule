﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RaDutySchedule.Models
{
    public class ScheduledDuty
    {
        [Key]
        public int SchDutyID { get; set; }
       public  DayOfWeek Day { get; set; }
       public  TimeSpan Time { get; set; }

       public string Name { get; set; }

        
    }
}
