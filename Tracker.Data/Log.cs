using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracker.Data
{
    public class Log
    {
        [Key]
        public int LogID { get; set; }
        [ForeignKey(nameof(PersonalInfo))]
        public Guid UserID { get; set; }
        public virtual PersonalInfo PersonalInfo { get; set; }
        public string ItemLogged { get; set; }
        public DateTime DateLogged { get; set; }
    }
}
