using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class RentalFormViewModel
    {
        public int? Id { get; set; }

        public IEnumerable<Movie> Movie { get; set; }
        public int? MovieId { get; set; }

        public IEnumerable<Customer> Customer { get; set; }
        public int? CustomerId { get; set; }

        public DateTime DateRent { get; set; }
        public DateTime? DateReturned { get; set; }

        //Default for when creating new Movie so hidden field is populated
        public RentalFormViewModel()
        {
            Id = 0;
        }

        //Initialiazing the ViewModel based on the rental
        public RentalFormViewModel(Rental rental)
        {
            Id = rental.Id;
            MovieId = rental.MovieId;
            CustomerId = rental.CustomerId;
            DateRent = rental.DateRent;
            DateReturned = rental.DateReturned;
        }
        

    }
}