using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracker.Data
{
    public class CervicalMucus
    {
        [Key]
        public int CMID { get; set; }

        [ForeignKey(nameof(PersonalInfo))]
        public Guid UserID { get; set; }
        public virtual PersonalInfo PersonalInfo { get; set; }
        [Required]
        [Display(Name = "Does mucus indicate ovulation?")]
        public bool Ovulation { get; set; }
        [Required]
        [Display(Name ="Date")]
        public DateTime ObservationDate { get; set; }
        [Display(Name = "Description of mucus:")]
        public string MucusDescription { get; set; }
        public DateTimeOffset CreatedTime { get; set; }
        public DateTimeOffset? ModifiedTime { get; set; }

    }
}
