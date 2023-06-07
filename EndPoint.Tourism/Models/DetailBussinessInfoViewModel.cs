using FinderProject.Domian.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EndPoint.FinderProject.Models
{
    public class DetailBussinessInfoViewModel
    {
        public long id { get; set; }
        public string Name { get; set; }
        public string phoneNumber { get; set; }
        public string websiteUrl { get; set; }
        public float lowPrice { get; set; }
        public float maxPrice { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Email { get; set; }
        public byte Score { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }
        public string categoryName { get; set; }
        public string Discription { get; set; }
        public List<product_TypeRoomDto> rooms { get; set; }
        public List<product_PossibilitiesDto> possibilities { get; set; }
        public List<product_HotelFeactureDto> hotelFeactures { get; set; }
        public List<product_FeactureDto> feactures { get; set; }
        public List<ProdoctBriefVM> RelatedBussiness { get; set; }
        public List<Product_SocialMediaDto> product_Socials { get; set; }
    }
}
