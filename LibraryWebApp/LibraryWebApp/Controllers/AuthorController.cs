using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryWebApp.Models;
using LibraryWebApp.Interfaces;
using LibraryWebApp.BusinessLogic;

namespace LibraryWebApp.Controllers
{
    public class AuthorController : Controller
    {
        private IAuthorManager authorManager;

        public AuthorController()
        {
            authorManager = new SqlAuthorManager();
        }

        public ActionResult Index()
        {
            var authors = authorManager.GetAll();

            return View(authors);
        }

        public ActionResult Details(int id)
        {
            var author = authorManager.Get(id);

            //Views/Author/Details.cshtml
            return View(author); //author - (@model in view)
        }

        // GET /author/add
        [HttpGet]
        public ActionResult Add(int? id)
        {
            if (id == null) return View();

            var auth = authorManager.Get(id.Value);

            //Views/Author/Add.cshtml
            return View(auth);
        }

        // POST /author/add + request body
        [HttpPost]
        public ActionResult Add(Author author)
        {
            if (ModelState.IsValid)
            {
                authorManager.Save(author);
                return Redirect("Index");
            }
            return View(author);
        }
    }
}