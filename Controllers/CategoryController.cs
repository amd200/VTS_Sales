using Books.Models;
using Books.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TLMS.WebApp.Authorization;

namespace Books.Controllers
{
    [Authorized]
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CategoryController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Category
        public ActionResult Index()
        {
            var categories = _context.Categories.ToList();
            return View(categories);
        }

        // GET: Category/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Category/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View("CategoryForm");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(CategoryViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("CategoryForm", model);
            }
           if(model.Id == 0)
            {
                Category category = new Category()
                {
                    Name = model.Name,
                    IsActive = model.IsActive
                };
                _context.Categories.Add(category);
            }
            else
            {
                var category = _context.Categories.Find(model.Id);
                if (category == null)
                    return HttpNotFound();

                category.Name = model.Name;
                category.IsActive = model.IsActive;
                _context.SaveChanges();
                TempData["Message"] = "Done";
            }
                _context.SaveChanges();
            return View("CategoryForm");
        }


        // GET: Category/Edit/5

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var category = _context.Categories.Find(id);
            if (category == null)
                return HttpNotFound();

            CategoryViewModel cat = new CategoryViewModel()
            {
                Name = category.Name,
                IsActive = category.IsActive
            };

            return View("CategoryForm", cat);
        }

       



    }
}
