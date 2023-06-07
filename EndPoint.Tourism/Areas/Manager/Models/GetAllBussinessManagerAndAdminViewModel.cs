using EndPoint.FinderProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EndPoint.FinderProject.Areas.Manager.Models
{
    public class GetAllBussinessManagerAndAdminViewModel
    {
       
        public int totalRow { get; set; }
        public List<ProdoctBriefVM> ProdoctBriefVM { get; set; }
        public List<CategoryManagerAdminPanle> Category { get; set; }

    }
    public class CategoryManagerAdminPanle
    {
        public long id { get; set; }
        public string CategoryName { get; set; }
    }
   
}
