using FinderProject.Domian.Entities.BaseEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinderProject.Domian.Entities
{
   public class PersonalInformation :BaseEntities
    {
        public string FullName { get; set; }
        public string gender { get; set; }
        public string BirthDate { get; set; }
        public string Email { get; set; }
        public string phoneNumber { get; set; }
        public string Address { get; set; }
        public virtual User User { get; set; }
        [ForeignKey("User")]
        public string UserId { get; set; }
            
    }
}
