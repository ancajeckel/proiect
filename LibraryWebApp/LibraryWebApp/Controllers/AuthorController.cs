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
    }
}