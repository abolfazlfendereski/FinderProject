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
    public interface IAddNewsService
    {
        public ResultMethodsWithOutData Execute(NewsDto dto);
    }
    public class AddNewsService : IAddNewsService
    {
        private readonly IApplicationDbContext _context;

        public AddNewsService(IApplicationDbContext context)
        {
            this._context = context;
        }
        public ResultMethodsWithOutData Execute(NewsDto dto)
        {
            try
            {
                var news = ObjectMapper.Mapper.Map<News>(dto);
                _context.News.Add(news);
                _context.SaveChanges();
                return new ResultMethodsWithOutData()
                {
                    Message = "اخبار با موفقیت ثبت شد",
                    Res = resMethod.Success
                };
            }
            catch (Exception ex)
            {

                return new ResultMethodsWithOutData()
                {
                    Message = $"رو به رو شد{ex.Message}ثبت اخبار با مشکل ",
                    Res = resMethod.Error
                };
            }
           
        }
    }
}
