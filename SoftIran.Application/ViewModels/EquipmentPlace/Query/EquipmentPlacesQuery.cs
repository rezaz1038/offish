using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftIran.Application.ViewModels.EquipmentPlace.Query
{
    public class EquipmentPlacesQuery : BasedFilter
    {
        //search base on name
        public string Name { get; set; }
    }
}
