using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EndPoint.FinderProject.Models
{
    public class ProductViewModel
    {
        [MaxLength(300)]
        [Required(ErrorMessage ="نام خالی است")]
        public string Name { get; set; }

        public string Description { get; set; }
        [Required(ErrorMessage ="محدوده قیمت خالی است")]
        
        public float lowPrice { get; set; }
        [Required(ErrorMessage = "محدوده قیمت خالی است")]
        public float maxPrice { get; set; }

        public long CategoryId { get; set; }
        public long SubCategoryId { get; set; }
       
        public string phoneNumber { get; set; }
        public string websiteUrl { get; set; }

        public string LogoSrc { get; set; }
        [Required]
        public string countery { get; set; }
        [Required]
        public string city { get; set; }
        public string LanLng { get; set; }
       
        [Required]
        public string Address { get; set; }
        
        public string Mantaghe { get; set; }
        [MaxLength(10)]
        public string codeposti { get; set; }
        [EmailAddress]
        [Required(ErrorMessage ="ایمیل خالی است")]
        public string Email { get; set; }
        public string numberRoom { get; set; }
        public byte Score { get; set; }

    }
    public class product_Feacture
    {
        public string DisplayName { get; set; }
        public string Value { get; set; }
    }
    public class product_Possibilities
    {
        public string PossibilityValue { get; set; }//امکانات
    }
    public class product_TypeRoom
    {
        public string Typevalue { get; set; }
    }
    public class product_awards
    {
        public string src { get; set; }
    }
    public class product_HotelFeacture
    {      
        public string featurestring { get; set; }
        
    }
    public class Product_SocialMedia
    {
        public string SocialMediaSrc { get; set; }
    }
}
