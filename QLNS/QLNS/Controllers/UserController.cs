using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QLNS.Models;

namespace QLNS.Controllers
{
    public class UserController : Controller
    {
        QLyNhanSuEntities database = new QLyNhanSuEntities();
        // GET: User
        public ActionResult Index(string _name)
        {
            if (_name == null)
            {
                return View(database.Users.ToList());

            }
            else
            {
                return View(database.Users.Where(s => s.UserName.Contains(_name)).ToList());
            }
        }
        // create user
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(User user)
        {
            database.Users.Add(user);
            database.SaveChanges();
            return RedirectToAction("Index", "User");
        }
        public ActionResult Details(int id)
        {
            return View(database.Users.Where(s => s.Id == id).FirstOrDefault());
        }
        public ActionResult Edit(int id)
        {
            return View(database.Users.Where(s => s.Id == id).FirstOrDefault());
        }
        [HttpPost]
        public ActionResult Edit(User user)
        {
            database.Entry(user).State = System.Data.Entity.EntityState.Modified;
            database.SaveChanges();
            return RedirectToAction("Index", "User");
        }
        public ActionResult Delete(int id)
        {
            return View(database.Users.Where(s => s.Id == id).FirstOrDefault());
        }
        [HttpPost]
        public ActionResult Delete(User user,int id)
        {
            try
            {
                user = database.Users.Where(s => s.Id == id).FirstOrDefault();
                database.Users.Remove(user);
                database.SaveChanges();
                return RedirectToAction("Index", "User");
            }
            catch
            {
                return Content("Không tồn tại User để xóa");
            }
        }

    }
}