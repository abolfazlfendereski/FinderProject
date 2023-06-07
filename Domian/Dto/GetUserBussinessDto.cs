using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinderProject.Domian.Dto
{
   public class GetUserBussinessDto
    {
        public List<ProdoctbriefDto> ProdoctbriefDtos { get; set; }
        public List<CategoryCount> CategoryCounts { get; set; }
    }
    public class CategoryCount
    {
        public string CategoryName { get; set; }
        public long CountCategory { get; set; }
    }
}
