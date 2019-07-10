using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracker.Data;

namespace Tracker.Models.PersonalInfoModels
{
    public class PersonalInfoUpdate
    {
        public Guid UserId { get; set; }
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        [Display(Name = "Previous Pregnancies?")]
        public bool PreviousPregnancies { get; set; }
        [Display(Name = "Please enter number of viable pregnancies (if applicable):")]
        public int? ViablePreg { get; set; }
        [Display(Name = "Please enter number of failed or miscarried pregnancies(if applicable):")]
        public int? FailedPreg { get; set; }
        [Display(Name = "Please enter number of terminated pregnancies (if applicable):")]
        public int? TerminatedPreg { get; set; }
        [Required]
        [Display(Name = "Please select your reason for using this app:")]
        public ReasonUsing WhyUsing { get; set; }
        [Display(Name = "Please enter any relevant medical history (PCOS, Endometriosis, STI's, Pelvic injuries or infections, etc.):")]
        public string MedicalHistory { get; set; }
        public DateTimeOffset CreatedTime { get; set; }
        public DateTimeOffset? ModifiedTime { get; set; }
    }
}
