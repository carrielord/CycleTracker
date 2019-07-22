using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracker.Models.BBTModels
{
   public class BBTUpdate
    {
        public int BBTID { get; set; }
        [Required]
        [MinLength(4, ErrorMessage = "Please enter a Basal Body Temperature with accuracy to the hundredth's place (two digits behind the decimal point).")]
        [MaxLength(5, ErrorMessage = "This value appears to be outside of the acceptable range. Please enter a temperature with accuracy to the hundredth's place only (two digits behind the decimal point)")]
        public double Temperature { get; set; }
        [Required]
        [Display(Name = "Date temperature was taken")]
        public DateTime DateOfTemp { get; set; }
        public string Comments { get; set; }
    }
}
