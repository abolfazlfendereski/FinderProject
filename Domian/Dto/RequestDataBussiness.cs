using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinderProject.Domian.Dto
{
    public class RequestDataBussiness
    {
        public ProductDto Product { get; set; }
        public addressDto AddressDto { get; set; }
        public List<Image_Dto> ImagesSrc { get; set; }
        public List<product_FeactureDto> feactures { get; set; }
        public List<product_HotelFeactureDto> HotelFeactures { get; set; }
        public List<product_PossibilitiesDto> possibilities { get; set; }
        public List<product_TypeRoomDto> typeRooms { get; set; }
        public List<Product_SocialMediaDto> SocialMedia { get; set; }
    }
    public class ProductDto
    {
        public long id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }


        public float lowPrice { get; set; }

        public float maxPrice { get; set; }

        public long CategoryId { get; set; }
        public long SubCategoryId { get; set; }
        

        public string websiteUrl { get; set; }

        public string LogoSrc { get; set; }


      

        public string Email { get; set; }
        public int numberRoom { get; set; }
        public byte Score { get; set; }

    }
    public class addressDto
    {
        public string phoneNumber { get; set; }
        public string codeposti { get; set; }
        public string countery { get; set; }

        public string city { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }


        public string Address { get; set; }

        public string Mantaghe { get; set; }

    }
    public class product_FeactureDto
    {
        public string DisplayName { get; set; }
        public string Value { get; set; }
    }
    public class Image_Dto
    {
        public string Src { get; set; }
    }
    public class product_PossibilitiesDto
    {
        public string PossibilityValue { get; set; }//امکانات
    }
    public class product_TypeRoomDto
    {
        public string Typevalue { get; set; }
    }
    public class product_awardsDto
    {
        public string src { get; set; }
    }
    public class product_HotelFeactureDto
    {
        public string DisPlayNameF { get; set; }
        public string valueF { get; set; }
    }
    public class Product_SocialMediaDto
    {
        public string SocialMediaName { get; set; }
        public string SocialMediaSrc { get; set; }
    }
}
