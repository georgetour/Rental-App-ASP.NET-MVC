using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class MovieFormViewModel
    {
        public IEnumerable<Genre> Genres { get; set; }
        public int? Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Release Date field is required.")]
        public DateTime? ReleaseDate { get; set; }


        [Required]
        [Range(1, 10)]
        public byte? Stock { get; set; }


        [Display(Name = "Genre")]
        [Required(ErrorMessage = "Genre field is required.")]
        public int? GenreId { get; set; }


        public string Title {
           get {
                return Id != 0 ? "Edit Movie" : "New Movie";
           }

        }

        //Default for when creating new Movie so hidden field is populated
        public MovieFormViewModel()
        {
            Id = 0;
        }

        //Initialiazing te ViewModel based on the movie
        public MovieFormViewModel(Movie movie)
        {
            Id = movie.Id;
            Name = movie.Name;
            ReleaseDate = movie.ReleaseDate;
            Stock = movie.Stock;
            GenreId = movie.GenreId;
        }
    }
}