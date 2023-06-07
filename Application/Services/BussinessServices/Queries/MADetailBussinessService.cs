using FinderProject.Common.Results;
using FinderProject.Domian.AutoMapperProfile;
using FinderProject.Domian.Dto;
using FinderProject.Domian.IContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinderProject.Application.Services.BussinessServices.Queries
{
    public interface IMADetailBussinessService
    {
        public ResultMethods<DetailBussinessDto> Execute(long id);
    }
    /// <summary>
    /// Admin And Manager Panel Data For DetailBussiness View  
    /// </summary>
    public class MADetailBussinessService : IMADetailBussinessService
    {
        private readonly IApplicationDbContext _context;
        private readonly ILogger<MADetailBussinessService> _logger;

        public MADetailBussinessService(IApplicationDbContext context, ILogger<MADetailBussinessService> logger)
        {
            this._context = context;
            this._logger = logger;
        }
        public ResultMethods<DetailBussinessDto> Execute(long id)
        {
            try
            {
                var Bussiness = _context.Products.Include(p => p.AddressInfo).Include(p => p.Images).Include(p => p.Category).Include(p => p.Possibilities)
                    .Include(p => p.Features).Include(p => p.HotelFeatures).Include(p => p.SocialMedias).Include(p => p.TypeRooms)
                    .FirstOrDefault(p => p.Id == id);
                var Detailbussiness = new DetailBussinessDto()
                {
                    Product = ObjectMapper.Mapper.Map<ProductDto>(Bussiness),
                    categoryName = Bussiness.Category.Name,
                    Address = ObjectMapper.Mapper.Map<addressDto>(Bussiness.AddressInfo),
                    feactures = ObjectMapper.Mapper.Map<List<product_FeactureDto>>(Bussiness.Features),
                    hotelFeactures = ObjectMapper.Mapper.Map<List<product_HotelFeactureDto>>(Bussiness.HotelFeatures),
                    possibilities = ObjectMapper.Mapper.Map<List<product_PossibilitiesDto>>(Bussiness.Possibilities),
                    rooms = ObjectMapper.Mapper.Map<List<product_TypeRoomDto>>(Bussiness.TypeRooms),
                    socialMedias = ObjectMapper.Mapper.Map<List<Product_SocialMediaDto>>(Bussiness.SocialMedias),
                    Images = Bussiness.Images.Select(p => p.Src).ToList()
                };

                return new ResultMethods<DetailBussinessDto>()
                {
                    Data = Detailbussiness,
                    Message = "جزئیات کسب و کار با موفقیت گرفته شد",
                    Res = resMethod.Success
                };
            }
            catch (Exception ex)
            {
                _logger.LogError($"گرفتن جزئیات کسب و کار با مشکل {ex.Message}");

                return new ResultMethods<DetailBussinessDto>()
                {
                    Data = null,
                    Message = "جزئیات کسب و کار با موفقیت گرفته شد",
                    Res = resMethod.Error
                };
            }
        }
    }
}
