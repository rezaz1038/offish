using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftIran.Application.ViewModels.OffishCategoy.Query
{

    public class OffishCategoriesDto : Pagenated
    {
        public ICollection<OffishCategoryDto> Dtos { get; set; }
    }


    public class OffishCategoryDto
    {
       
        public string Id { get; set; }
             
        public string Name { get; set; }


    }
}
