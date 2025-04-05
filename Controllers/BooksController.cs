using Books.Models;
using Books.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TLMS.WebApp.Authorization;

namespace Books.Controllers
{
    [Authorized]
    public class BooksController : Controller
    {   
        private readonly ApplicationDbContext _context;
        public BooksController()
        {
            _context = new ApplicationDbContext();            
        }
        // GET: Books

        public ActionResult Index()
        {
            var books = _context.Books.Include(x => x.Category).ToList();
            return View(books);
        }
        public ActionResult Create()
        {
            var viewModel = new BookFormViewModel()
            {
                Categories = _context.Categories.Where(x => x.IsActive).ToList()
            };

            return View("BookFrom",viewModel);
        }

        public ActionResult Save(BookFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Create");

            }
            if(model.Id == 0)
            {
                var book = new Book()
                {
                    Title = model.Title,
                    Author = model.Author,
                    CategoryId = model.CategoryId,
                    Description = model.Description

                };
                _context.Books.Add(book);
            }
            else
            {
                var book = _context.Books.Find(model.Id);
                if (book == null)
                    return HttpNotFound();

                book.Title = model.Title;
                book.Author = model.Author;
                book.CategoryId = model.CategoryId;
                book.Description = model.Description;
            }
            _context.SaveChanges();
            TempData["Message"] = "Done";

            return RedirectToAction("Index");

        }
        public ActionResult Details(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var book = _context.Books.Include(m => m.Category).SingleOrDefault(m => m.Id == id);

            if (book == null)
                return HttpNotFound();

            return View(book);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var book = _context.Books.Find(id);

            if (book == null)
                return HttpNotFound();

            var viewModel = new BookFormViewModel
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author,
                CategoryId = book.CategoryId,
                Description = book.Description,
                Categories = _context.Categories.Where(m => m.IsActive).ToList()
            };

            return View("BookFrom", viewModel);
        }

    }
}