using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinderProject.Domian.Dto
{
   public class GetCategoryDto
    {
        public long id { get; set; }
        public string Name { get; set; }
        public bool HasChild { get; set; }
        public string iconCate { get; set; }
        public long? ParentCategoryId { get; set; }
        public ParentCategoryDto Parent { get; set; }
    }
    public class ParentCategoryDto
    {
        public long Id { get; set; }
        public string name { get; set; }
    }
}
