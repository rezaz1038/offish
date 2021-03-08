using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftIran.Application.ViewModels.EquipmentBrand.Query
{
    public class EquipmentBrandsDto : Pagenated
    {
        public ICollection<EquipmentBrandDto> Dtos { get; set; }

    }

    public class EquipmentBrandDto
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }
    }
}
