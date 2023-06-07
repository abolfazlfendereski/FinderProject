using FinderProject.Domian.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EndPoint.FinderProject.Models
{
    public class DetailBussinessReviewViewModel
    {
        public long id { get; set; }
        public string Name { get; set; }
        public string phoneNumber { get; set; }
        public string websiteUrl { get; set; }
        public float lowPrice { get; set; }
        public float maxPrice { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public byte Score { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }
        public List<Product_SocialMediaDto> product_Socials { get; set; }
        public List<ProdoctBriefVM> RelatedBussiness { get; set; }
        public List<CommentProductDto> CommentProductDtos { get; set; }
        public CommentProductDto AddCommentProperty { get; set; }
    }
}
