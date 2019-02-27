using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryWebApp.Interfaces;
using LibraryWebApp.Models;
using LibraryWebApp.BusinessLogic;

namespace LibraryWebApp.Controllers
{
    public class BookController : Controller
    {
        private IBookManager bookManager;
        private IPublisherManager publisherManager;

        public BookController()
        {
            bookManager = new SqlBookManager();
            publisherManager = new SqlPublisherManager();
        }

        // GET: /book
        public ActionResult Index()
        {
            var books = bookManager.GetAll();

            return View(books);
        }

        // GET: /book/details/{id} 
        public ActionResult Details(int id)
        {
            var book = bookManager.Get(id);

            return View(book);
        }

        public  void SetSessionPublishers()
        {
            var publishers_list = publisherManager.GetAll();

            List<SelectListItem> listItems = new List<SelectListItem>();
            foreach (var item in publishers_list)
            {
                listItems.Add(new SelectListItem
                {
                    Text = item.Name,
                    Value = item.PublisherId.ToString()
                });
            }
            Session["Publishers"] = listItems;
        }

        // GET /book/addedit
        [HttpGet]
        public ActionResult CreateEdit(int? id)
        {
            SetSessionPublishers();

            if (id == null) return View();

            var book = bookManager.Get(id.Value);

            return View(book);
        }

        // POST /book/addedit + request body
        [HttpPost]
        public ActionResult CreateEdit(Book book)
        {
            SetSessionPublishers();

            if (ModelState.IsValid)
            {
                bookManager.Save(book);
                return RedirectToAction("Index", "Book");
            }
            else
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors);
            }

            return View(book);
        }
    }
}