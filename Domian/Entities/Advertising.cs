using FinderProject.Domian.Entities.BaseEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinderProject.Domian.Entities
{
   public class Advertising:BaseEntities
    {
        public string title { get; set; }
        public string txt { get; set; }
        public string AdvertisingSrc { get; set; }
    }
}
