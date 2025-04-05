using Books.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Books.ViewModels;
using System.Diagnostics;

namespace Books.Controllers
{
    public class ProductsController : Controller
    {

        private readonly ApplicationDbContext _context;
        public ProductsController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Product
        public ActionResult Index()
        {

           
            var products = _context.Products.Include(x => x.Category).ToList();
            return View(products);
        }


        [HttpGet]
        public ActionResult Create()
        {
            var categories = _context.Categories.ToList(); 
            var viewModel = new ProductFromViewModel
            {
                Categories = categories 
            };

            return View("ProductFrom", viewModel);
        }


        [HttpGet]
        public ActionResult Edit(int id)
        {
            var product = _context.Products.Find(id);
            if (product == null)
                return HttpNotFound();

            var categories = _context.Categories.ToList();
            var viewModel = new ProductFromViewModel
            {
                Name = product.Name,
                Categories = categories,
                Price = product.Price,
                CategoryId = product.CategoryId
            };

            return View("ProductFrom", viewModel);
        }

        [HttpPost]
        public ActionResult Save(ProductFromViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Create");

            }
            if (model.Id == 0)
            {
                var product = new Product()
                {
                    Name = model.Name,
                    Price = model.Price,
                    CategoryId = model.CategoryId

                };
                _context.Products.Add(product);
            }
            else
            {
                var product = _context.Products.Find(model.Id);
                if (product == null)
                    return HttpNotFound();

                product.Name = model.Name;
                product.Price = model.Price;
                product.CategoryId = model.CategoryId;
            }
            _context.SaveChanges();
            TempData["Message"] = "Done";

            return RedirectToAction("Index");
        }

    }
}