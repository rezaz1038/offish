using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftIran.Application.ViewModels.OffishCategoy.Query
{
   public class OffishCategoriesQuery : BasedFilter
    {
        //search base
        [JsonProperty("name")]
        public string Name { get; set; }
    
    }

}
