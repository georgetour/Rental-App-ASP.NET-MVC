using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;
using System.Runtime.Caching;


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
        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Index()
        {
            if (MemoryCache.Default["Genres"]== null)
            {
                MemoryCache.Default["Genres"] = _context.Genres.ToList();
            }
            var genres = MemoryCache.Default["Genres"] as IEnumerable<Genre>;

            return View();
        }


        //Details for one customer 
        public ActionResult Details(int id)
        {

            var customerDetails = _context.Customers
                .Include(c => c.MembershipType)
                .SingleOrDefault(c => c.Id== id);

            if (customerDetails == null)
               return HttpNotFound();

            return View(customerDetails);
        }

        public ActionResult NewCustomer()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new CustomerFormViewModel
            {
                Customer = new Customer(),
                MembershipTypes = membershipTypes
            };

            return View("CustomerForm",viewModel);
        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };

            if (customer == null)
            {
                return HttpNotFound();

            }
            return View("CustomerForm",viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };
                return View("CustomerForm",viewModel);
            }
            
            if (customer.Id == 0)
                _context.Customers.Add(customer);
            else
            {
                var customerInDB = _context.Customers.Single(c => c.Id == customer.Id);

                customerInDB.Name = customer.Name;
                customerInDB.Birthdate = customer.Birthdate;
                customerInDB.MembershipTypeId = customer.MembershipTypeId;
                customerInDB.IsSubcribed = customer.IsSubcribed;
            }
            _context.SaveChanges();

            return RedirectToAction("Index","Customers");
        }

    }
}