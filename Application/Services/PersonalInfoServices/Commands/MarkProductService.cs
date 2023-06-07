using FinderProject.Domian.Entities;
using FinderProject.Domian.IContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinderProject.Application.Services.PersonalInfoServices.Commands
{
    public interface IMarkProductService
    {
        public void Execute(long id,string userId);
    }
    public class MarkProductService : IMarkProductService
    {
        private readonly IApplicationDbContext _context;

        public MarkProductService(IApplicationDbContext context)
        {
            this._context = context;
        }
        public void Execute(long id,string userId)
        {
            var product = _context.Products.FirstOrDefault(a=>a.Id==id);
            var user = _context.Users.FirstOrDefault(a=>a.Id==userId);
            var favorite = new Favorite() { Product = product, User = user };
            _context.Favorites.Add(favorite);
            _context.SaveChanges();
        }
    }
}
