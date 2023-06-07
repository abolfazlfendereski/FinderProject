using FinderProject.Domian.AutoMapperProfile;
using FinderProject.Domian.Dto;
using FinderProject.Domian.IContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinderProject.Application.Services.PersonalInfoServices.Queries
{
    public interface IGetUserCommentsService
    {
        public List<CommentProductDto> Execute(string userId);
    }
    public class GetUserCommentsService : IGetUserCommentsService
    {
        private readonly IApplicationDbContext _context;

        public GetUserCommentsService(IApplicationDbContext context)
        {
            this._context = context;
        }
        public List<CommentProductDto> Execute(string userId)
        {
            var comment = _context.CommentProducts.Where(c => c.UserId == userId).ToList();
            var CommentDto = comment.Select(c => new CommentProductDto()
            {
                Comments = c.Comments,
                Email = c.Email,
                insertTime = c.InsertTime,
                Name = c.Name,
                ProductId = c.ProductId,
                ProductName = _context.Products.FirstOrDefault(a=>a.Id==c.ProductId).Name,
                Score=c.Score,
                User=c.User
            }).ToList();
            return CommentDto;
        }
    }
}
