using FinderProject.Domian.AutoMapperProfile;
using FinderProject.Domian.Dto;
using FinderProject.Domian.IContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinderProject.Application.Services.BussinessServices.Queries
{
    public interface IDetailInformationServer
    {
        public InformationDetailDto Execute(long id);
    }
    public class DetailInformationServer : IDetailInformationServer
    {
        private readonly IApplicationDbContext _context;
        private readonly IDistributedCache _cache;
        public DetailInformationServer(IApplicationDbContext context,IDistributedCache cache)
        {
            this._context = context;
            this._cache = cache;
        }
        public InformationDetailDto Execute(long id)
        {
            var Bussiness = _context.Products.Include(p => p.AddressInfo).Include(p => p.Features)
                .Include(p => p.HotelFeatures).Include(p => p.Category).Include(p => p.Possibilities).Include(p => p.TypeRooms)
                .Include(p => p.SocialMedias).FirstOrDefault(p=>p.Id==id);
            var Detailbussiness = new InformationDetailDto()
            {
                Product = ObjectMapper.Mapper.Map<ProductDto>(Bussiness),
                categoryName = Bussiness.Category.Name,
                Address = ObjectMapper.Mapper.Map<addressDto>(Bussiness.AddressInfo),
                feactures = ObjectMapper.Mapper.Map<List<product_FeactureDto>>(Bussiness.Features),
                hotelFeactures = ObjectMapper.Mapper.Map<List<product_HotelFeactureDto>>(Bussiness.HotelFeatures),
                possibilities = ObjectMapper.Mapper.Map<List<product_PossibilitiesDto>>(Bussiness.Possibilities),
                rooms = ObjectMapper.Mapper.Map<List<product_TypeRoomDto>>(Bussiness.TypeRooms),
                socialMedias = ObjectMapper.Mapper.Map<List<Product_SocialMediaDto>>(Bussiness.SocialMedias),             

                RelatedBussiness = GetRelatedBussinessService.Execute(_context, _cache, Bussiness.Id, Bussiness.Category.Id, Bussiness.AddressInfo.city)
            };

            return Detailbussiness;
        }
    }
}
