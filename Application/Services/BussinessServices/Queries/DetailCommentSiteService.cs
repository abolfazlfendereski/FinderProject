using FinderProject.Domian.AutoMapperProfile;
using FinderProject.Domian.Dto;
using FinderProject.Domian.IContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinderProject.Application.Services.BussinessServices.Queries
{
    public interface IDetailCommentSiteService
    {
        public CommentDetailDto Execute(long id);
    }
    public class DetailCommentSiteService : IDetailCommentSiteService
    {
        private readonly IApplicationDbContext _context;

        public DetailCommentSiteService(IApplicationDbContext context)
        {
            this._context = context;
        }
        public CommentDetailDto Execute(long id)
        {
            var Bussiness = _context.Products.Include(p => p.Category).Include(p=>p.AddressInfo).FirstOrDefault(p => p.Id == id);
            var Comments = _context.CommentProducts.Where(p => p.Product.Id == id)
                .Select(p => new CommentProductDto()
                {
                    Comments=p.Comments,
                    Email=p.Email,
                    Name=p.Name,
                    Score=p.Score,
                    insertTime=p.InsertTime
                }).ToList();
            return new CommentDetailDto()
            {
                ProductDto = ObjectMapper.Mapper.Map<ProductDto>(Bussiness),
                categoryName = Bussiness.Category.Name,
                Address = ObjectMapper.Mapper.Map<addressDto>(Bussiness.AddressInfo),
                CommentProducts=Comments
            };
        }
    }
}
