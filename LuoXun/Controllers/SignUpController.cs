using LuoXun.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LuoXun.Controllers
{
    public class SignUpController : Controller
    {
        public SSOcontext db = new DbHelper().userhelper;
        public Stateinfo logininfo = new Stateinfo();
        public ActionResult Index()
        {
            return View();
        }
        // GET: SignUp
        [HttpPost]
        public ActionResult Index(Userinfo user)
        {

            if (ModelState.IsValid)
            {
                db.Usercontext.Add(user);
                db.SaveChanges();
            }
            return RedirectToAction("Login","SignIn",user);
        }
    }
}