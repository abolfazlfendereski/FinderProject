using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinderProject.Domian.Dto
{
   public class DetailBussinessDto
    {
        public ProductDto Product { get; set; }
        public string categoryName { get; set; }
        public addressDto Address { get; set; }
        public List<product_TypeRoomDto> rooms { get; set; }
        public List<product_PossibilitiesDto> possibilities { get; set; }
        public List<product_HotelFeactureDto> hotelFeactures { get; set; }
        public List<product_FeactureDto> feactures { get; set; }
        public List<Product_SocialMediaDto> socialMedias { get; set; }
        public List<string> Images { get; set; }
        public List<ProdoctbriefDto> RelatedBussiness { get; set; }
        public List<CommentProductDto> CommentProducts { get; set; }

    }
   
   
}
