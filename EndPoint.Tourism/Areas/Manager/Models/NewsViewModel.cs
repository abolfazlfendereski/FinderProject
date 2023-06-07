using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EndPoint.FinderProject.Areas.Manager.Models
{
    public class NewsViewModel
    {
        public string TitleNews { get; set; }
        public string TxtNews { get; set; }
        public IFormFile ImageFile { get; set; }

        public string ForCity { get; set; }
    }
}
