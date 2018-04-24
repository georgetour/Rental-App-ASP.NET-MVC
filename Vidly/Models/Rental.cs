using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Rental
    {
        public int Id { get; set; }

        [Required]
        public Customer Customer { get; set; }

        [Required]
        public Movie Movie { get; set; }

        //What date the movie was rent
        public DateTime DateRent { get; set; }

        //What date the movie was returned
        public DateTime? DateReturned { get; set; }


    }
}