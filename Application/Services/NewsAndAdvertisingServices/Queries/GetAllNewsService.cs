using FinderProject.Common.Results;
using FinderProject.Domian.Dto;
using FinderProject.Domian.IContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinderProject.Application.Services.NewsAndAdvertisingServices.Queries
{
    public interface IGetAllNewsService
    {
        public ResultMethods<List<NewsDto>> Execute();
    }
    public class GetAllNewsService : IGetAllNewsService
    {
        private readonly IApplicationDbContext _context;

        public GetAllNewsService(IApplicationDbContext context)
        {
            this._context = context;
        }
        public ResultMethods<List<NewsDto>> Execute()
        {
            var AllNews = _context.News.Select(a => new NewsDto()
            {
                id=a.Id,
                ForCity=a.ForCity,
                ImageNews=a.ImageNews,
                TitleNews=a.TitleNews,
                TxtNews=a.TxtNews
            }).ToList();
            return new ResultMethods<List<NewsDto>>()
            {
                Data=AllNews,
                Message="همه اخبار با موفقیت گرفته شد",
                Res=resMethod.Success
            };
        }
    }
}
