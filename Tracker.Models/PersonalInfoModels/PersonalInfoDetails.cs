using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracker.Data;

namespace Tracker.Models.PersonalInfoModels
{
    public class PersonalInfoDetails
    {
        public Guid UserID { get; set; }
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        [Display(Name = "Previous Pregnancies:")]
        public bool PreviousPregnancies { get; set; }
        [Display(Name = "Number of viable pregnancies (if applicable):")]
        public int? ViablePreg { get; set; }
        [Display(Name = "Number of failed or miscarried pregnancies(if applicable):")]
        public int? FailedPreg { get; set; }
        [Display(Name = "Number of terminated pregnancies (if applicable):")]
        public int? TerminatedPreg { get; set; }
        [Required]
        [Display(Name = "Reason for using this app:")]
        public ReasonUsing WhyUsing { get; set; }
        [Display(Name = "Relevant medical history (PCOS, Endometriosis, STI's, Pelvic injuries or infections, etc.):")]
        public string MedicalHistory { get; set; }
        [Display(Name = "Created Time")]

        public DateTimeOffset CreatedTime { get; set; }
        [Display(Name = "Modified Time")]

        public DateTimeOffset? ModifiedTime { get; set; }
    }
}
