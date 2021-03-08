using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftIran.Application.ViewModels.Equipment.Upsert
{
    public class UpsertEquipmentCmd
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

        [JsonProperty("placeId")]
        public string PlaceId { get; set; }

        [JsonProperty("brandId")]
        public string BrandId { get; set; }

        [JsonProperty("typeId")]
        public string TypeId { get; set; }
    }
}
