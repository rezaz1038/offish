using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftIran.Application.ViewModels.Equipment.Query
{
    public class EquipmentsQuery : BasedFilter
    {
        //search base on name
        public string Name { get; set; }
        public string TechnicalCode { get; set; }
        public string Amval { get; set; }
        public string Model { get; set; }
        public string Serial { get; set; }
        public bool IsActive { get; set; }
        public bool IsInUse { get; set; }

        public string PlaceId { get; set; }
        public string BrandId { get; set; }
        public string TypeId { get; set; }

    }
}
