using FinderProject.Common.Results;
using FinderProject.Domian.AutoMapperProfile;
using FinderProject.Domian.Dto;
using FinderProject.Domian.IContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace FinderProject.Application.Services.BussinessServices.Queries
{
    public interface ISiteDetailBussinessService
    {
        public ResultMethods<DetailBussinessDto> Execute(long Id);
    }
    public class SiteDetailBussinessService : ISiteDetailBussinessService
    {
        private readonly IApplicationDbContext _context;
        private readonly ILogger<SiteDetailBussinessService> _logger;
        private readonly IDistributedCache _cache;

        public SiteDetailBussinessService(IApplicationDbContext context
            ,ILogger<SiteDetailBussinessService> logger,IDistributedCache cache)
        {
            this._context = context;
            this._logger = logger;
            this._cache = cache;
        }
        public ResultMethods<DetailBussinessDto> Execute(long Id)
        {
            var Bussiness = _context.Products.Include(b => b.AddressInfo).Include(b => b.Images).Include(b => b.Possibilities)
                .Include(b => b.SocialMedias).Include(b=>b.CommentProducts).Include(b => b.HotelFeatures).Include(b => b.Category).Include(b => b.Features)
                .Include(b => b.TypeRooms).FirstOrDefault(b=>b.Id==Id);
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
                Images = Bussiness.Images.Select(p => p.Src).ToList(),             
                RelatedBussiness= GetRelatedBussinessService.Execute(_context,_cache,Bussiness.Id,Bussiness.Category.Id,Bussiness.AddressInfo.city)
            };
            Bussiness.ViewCount++;
            _context.SaveChanges();
            return new ResultMethods<DetailBussinessDto>()
            {
                Data = Detailbussiness,
                Message = "جزئیات کسب و کار با موفقیت گرفته شد",
                Res = resMethod.Success
            };
        }

        
    }
}
