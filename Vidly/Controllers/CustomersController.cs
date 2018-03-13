using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {

        private ApplicationDbContext _context;


        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        
        // GET: Customers
        public ActionResult Index()
        {
            var customers = _context.Customers.Include(c => c.MembershipType).ToList();
           
            return View(customers);
        }


        //Details for one customer 
        public ActionResult Details(int id)
        {

            var customerDetails = _context.Customers.SingleOrDefault(c => c.Id== id);

            if (customerDetails == null)
               return HttpNotFound();

            return View(customerDetails);
        }

    }
}