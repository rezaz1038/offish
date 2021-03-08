using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftIran.Application.ViewModels.Offish.Cmd
{
   public class UpsertActionRegisterCmd
    {
        public string  Id { get; set; }
        public string OffishId{ get; set; }
       
        public string PgmId { get; set; }
        public string CategoryId { get; set; }
        public List<Avamel> Avamel { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndTime { get; set; }
        public DateTime EndDate { get; set; }
    }

    public class Avamel
    {
        public string UserId { get; set; }
        public string RoleId { get; set; }
    }

}
