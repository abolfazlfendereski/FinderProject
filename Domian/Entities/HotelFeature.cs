using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using FinderProject.Domian.Entities.BaseEntity;

namespace FinderProject.Domian.Entities
{
    public class HotelFeature : BaseEntities
    {
       
        public string DisPlayNameF { get; set; }
        public string valueF { get; set; }
       
        
        public virtual Product Product { get; set; }
        [ForeignKey("Product")]
        public long ProductId { get; set; }
    }
}