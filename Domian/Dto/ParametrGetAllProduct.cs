using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinderProject.Domian.Dto
{
   public class ParametrGetAllProduct
    {
        public Ordering Ordering { get; set; } = Ordering.Newest;
        public long? categoryId { get; set; } = null;
        public int page { get; set; } = 1;
        public int pageSize { get; set; } = 15;
        public string searchKey { get; set; } = null;
        public string City { get; set; } = null;
        public string region { get; set; } = null;
        public float? LowPrice { get; set; } = null;
        public float? MaxPrice { get; set; } = null;
        public byte? score { get; set; } = null;
        public byte? NumberRoom { get; set; } = null;
    }
}
