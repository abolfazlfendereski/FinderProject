using FinderProject.Domian.Entities.BaseEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinderProject.Domian.Entities
{
   public class CommentProduct: BaseEntities
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public byte Score { get; set; }
        public string Comments { get; set; }
        public virtual Product Product { get; set; }
        [ForeignKey("Product")]
        public long ProductId { get; set; }
        public virtual User User { get; set; }
        [ForeignKey("User")]
        public string UserId { get; set; }
    }
}
