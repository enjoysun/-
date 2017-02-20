using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace LuoXun.Models
{
    public class Userinfo
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public string UserAccount { get; set; }
        public string UserPassword { get; set; }
    }
}