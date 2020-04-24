using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;
using Vidly3.Models;
using Vidly3.ViewModels;

namespace Vidly3.Controllers
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
            base.Dispose(disposing);
            _context.Dispose();
        }

        // GET: Customers
        public ActionResult Index()
        {
            var customers = _context.Customers.Include(c => c.MembershipType).ToList();

            var customerViewModel = new CustomerViewModel
            {                
                Customers = customers
            };

            return View(customerViewModel);
        }

        [Route("Customers/Details/{customerId}")]
        public ActionResult Details(int customerId)
        {
            var customer = _context.Customers.FirstOrDefault(c => c.Id == customerId);

            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }
    }
}