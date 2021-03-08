using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftIran.Application.ViewModels.Identity.User.Cmd
{
    public class ChangePasswordCmd
    {
        //[JsonProperty("id")]
       // public string Id { get; set; }

       // [JsonProperty("username")]
       // public string UserName { get; set; }

        [JsonProperty("currentPassword")]
        public string CurrentPassword { get; set; }

        [JsonProperty("newPassword")]
        public string NewPassword { get; set; }
    }
}
