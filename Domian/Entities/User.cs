using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinderProject.Domian.Entities
{
   public class User:IdentityUser
    {
        public string FullName { get; set; }
        public ICollection<Product> Products  { get; set; }
        public virtual PersonalInformation PersonalInformation  { get; set; }
        
    }
}
