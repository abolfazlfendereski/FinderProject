using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EndPoint.FinderProject.Areas.Admin.Models;
using FinderProject.Domian.Dto;

namespace EndPoint.FinderProject.Models
{
    public class HomeViewModel
    {
        public List<ProdoctBriefVM> BriefResidenceVM { get; set; }
        public List<ProdoctBriefVM> BriefRestaurantVM { get; set; }
        public List<ProdoctBriefVM> MostVisited { get; set; }
        public List<NewsDto> News { get; set; }
        public AdvertisingViewModel AdvertisingSrc { get; set; }
    }
    public class ProdoctBriefVM
    {
        public long BussinessId { get; set; }
        public string Name { get; set; }
        public string Src { get; set; }
        public byte Score { get; set; }
        public float LowPrice { get; set; }
        public string City { get; set; }
        public string CategoryName { get; set; }
    }
}
