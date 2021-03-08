using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftIran.Application.ViewModels.Offish.Cmd
{
    public class UpsertActionEquipmentDeliveryCmd
    {
        public string OffishId { get; set; }
        public List<Equipment> Equipment { get; set; }
    }

    public class Equipment
    {
        public string Id { get; set; }
    }
}
