using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftIran.DataLayer.Models.Entities
{
    public class OffishAction : TEntity
    {
       // public string ActionMakerId { get; set; }
        public string ActionType { get; set; }

        public string ActionDescription { get; set; }
        public string SenderId { get; set; }
        public ApplicationUser Sender { get; set; }

        public string OffishId { get; set; }
        public Offish Offish { get; set; }

        public ICollection<Equipment> Equipment { get; set; }
    }
}
