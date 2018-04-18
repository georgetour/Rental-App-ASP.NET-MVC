using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Dtos;
using Vidly.Models;
using System.Data.Entity;

namespace Vidly.Controllers.Api
{
    public class CustomersController : ApiController
    {

        private ApplicationDbContext _context;

        //data from database 
        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        //GET /api/customers /api/customers
        [Authorize(Roles = RoleName.CanManageMovies)]
        public IEnumerable<CustomerDto>GetCustomers()
        {
            return _context.Customers
                .Include(c => c.MembershipType)
                .ToList()
                .Select(Mapper.Map<Customer,CustomerDto>);
        }

        //single customer /api/customers
        [Authorize(Roles = RoleName.CanManageMovies)]
        public IHttpActionResult GetCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
            {
                return NotFound();
            }
            return Ok(Mapper.Map<Customer,CustomerDto>(customer));
        }


        //create customer /api/customers
        [HttpPost]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public IHttpActionResult CreateCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);
            _context.Customers.Add(customer);
            _context.SaveChanges();

            customerDto.Id = customer.Id;

            //
            return Created(new Uri(Request.RequestUri + "/" + customer.Id), customerDto);
        }

        //update customer api/customers/1
        [HttpPut]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public void UpdateCustomer(int id, CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            //Get customer from database
            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            //Check if oject exists in db
            if (customerInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            Mapper.Map<CustomerDto, Customer>(customerDto, customerInDb);

            _context.SaveChanges();
        }


        //delete customer api/customers/1
        [HttpDelete]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public void DeleteCustomer(int id)
        {
            //Get customer from database
            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            //Check if oject exists in db
            if (customerInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            _context.Customers.Remove(customerInDb);
            _context.SaveChanges();
        }

    }
}
