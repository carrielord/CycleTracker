using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracker.Models.CycleModels
{
    public class CycleDetails
    {
        public int CycleID { get; set; }
        [Required]
        [Display(Name = "Cycle Start Date")]
        public DateTime DateStarted { get; set; }
        [Display(Name = "Cycle End Date")]
        public DateTime DateEnded { get; set; }
        public string Comments { get; set; }
        [Display(Name = "Created Time")]

        public DateTimeOffset CreatedTime { get; set; }
        [Display(Name = "Modified Time")]

        public DateTimeOffset? ModifiedTime { get; set; }
    }
}
