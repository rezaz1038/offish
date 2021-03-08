using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftIran.DataLayer.Models.Entities
{
    public  class Equipment:TEntity
    {
        public string TechnicalCode  { get; set; }
        public string Name { get; set; }
        public string Amval { get; set; }
        public string Model { get; set; }
        public string Serial  { get; set; }
        public bool IsActive { get; set; }
        public bool IsInUse { get; set; }
        public string Description { get; set; } 
        public string PlaceId{ get; set; }

        public EquipmentPlace   Place { get; set; }

        public string BrandId { get; set; }
        public EquipmentBrand Brand  { get; set; }

        public string TypeId { get; set; }
        public EquipmentType Type { get; set; }

        public ICollection<OffishAction>   OffishActions { get; set; }
    }
}
