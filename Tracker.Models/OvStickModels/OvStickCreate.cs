using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracker.Models.OvStickModels
{
    public class OvStickCreate
    {
        [Required]
        [Display(Name = "Are you ovulating, according to the ovulation stick?")]
        public bool Ovulation { get; set; }
        [Required]
        [Display(Name = "Date of ovulation stick sse")]
        public DateTime DateOfUse { get; set; }
        public string Comments { get; set; }
    }
}
