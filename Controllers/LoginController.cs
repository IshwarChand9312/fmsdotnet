using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using fms.Models;
using Microsoft.AspNetCore.Http;

namespace fms.Controllers
{
    public class LoginController : Controller
    {
        private readonly ACE42023Context db = new();
        private readonly ISession session; //httpContextAccessor.HttpContext.Session;

        
        public IActionResult login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult login(IUser obj)
        {
            var result=(from i in db.IUsers
                       where i.UserId ==obj.UserId && i.UserPassword==obj.UserPassword
                       select i).SingleOrDefault();
            if (result != null)
            {
              HttpContext.Session.SetString("Username", result.UserId.ToString());
              HttpContext.Session.SetString("user_name", result.UserName);
                return RedirectToAction("GetBooking", "Booking");
            }
            else
                return View();

        }

        
        public IActionResult register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult register(IUser obj)
        {
            db.IUsers.Add(obj);
            db.SaveChanges();
            return RedirectToAction("login");
        }

        public IActionResult logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("login", "Login");
        }
    }
}
