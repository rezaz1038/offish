using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftIran.DataLayer.Models.Entities
{
    public class PGM:TEntity
    {
        public string Name { get; set; }
        public string  DepartmentId { get; set; }
        public ICollection<Offish>  Offishes { get; set; }
    }
}
