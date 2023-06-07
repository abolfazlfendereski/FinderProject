using System.ComponentModel.DataAnnotations.Schema;
using FinderProject.Domian.Entities.BaseEntity;

namespace FinderProject.Domian.Entities
{
    public class SocialMedia:BaseEntities
    {
        public string SocialMediaName { get; set; }
        public string AddressSocialMedia { get; set; }
        public virtual Product Product { get; set; }
        [ForeignKey("Product")]
        public long ProductId { get; set; }
    }
}