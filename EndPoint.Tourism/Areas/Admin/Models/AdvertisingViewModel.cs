using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EndPoint.FinderProject.Areas.Admin.Models
{
    public class AdvertisingViewModel
    {
        public string title { get; set; }
        public string txt { get; set; }
        public string AdvertisingSrc { get; set; }
        public IFormFile ImageFile { get; set; }
    }
}
