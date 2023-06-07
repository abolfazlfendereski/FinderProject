using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinderProject.Domian.Dto
{
   public class GetBussinessHome
    {
        public IEnumerable<ProdoctbriefDto> ProdoctbriefsResidence { get; set; }
        public IEnumerable<ProdoctbriefDto> ProdoctbriefsRestaurant { get; set; }
        public IEnumerable<ProdoctbriefDto> MostVisited { get; set; }
    }
   
}
