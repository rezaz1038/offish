using Newtonsoft.Json;
using SoftIran.Application.ViewModels.Department.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftIran.Application.ViewModels.Identity.User.Query
{

    public class  UsersDto : Pagenated
    {
        public ICollection<UserDto> Dtos { get; set; }

    }

    public class UserDto
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("username")]
        public string UserName { get; set; }

        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }



        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("claims")]
        public List<string> Claims { get; set; }

        [JsonProperty("roles")]
        public List<string> Roles { get; set; }

        [JsonProperty("department")]
        public DepartmentDto Department { get; set; }
    }
}
