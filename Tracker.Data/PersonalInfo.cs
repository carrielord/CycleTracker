using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracker.Data
{
    public enum ReasonUsing
    {
        [Display(Name = "For Basic Tracking Only")] 
        Tracking,
        [Display(Name = "For Tracking Related to Infertility")]
        Infertility,
        [Display(Name = "For Trying to Get Pregnant")]
        Pregnancy,
        [Display(Name = "For Pregnancy Prevention")]
        Prevention
    }
    public class PersonalInfo
    {
        [Key]
        public Guid UserID { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        [Display(Name = "Previous Pregnancies?")]
        public bool PreviousPregnancies { get; set; }
        [Display(Name = "Please enter number of viable pregnancies (if applicable):")]
        public int ViablePreg { get; set; }
        [Display(Name = "Please enter number of failed or miscarried pregnancies(if applicable):")]
        public int FailedPreg { get; set; }
        [Display(Name = "Please enter number of terminated pregnancies (if applicable):")]
        public int TerminatedPreg { get; set; }
        [Required]
        [Display(Name = "Please select your reason for using this app:")]
        public ReasonUsing WhyUsing { get; set; }
        [Display(Name = "Please enter any relevant medical history (PCOS, Endometriosis, STI's, Pelvic injuries or infections, etc.):")]
        public string MedicalHistory { get; set; }
    }
}
