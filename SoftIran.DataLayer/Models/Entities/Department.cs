using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftIran.DataLayer.Models.Entities
{
    public class Department:TEntity
    {
        public string Name { get; set; }

        public ICollection<ApplicationUser>  Users { get; set; }
        public ICollection<PGM>   PGMs { get; set; }
    }
}
