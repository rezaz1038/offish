using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftIran.Application.ViewModels.Identity.Role.Query
{
   public class RolesQuery : BasedFilter
    {
       

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
