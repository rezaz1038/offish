using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftIran.DataLayer.Models.Entities
{
    public class OffishCategory:TEntity
    {
        public string Name { get; set; }
        public ICollection<Offish>   Offishes { get; set; }
    }
}
