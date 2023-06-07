using FinderProject.Common.Results;
using FinderProject.Domian.AutoMapperProfile;
using FinderProject.Domian.Dto;
using FinderProject.Domian.IContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinderProject.Application.Services.NewsAndAdvertisingServices.Queries
{
    public interface IGetFewNewsService
    {
        public ResultMethods<List<NewsDto>> Execute();
    }
    public class GetFewNewsService : IGetFewNewsService
    {
        private readonly IApplicationDbContext _context;

        public GetFewNewsService(IApplicationDbContext context)
        {
            this._context = context;
        }
        public ResultMethods<List<NewsDto>> Execute()
        {
            var news = _context.News.ToList().TakeLast(5);
            return new ResultMethods<List<NewsDto>>()
            {
                Data = ObjectMapper.Mapper.Map<List<NewsDto>>(news),
                Message="",
                Res=resMethod.Success
            };
        }
    }
}
