using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RaDutySchedule.Models
{
    public class Duty
    {
        [Key]
        public string DutyID { get; set; }
        public DateTime DutyDate { get; set; }
        public int Hours { get; set; }

     [ForeignKey("UserId")]
     public string aubgID { get; set; }
    }
}
