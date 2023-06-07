using FinderProject.Common.Results;
using FinderProject.Domian.Entities;
using FinderProject.Domian.IContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinderProject.Application.Services.NewsAndAdvertisingServices.Queries
{
    public interface IGetAdvertisingService
    {
        public ResultMethods<List<Advertising>> GetAll();
        public ResultMethods<Advertising> GetLast();
    }
    public class GetAdvertisingService : IGetAdvertisingService
    {
        private readonly IApplicationDbContext _context;

        public GetAdvertisingService(IApplicationDbContext context)
        {
            this._context = context;
        }
        public ResultMethods<List<Advertising>> GetAll()
        {

            var result = _context.Advertisings.ToList();
            return new ResultMethods<List<Advertising>>()
            {
                Data = result,
                Message = "",
                Res = resMethod.Success
            };
        }

        public ResultMethods<Advertising> GetLast()
        {

            return new ResultMethods<Advertising>()
            {
                Data = _context.Advertisings.OrderByDescending(a=>a.Id).FirstOrDefault(),
                Message="",
                Res=resMethod.Success
            };
       
        }
    }
}
