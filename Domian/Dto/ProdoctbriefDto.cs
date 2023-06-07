using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinderProject.Domian.Dto
{
    public class ProdoctbriefDto
    {
        public long BussinessId { get; set; }
        public string Name { get; set; }
        public string Src { get; set; }
        public byte Score { get; set; }
        public float LowPrice { get; set; }
        public string City { get; set; }
        public string CategoryName { get; set; }
        public long Categoryid { get; set; }
    }
}
