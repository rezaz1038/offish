using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftIran.DataLayer.Models.Entities
{
    public class Offish:TEntity
    {
        public string Code { get; set; }  //affish number
       
        public DateTime StartDate { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime EndTime { get; set; }

        public DateTime  ExitDate { get; set; }
        public DateTime  ExitTime { get; set; }
        public DateTime  BackDate { get; set; }
        public DateTime  BackTime { get; set; }
        public string    PGMId { get; set; }
        public PGM PGM  { get; set; }
        public string DirectorId { get; set; }

        public bool IsFinal { get; set; }
        public bool IsDone { get; set; }

        public string ActoinId { get; set; }
        public ICollection<OffishAction>  OffishActions { get; set; }




        public string CategoryId { get; set; }
        public OffishCategory Category { get; set; }

   
        

        public string TemplateId { get; set; }
        public OffishTemplate  OffishTemplate { get; set; }

       
        public ICollection<OffishUser>   OffishUsers { get; set; }

    }
}
