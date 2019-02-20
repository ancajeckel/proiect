﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using LibraryWebApp.Models;
using LibraryWebApp.Interfaces;
using LibraryWebApp.BusinessLogic;

namespace LibraryWebApp.Controllers
{
    public class HomeController : Controller
    {
        private IAuthorManager authorManager;

        public HomeController()
        {
            authorManager = new SqlAuthorManager();
        }

        public ActionResult Index()
        {
            var authors = authorManager.GetAll();

            return View(authors);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

    }
}