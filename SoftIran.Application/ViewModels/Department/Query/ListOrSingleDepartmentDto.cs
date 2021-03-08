using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftIran.Application.ViewModels.Department.Query
{
    public class DepartmentsDto : Pagenated
    {
        public ICollection<DepartmentDto> Dtos { get; set; }

    }

    public class DepartmentDto
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }
    }
}
