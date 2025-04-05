using Books.Models;
using Books.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Books.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ApplicationDbContext _context;
        public CustomerController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Customer
        public ActionResult Index()
        {
            var customers = _context.Customers.ToList();
            return View(customers);
        }

        public ActionResult Create()
        {
            return View("CustomerForm");
        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.Find(id);

            if(customer == null)
            {
                return HttpNotFound();

            }

            CustomerViewModel viewModel = new CustomerViewModel()
            {
                Id = customer.Id,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Phone = customer.Phone,
                Email = customer.Email,
                Gender =(Books.ViewModels.GenderEnum)customer.Gender
            };

            return View("CustomerForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(CustomerViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("CustomerForm", model);
            }
            if (model.Id == 0)
            {
                Customer customer = new Customer()
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Address = model.Address,
                    Gender = (Books.Models.GenderEnum)model.Gender,  
                    Email = model.Email

                };
                _context.Customers.Add(customer);
            }
            else
            {
                var customer = _context.Customers.Find(model.Id);
                if (customer == null)
                    return HttpNotFound();

                customer.FirstName = model.FirstName;
                customer.LastName = model.LastName;
                _context.SaveChanges();
                TempData["Message"] = "Done";
            }
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}