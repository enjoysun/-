using LuoXun.Models;
using Newtonsoft.Json;
using Quartzdemo.Models;
using RedisHelp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LuoXun.Controllers
{
    public class SignInController : Controller
    {
        // GET: SignIn
        public SSOcontext db = new DbHelper().userhelper;
        public Stateinfo logininfo = new Stateinfo();
        public CookHelp cookhelper = new CookHelp();
        public RedisHelper redis = new RedisHelper(1);
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Userinfo user)
        {
            var usercookie = cookhelper.GetCookie("singininfo");

            if (ModelState.IsValid)
            {
                if (usercookie == null)
                {

                    var userinfo = db.Usercontext.FirstOrDefault(c => c.UserAccount == user.UserAccount);
                    if (userinfo != null)
                    {
                        if (userinfo.UserPassword == user.UserPassword)
                        {
                            logininfo.infocode = 1;
                            logininfo.infomessage = "登陆成功";
                            logininfo.infocache = userinfo.Name;
                            logininfo.userinfokey = Guid.NewGuid();
                            redis.StringSet<Userinfo>(logininfo.userinfokey.ToString(), userinfo, DateTime.Now.AddHours(1) - DateTime.Now);
                        }
                        else
                        {
                            logininfo.infocode = 0;
                            logininfo.infomessage = "密码错误";
                        }
                    }
                    else
                    {
                        logininfo.infocode = 0;
                        logininfo.infomessage = "账号错误";
                    }
                }
                else
                {
                    Guid rediskey = JsonConvert.DeserializeObject<Stateinfo>(usercookie.Value.Split('=')[1]).userinfokey;
                    Userinfo userinfo = redis.StringGet<Userinfo>(rediskey.ToString());
                    if (userinfo.UserAccount == user.UserAccount)
                    {
                        if (userinfo.UserPassword == user.UserPassword)
                        {
                            logininfo.infocode = 1;
                            logininfo.infomessage = "登陆成功";
                            logininfo.infocache = userinfo.Name;
                            logininfo.userinfokey = rediskey;
                        }
                        else
                        {
                            logininfo.infocode = 0;
                            logininfo.infomessage = "密码错误";
                            logininfo.infocache = null;
                            logininfo.userinfokey = rediskey;
                        }
                    }
                    else
                    {
                        logininfo.infocode = 0;
                        logininfo.infomessage = "账号错误";
                        logininfo.infocache = null;
                        logininfo.userinfokey = rediskey;
                    }
                }
            }
            string signinfo = JsonConvert.SerializeObject(logininfo);
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("info", signinfo);
            cookhelper.SetCookie(dic, DateTime.Now.AddHours(1), "singininfo");
            return Redirect("../Demo/Index.html");
        }
    }
}