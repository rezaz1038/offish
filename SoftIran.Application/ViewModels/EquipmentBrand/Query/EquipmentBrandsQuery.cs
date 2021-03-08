using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftIran.Application.ViewModels.EquipmentBrand.Query
{
    public class EquipmentBrandsQuery : BasedFilter
    {
        //search base on name
        public string Name { get; set; }
    }
}
