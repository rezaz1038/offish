using Newtonsoft.Json;
using SoftIran.Application.ViewModels.EquipmentBrand.Query;
using SoftIran.Application.ViewModels.EquipmentPlace.Query;
using SoftIran.Application.ViewModels.EquipmentType.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftIran.Application.ViewModels.Equipment.Query
{
    public class EquipmentsDto : Pagenated
    {
        public ICollection<EquipmentDto> Dtos { get; set; }

    }

    public class EquipmentDto
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("technicalCode")]
        public string TechnicalCode { get; set; }

        [JsonProperty("amval")]
        public string Amval { get; set; }

        [JsonProperty("model")]
        public string Model { get; set; }

        [JsonProperty("serial")]
        public string Serial { get; set; }

        [JsonProperty("isActive")]
        public bool IsActive { get; set; }

        [JsonProperty("isInUse")]
        public bool IsInUse { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("place")]
        public EquipmentPlaceDto Place { get; set; }

        [JsonProperty("brand")]
        public EquipmentBrandDto Brand { get; set; }

        [JsonProperty("type")]
        public EquipmentTypeDto Type { get; set; }

    }
}
