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

namespace FinderProject.Application.Services.NewsAndAdvertisingServices.Commands
{
    public interface IAddAdvertisingService
    {
        public ResultMethodsWithOutData Execute(Advertising advertising);
    }
    public class AddAdvertisingService : IAddAdvertisingService
    {
        private readonly IApplicationDbContext _context;

        public AddAdvertisingService(IApplicationDbContext context)
        {
            this._context = context;
        }
        public ResultMethodsWithOutData Execute(Advertising advertising)
        {
            _context.Advertisings.Add(advertising);
            _context.SaveChanges();
            return new ResultMethodsWithOutData()
            {
                Message="تبلیغات با موفقیت اضافه شد",
                Res=resMethod.Success
            };
        }
    }
}
