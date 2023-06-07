using FinderProject.Domian.Dto;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EndPoint.FinderProject.Models
{
    public class GetAllBussnessViewModel
    {
        public string CatgegoryName { get; set; }
        public int totalRow { get; set; }
        public List<ProdoctBriefVM> ProdoctBriefVM { get; set; }
        public List<SelectListItem> CategoryDtos { get; set; }
    }
    public enum OrderingVM
    {
        Newest,
        MostVisited,
        PriceUpToDown,
        PriceLowToHigh,
        HighScore,
        LowScore,
    }
}
