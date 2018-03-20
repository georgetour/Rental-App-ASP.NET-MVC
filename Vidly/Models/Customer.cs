using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Must not be empty")]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubcribed { get; set; }

        public MembershipType MembershipType { get; set; }

        [Display (Name = "Membership Type")]
        public byte MembershipTypeId { get; set; }

        [Min18YearsIfMember]
        public DateTime? Birthdate { get; set; }

    }
}