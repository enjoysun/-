using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Quartzdemo.Models
{
    public class CookHelp
    {
        private string name;   //Cookie名称

        //是否已经被创建
        public bool IsCreate
        {
            get
            {
                HttpCookie Cookie = HttpContext.Current.Request.Cookies[this.name];
                if (Cookie != null)
                    return true;
                else
                    return false;
            }
        }

        //设置Cookies
        public void SetCookie(Dictionary<string, string> Values, DateTime Expires,string name)
        {
            HttpCookie Cookie = new HttpCookie(name);
            foreach (string key in Values.Keys)
            {
                Cookie.Values.Add(key, Values[key]);
            }
            Cookie.Expires = Expires;
            HttpContext.Current.Response.Cookies.Add(Cookie);
        }

        //获取Cookie
        public HttpCookie GetCookie(string name)
        {
            return HttpContext.Current.Request.Cookies[name];
        }

        //清空Cookie
        public void ClearCookie(string name)
        {
            HttpCookie Cookie = HttpContext.Current.Request.Cookies[name];
            Cookie.Expires = DateTime.Now.AddDays(-1);
            HttpContext.Current.Response.Cookies.Add(Cookie);
        }
    }
}