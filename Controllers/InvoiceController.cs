using Books.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Books.ViewModels;

namespace Books.Controllers
{
    public class InvoiceController : Controller
    {
        private readonly ApplicationDbContext _context;
        public InvoiceController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Invoice
        public ActionResult Index()
        {
            var invoices = _context.Invoices.ToList();
            return View(invoices);
        }

        public ActionResult Create()
        {
            var model = new InvoiceFormViewModel
            {
                Customers = _context.Customers.Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.FirstName }),
                Products = _context.Products.ToList(),
                InvoiceDate = DateTime.Now,
               
               
            };

            return View("InvoiceForm", model);
        }

        public ActionResult Save(InvoiceFormViewModel model , string Price,string Quantity)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Create");
            }
            Invoice nn = new Invoice()
            {
                CustomerId = model.CustomerId,
                InvoiceDate = DateTime.Now,
                InvoiceDiscount = model.InvoiceDiscount,
                //InvoiceDetails = model.InvoiceDetails.Select(d => new InvoiceDetail
                //{
                //    ProductId = d.ProductId,
                //    Quantity = d.Quantity,
                //    Price = d.Price,
                //}).ToList()
            };
            _context.Invoices.Add(nn);
            _context.SaveChanges();
            InvoiceDetail id = new InvoiceDetail()
            {
                InvoiceId = nn.InvoiceId,
                Price = decimal.Parse(Price),
                Quantity = int.Parse(Quantity),
            };

            _context.Invoices.Add(nn);
            _context.SaveChanges();
      


            return RedirectToAction("Index" );
        }


    }
}