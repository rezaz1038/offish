using Newtonsoft.Json;
using SoftIran.Application.ViewModels.Department.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftIran.Application.ViewModels.Pgm.Query
{
    public class PgmsDto : Pagenated
    {
        public ICollection<PgmDto> Dtos { get; set; }
    }


    public class PgmDto
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }


        [JsonProperty("department")]
        public DepartmentDto Department { get; set; }
    }

}



