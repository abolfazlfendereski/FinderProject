using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinderProject.Domian.Entities.BaseEntity;

namespace FinderProject.Domian.Entities
{
    public class Category : BaseEntities
    {
        [Required(ErrorMessage = "نام خالی است")]
        public string Name { get; set; }
        public virtual Category ParentCategory { get; set; }
        public string iconCate  { get; set; }
        public long? ParentCategoryId { get; set; }
        public virtual ICollection<Category> SubCategories { get; set; }
    }
}
