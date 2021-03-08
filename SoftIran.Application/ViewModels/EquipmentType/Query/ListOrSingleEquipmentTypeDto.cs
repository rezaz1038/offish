using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftIran.Application.ViewModels.EquipmentType.Query
{
    public class EquipmentTypesDto : Pagenated
    {
        public ICollection<EquipmentTypeDto> Dtos { get; set; }

    }

    public class EquipmentTypeDto
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }
    }
}
