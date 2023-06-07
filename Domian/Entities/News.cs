using FinderProject.Domian.Entities.BaseEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinderProject.Domian.Entities
{
   public class News : BaseEntities
    {
        public string TitleNews { get; set; }
        public string TxtNews { get; set; }
        public string ImageNews { get; set; }
        public string ForCity { get; set; }
    }
}
