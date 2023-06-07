using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinderProject.Domian.Entities.BaseEntity;

namespace FinderProject.Domian.Entities
{
   public class Product:BaseEntities
    {
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }
        [Required]
        public float lowPrice { get; set; }
        [Required]
        public float maxPrice { get; set; }

        public virtual Category Category { get; set; }
        public long CategoryId { get; set; }
        public long ViewCount { get; set; }
        public byte numberRoom { get; set; }
        public byte Score { get; set; }

        public string websiteUrl { get; set; }

        public string LogoSrc { get; set; }
       
        [EmailAddress]
        public string Email { get; set; }


        #region Relation
        public virtual AddressInfo AddressInfo { get; set; }      
        public virtual ICollection<Features> Features { get; set; }
        public virtual ICollection<HotelFeature> HotelFeatures { get; set; }
        public virtual ICollection<awards> Awards { get; set; }
        public virtual ICollection<Images> Images { get; set; }
        public virtual ICollection<SocialMedia> SocialMedias { get; set; }
        public virtual ICollection<Possibilities> Possibilities { get; set; }
        public virtual ICollection<TypeRoom> TypeRooms { get; set; }
        public virtual ICollection<CommentProduct> CommentProducts { get; set; }
       public virtual User User { get; set; }
        [ForeignKey("User")]
        public string UserId { get; set; }
        #endregion

    }
}
