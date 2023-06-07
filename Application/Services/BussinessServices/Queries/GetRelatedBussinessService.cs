using FinderProject.Domian.Dto;
using FinderProject.Domian.IContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace FinderProject.Application.Services.BussinessServices.Queries
{
   public static class GetRelatedBussinessService
    {        
        public static List<ProdoctbriefDto> Execute(IApplicationDbContext _context,IDistributedCache _cache,long Bussinessid, long categoryid, string CityName, int TakeValue = 5)
        {
            var Products = _cache.GetAsync($"RelatedBussiness{CityName}").Result;
            if (Products == null)
            {
                var Bussinesses = _context.Products.Include(b => b.Category).Include(b => b.AddressInfo).Include(b => b.Images)
                    .Where(b => b.Category.Id == categoryid && b.AddressInfo.city == CityName && b.Id != Bussinessid)
                    .Take(TakeValue).Select(b => new ProdoctbriefDto()
                    {
                        BussinessId = b.Id,
                        CategoryName = b.Category.Name,
                        City = b.AddressInfo.city,
                        LowPrice = b.lowPrice,
                        Name = b.Name,
                        Score = b.Score,
                        Src = b.Images.FirstOrDefault().Src
                    }).ToList();
                var JsonData = JsonSerializer.Serialize(Bussinesses);
                byte[] ByteDataArray = Encoding.UTF8.GetBytes(JsonData);
                var optionCache = new DistributedCacheEntryOptions() { SlidingExpiration = TimeSpan.FromMinutes(4) };
                _cache.SetAsync($"RelatedBussiness{CityName}", ByteDataArray, optionCache);
                return Bussinesses;
            }
            else
            {
                var resultCacheData = JsonSerializer.Deserialize<List<ProdoctbriefDto>>(Products);
                return resultCacheData;
            }
        }
    }
}
