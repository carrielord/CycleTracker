using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracker.Data
{
    public class OvulationStick
    {
        [Key]
        public int OvStickID { get; set; }

        [ForeignKey(nameof(PersonalInfo))]
        public Guid UserID { get; set; }
        public virtual PersonalInfo PersonalInfo { get; set; }
        [Required]
        [Display(Name = "Are you ovulating?")]
        public bool Ovulation { get; set; }
        public string Comments { get; set; }
    }
}
