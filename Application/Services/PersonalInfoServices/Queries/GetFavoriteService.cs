using FinderProject.Domian.Dto;
using FinderProject.Domian.Entities;
using FinderProject.Domian.IContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinderProject.Application.Services.PersonalInfoServices.Queries
{
    public interface IGetFavoriteService
    {
        public List<ProdoctbriefDto> Execute(string userId);
    }
    public class GetFavoriteService : IGetFavoriteService
    {
        private readonly IApplicationDbContext _context;

        public GetFavoriteService(IApplicationDbContext context)
        {
            this._context = context;
        }
        public List<ProdoctbriefDto> Execute(string userId)
        {
            var favorites = _context.Favorites.Where(a => a.UserId == userId).ToList();
            var Products = new List<ProdoctbriefDto>();
            foreach (var item in favorites)
            {
                var product = _context.Products.Where(a => a.Id == item.ProductId)
                    .Select(a => new ProdoctbriefDto()
                    {
                        City = a.AddressInfo.city,
                        LowPrice = a.lowPrice,
                        Name = a.Name,
                        Score = a.Score,
                        Src = a.Images.FirstOrDefault().Src,
                        CategoryName = a.Category.ParentCategory.Name
                    }).FirstOrDefault();

                Products.Add(product);
            }
            return Products;
        }
    }
}
