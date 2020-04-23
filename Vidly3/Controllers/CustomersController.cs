using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly3.Models;
using Vidly3.ViewModels;

namespace Vidly3.Controllers
{
    public class CustomersController : Controller
    {
        // Declare Customers Here Since No DB
        public List<Customer> customers = new List<Customer>
        {
            new Customer { Id = 1, Name = "John Smith" },
            new Customer { Id = 2, Name = "Mary Williams" }
        };

        // GET: Customers
        public ActionResult Index()
        {
            var customerViewModel = new CustomerViewModel
            {                
                Customers = customers
            };

            return View(customerViewModel);
        }

        [Route("Customers/Details/{customerId}")]
        public ActionResult Details(int customerId)
        {
            var customer = customers.FirstOrDefault(c => c.Id == customerId);

            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }
    }
}