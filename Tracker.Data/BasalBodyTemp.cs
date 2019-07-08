using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracker.Data
{
    public class BasalBodyTemp
    {
        [Key]
        public int BBTID { get; set; }

        [ForeignKey(nameof(PersonalInfo))]
        public Guid UserID { get; set; }
        public virtual PersonalInfo PersonalInfo { get; set; }
        [Required]
        public double Temperature { get; set; }
        [Required]
        [Display(Name = "Date temperature was taken")]
        public DateTime DateOfTemp { get; set; }
        public string Comments { get; set; }
    }
}
