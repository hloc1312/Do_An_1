using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QLNS.Models;

namespace QLNS.Controllers
{
    public class AccountController : Controller
    {
        QLyNhanSuEntities db = new QLyNhanSuEntities();
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult Login(User user)
        {
            var check = db.Users.Where(s => s.UserName == user.UserName && s.PassWord == user.PassWord).FirstOrDefault();
            if (check == null)
            {
                ViewBag.Error = "Sai thông tin đăng nhập";
                return View("Login");
            }
            else
            {
                db.Configuration.ValidateOnSaveEnabled = false;
                Session["UserName"] = user.UserName;
                Session["Password"] = user.PassWord;
                return RedirectToAction("Index", "Home");
            }
        }

    }
}