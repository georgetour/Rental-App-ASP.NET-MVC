using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Vidly.Models;
using Vidly.Dtos;
using AutoMapper;
using System.Data.Entity;

namespace Vidly.Controllers.Api
{
    public class RentalsController : ApiController
    {
        private ApplicationDbContext _context;


        //data from database
        public RentalsController()
        {
            _context = new ApplicationDbContext();
        }

        //Post api/rentals create rental
        [HttpPost]
        public IHttpActionResult CreateRental(RentalDto rentalDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var rental = Mapper.Map<RentalDto, Rental>(rentalDto);
            _context.Rental.Add(rental);
            _context.SaveChanges();

            rentalDto.Id = rental.Id;
            return Created(new Uri(Request.RequestUri + "/"), rentalDto);
        }



    }
}
