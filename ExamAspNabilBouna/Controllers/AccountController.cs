using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using ExamAspNabilBouna.Models;

namespace ExamAspNabilBouna.Controllers
{
    public class AccountController : Controller
    {

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(User user)
        {
            if (user.Pass == user.rePass)
            {

                if (ModelState.IsValid)
                {
                    using (BDMembres db = new BDMembres())
                    {
                        db.user.Add(user);
                        db.SaveChanges();
                    }
                    ModelState.Clear();
                    ViewBag.Message = "Votre compte bien créé " + user.Login;
                }
            }
            else
            {
                ViewBag.Erreur = "Mots de pass incorrect.";
            }
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(String Login,String Pass)
        {
            if (ModelState.IsValid)
            {
                    try
                    {
                        using (BDMembres db = new BDMembres())
                        {
                            var usernow = db.user.Single(x => x.Login == Login && x.Pass == Pass).Login;
                            if (usernow != null)
                            {
                                Session["Login"] = Login;
                                Session["Pass"] = Pass;
                                return RedirectToAction("Profile");
                            }
                        }
                    }
                    catch
                    {
                        ViewBag.Erreur = "Username ou Mots de pass incorrect.";
                    }
            }
            return View();
        }

        public ActionResult Profile()
        {
            if (Session["Login"] != null && Session["Pass"] != null)
            {
                using (BDMembres db = new BDMembres())
                {
                    return View(db.user.ToList());
                }
            }
            else
            {
                return RedirectToAction("Login");
            }

            return View();
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon(); // it will clear the session at the end of request
            return RedirectToAction("index", "Home");
        }

    }
}