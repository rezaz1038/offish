using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftIran.Application.ViewModels.EquipmentPlace.Query
{
    public class EquipmentPlacesDto : Pagenated
    {
        public ICollection<EquipmentPlaceDto> Dtos { get; set; }

    }

    public class EquipmentPlaceDto
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }
    }
}
