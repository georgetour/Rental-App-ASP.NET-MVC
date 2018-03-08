using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        List<Customer> customers = new List<Customer>
            {
                new Customer() {Id =1, Name = "John Smith"},
                new Customer() {Id = 2, Name = "Mary Doe" }
            };



        // GET: Customers
        public ActionResult Index()
        {
            
            var viewModel = new RandomMovieViewModel
            {
                Customers = customers
            };


            return View(viewModel);
        }


        //Details for one customer 
        public ActionResult Details(int id)
        {

            var customerDetails = customers.SingleOrDefault(c => c.Id== id);

            if (customerDetails == null)
               return HttpNotFound();

            return View(customerDetails);
        }




    }
}