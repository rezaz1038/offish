using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftIran.Insfrastrcture
{
   public class Utilities
    {
        public class Singleton
        {
            public IConfiguration Configuration { get; set; }
            public IHttpContextAccessor httpContextAccessor { get; set; }

            private Singleton() { }
            private static Singleton _instance;

            public static Singleton Instance
            {
                get
                {
                    if (_instance == null)
                        _instance = new Singleton();

                    return _instance;
                }
            }
        }
    }
}
