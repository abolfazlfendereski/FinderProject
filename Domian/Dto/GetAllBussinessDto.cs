using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinderProject.Domian.Dto
{
   public class GetAllBussinessDto
    {
        public string CategoryName { get; set; }
        public int totalRow { get; set; }
        public List<ProdoctbriefDto> ProdoctbriefsDto { get; set; }
    }
    public enum Ordering
    {
         Newest,
         MostVisited,
         PriceUpToDown,
         PriceLowToHigh,
         HighScore,
         LowScore,
    }
}
