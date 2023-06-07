using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinderProject.Domian.Entities.BaseEntity;

namespace FinderProject.Domian.Entities
{
    public class awards:BaseEntities
    {
        public string src { get; set; }
       
        public virtual HotelFeature HotelFeature { get; set; }
        public long HotelFeatureId { get; set; }
    }
}
