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
    public class AddressInfo:BaseEntities
    {
        [Required]
        public string countery { get; set; }
        [Required]
        public string city { get; set; }
        [Required]
        public string Address { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }
        public string Mantaghe { get; set; }
        [MaxLength(10)]
        public string codeposti { get; set; }
        [Required]
        [MaxLength(11)]
        public string phoneNumber  { get; set; }
        public virtual Product Product { get; set; }
        [ForeignKey("Product")]
        public long ProductId { get; set; }
    }
}
