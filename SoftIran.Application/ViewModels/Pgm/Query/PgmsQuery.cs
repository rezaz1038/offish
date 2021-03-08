using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftIran.Application.ViewModels.Pgm.Query
{
    public class PgmsQuery : BasedFilter
    {
        //search base
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("departmentId")]
        public string DepartmentId { get; set; }
    }
}
