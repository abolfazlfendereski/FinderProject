using FinderProject.Common.Results;
using FinderProject.Domian.AutoMapperProfile;
using FinderProject.Domian.Dto;
using FinderProject.Domian.Entities;
using FinderProject.Domian.IContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinderProject.Application.Services.BussinessServices.Commands
{
    public interface IAddCommentService
    {
        public CommentProductDto Execute(CommentProductDto dto,long id);
    }
    public class AddCommentService : IAddCommentService
    {
        private readonly IApplicationDbContext _context;

        public AddCommentService(IApplicationDbContext context)
        {
            this._context = context;
        }
        public CommentProductDto Execute(CommentProductDto dto,long id)
        {
            var comment = ObjectMapper.Mapper.Map<CommentProduct>(dto);
            var user = _context.Users.FirstOrDefault(a=>a.Id==dto.userId);
            comment.User = user;
            comment.Product = _context.Products.FirstOrDefault(a => a.Id == id);
            _context.CommentProducts.Add(comment);
            _context.SaveChanges();
            return dto;
        }
    }
}
