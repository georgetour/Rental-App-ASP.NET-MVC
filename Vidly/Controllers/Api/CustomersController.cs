using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Models;

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
        public IEnumerable<Customer>GetCustomers()
        {
            return _context.Customers.ToList();
        }

        //single customer /api/customers
        public Customer GetCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return customer;
        }


        //create customer /api/customers
        [HttpPost]
        public Customer CreateCustomer(Customer customer)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            _context.Customers.Add(customer);
            _context.SaveChanges();

            return customer;
        }

        //update customer api/customers/1
        [HttpPut]
        public void UpdateCustomer(int id, Customer customer)
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
            customerInDb.Name = customer.Name;
            customerInDb.Birthdate = customer.Birthdate;
            customerInDb.IsSubcribed = customer.IsSubcribed;
            customerInDb.MembershipTypeId = customer.MembershipTypeId;

            _context.SaveChanges();
        }


        //delete customer api/customers/1
        [HttpDelete]
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
