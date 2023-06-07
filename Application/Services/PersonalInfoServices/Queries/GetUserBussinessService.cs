using FinderProject.Domian.Dto;
using FinderProject.Domian.IContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinderProject.Application.Services.PersonalInfoServices.Queries
{
    public interface IGetUserBussinessService
    {
        public GetUserBussinessDto Execute(string userid);
    }
    public class GetUserBussinessService : IGetUserBussinessService
    {
        private readonly IApplicationDbContext _context;

        public GetUserBussinessService(IApplicationDbContext context)
        {
            this._context = context;
        }
        public GetUserBussinessDto Execute(string userid)
        {

            var Products = _context.Products.Include(p => p.Category).Include(p => p.Images)
                 .Include(p => p.AddressInfo).Where(p => p.UserId == userid).Select(p => new ProdoctbriefDto()
                 {
                     BussinessId = p.Id,
                     CategoryName = p.Category.ParentCategory.Name,
                     City = p.AddressInfo.city,
                     Categoryid = p.CategoryId,
                     Name = p.Name,
                     LowPrice = p.lowPrice,
                     Score = p.Score,
                     Src = p.Images.FirstOrDefault().Src
                 }).ToList();
            var GetUserBussiness = new GetUserBussinessDto();
            GetUserBussiness.ProdoctbriefDtos=Products;
            List<CategoryCount> cateoryList = new List<CategoryCount>();
            for (int i = 0; i < Products.Count(); i++)
            {
                if (cateoryList.Count()>0 && cateoryList.Any(a=>a.CategoryName== Products[i].CategoryName))
                {
                    cateoryList.Find(a => a.CategoryName == Products[i].CategoryName).CountCategory++;
                }
                else
                {
                   var cate= new CategoryCount() { CategoryName = Products[i].CategoryName};
                    cate.CountCategory++;
                    cateoryList.Add(cate);
                }
            }
            GetUserBussiness.CategoryCounts=cateoryList;
            return GetUserBussiness;

        }
    }
}
