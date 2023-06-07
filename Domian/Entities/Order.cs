using FinderProject.Domian.Entities.BaseEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinderProject.Domian.Entities
{
   public class Order:BaseEntities
    {
        public string Name { get; set; }
        public string Family { get; set; }        
        public string Codemeli { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public int Number { get; set; }
        public string PhoneNumber { get; set; }
        public virtual Product Product { get; set; }
        [ForeignKey("Product")]
        public long ProductId { get; set; }
        public virtual User User { get; set; }
        [ForeignKey("User")]
        public string Userid { get; set; }
       
    }
}
