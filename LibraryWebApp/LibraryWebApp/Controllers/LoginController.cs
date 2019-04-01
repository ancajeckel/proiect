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
    public class LoginController : Controller
    {
        private IMemberManager memberManager;

        public LoginController()
        {
            memberManager = new SqlMemberManager();
        }

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Authorize(Member member)
        {
            var memberDetails = memberManager.Get(member.EmailAddress, member.Password);

            if (memberDetails == null)
            {
                member.LoginErrorMessage = "Invalid email address or password";
                return View("Index", member);
            }
            else
            {
                Session["MemberId"] = memberDetails.MemberId;
                Session["MemberName"] = memberDetails.FirstName;
                return RedirectToAction("Index", "Home");
            }
        }

        public ActionResult Details(int? id)
        {
            Member member;
            if (id == null)
            {
                if (System.Web.HttpContext.Current.Session["MemberId"] != null)
                {
                    id = Convert.ToInt32(Session["MemberId"].ToString());
                    member = memberManager.Get(id.Value);
                }
                else
                {
                    return View();
                }
            }
            member = memberManager.Get(id.Value);

            return View(member);
        }

        public ActionResult Edit(int id)
        {
            var member = memberManager.Get(id);
            return View(member);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Edit(Member member)
        {
            if (ModelState.IsValid)
            {
                memberManager.Save(member);
                return RedirectToAction("Details", "Login");
            }
            return View(member);
        }

        [HttpGet]
        public ActionResult Add(int? id)
        {
            if (id == null) return View();

            var member = memberManager.Get(id.Value);

            return View(member);
        }

        [HttpPost]
        public ActionResult Add(Member member)
        {
            if (ModelState.IsValid)
            {
                memberManager.Save(member);
                return RedirectToAction("Details", "Login", new { id = member.MemberId});
            }
            return View(member);
        }
    }
}