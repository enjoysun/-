using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LuoXun.Models;

namespace LuoXun.Models
{
    public class DbHelper
    {
        public SSOcontext _dbcontext = null;
        public object locker = new object();
        public SSOcontext userhelper
        {
            get
            {
                if (_dbcontext == null)
                {
                    lock (locker)
                    {
                        if (_dbcontext == null)
                        {
                            return new SSOcontext();
                        }
                    }
                }
                return _dbcontext;
            }
        }
    }
}