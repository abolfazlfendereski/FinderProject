using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EndPoint.FinderProject.Models
{
    public class AddOrderBussinessViewModel
    {
        public string Name { get; set; }
        public string Family { get; set; }
        [MaxLength(10)]
        public string Codemeli { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public int Number { get; set; }
        public string PhoneNumber { get; set; }
        public long BussinessId { get; set; }
    }
}
