using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracker.Data
{
    public class CervicalMucous
    {
        [Key]
        public int CMID { get; set; }

        [ForeignKey(nameof(PersonalInfo))]
        public Guid UserID { get; set; }
        public virtual PersonalInfo PersonalInfo { get; set; }
        [Required]
        [Display(Name = "Does mucous indicate ovulation?")]
        public bool Ovulation { get; set; }
        [Display(Name = "Description of mucous:")]
        public string MucousDescription { get; set; }

    }
}
