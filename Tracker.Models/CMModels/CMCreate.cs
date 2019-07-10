using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracker.Models.CMModels
{
    public class CMCreate
    {
        [Required]
        [Display(Name = "Does mucus indicate ovulation?")]
        public bool Ovulation { get; set; }
        [Required]
        [Display(Name = "Date")]
        public DateTime ObservationDate { get; set; }
        [Display(Name = "Description of mucus:")]
        public string MucusDescription { get; set; }
    }
}
