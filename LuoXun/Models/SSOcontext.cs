using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace LuoXun.Models
{
    public class SSOcontext : DbContext
    {
        public SSOcontext():base("name=SSO")
        {

        }
        public DbSet<Userinfo> Usercontext { get; set; }
    }
}