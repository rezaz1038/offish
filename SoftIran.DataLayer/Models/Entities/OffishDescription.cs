using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftIran.DataLayer.Models.Entities
{
   public class OffishDescription : TEntity
    {
       
        public string Description { get; set; }

        public string ActionId { get; set; }

        public  OffishAction Action { get; set; }

    }
}
