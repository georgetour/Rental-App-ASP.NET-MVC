using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.Dtos
{
    public class RentalDto
    {
        public int Id { get; set; }

        //What date the movie was rent
        public DateTime DateRent { get; set; }

        //What date the movie was returned
        public DateTime? DateReturned { get; set; }

        public Movie Movie { get; set; }
        public int MovieId { get; set; }

        public Customer Customer { get; set; }
        public int CustomerId { get; set; }

    }
}