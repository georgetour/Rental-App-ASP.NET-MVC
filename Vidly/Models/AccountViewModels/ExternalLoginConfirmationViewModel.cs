using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models.AccountViewModels
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [StringLength(50)]
        [Display(Name = "Phone")]
        public string Phone { get; set; }


        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Driving License")]
        public string DrivingLicense { get; set; }
    }
}