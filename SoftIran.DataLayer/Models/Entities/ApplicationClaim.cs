using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace SoftIran.DataLayer.Models.Entities
{
   public  class ApplicationClaim :ClaimsIdentity
    {
        public string Description { get; set; }
    }
}
