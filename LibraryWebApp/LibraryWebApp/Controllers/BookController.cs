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

        public BookController()
        {
            bookManager = new SqlBookManager();
        }

        // GET: Book
        public ActionResult Index()
        {
            var books = bookManager.GetAll();

            return View(books);
        }
    }
}