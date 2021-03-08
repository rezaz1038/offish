using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftIran.DataLayer.Models.Entities
{
    public class OffishUser:TEntity
    {
        public string UserId { get; set; }
        public string RoleId { get; set; }
        public   ApplicationRole  Role { get; set; }
        public   ApplicationUser  User { get; set; }
        public string OffishId { get; set; }
        public Offish Offish  { get; set; }
    }
}
