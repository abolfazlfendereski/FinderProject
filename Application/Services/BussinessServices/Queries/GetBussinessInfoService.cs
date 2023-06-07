using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using FinderProject.Common.Results;
using FinderProject.Domian.Dto;
using FinderProject.Domian.IContext;
using System;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Caching.Distributed;

namespace FinderProject.Application.Services.BussinessServices.Queries
{
    public interface IGetBussinessInfoService
    {
        public ResultMethods<GetBussinessHome> GetBriefBussiness();
        public ProdoctbriefDto GetBussiness(long id);
    }
    public class GetBussinessInfoService : IGetBussinessInfoService
    {
        private readonly IApplicationDbContext _context;
        private readonly ILogger<GetBussinessInfoService> _logger;

        public GetBussinessInfoService(IApplicationDbContext context
            , ILogger<GetBussinessInfoService> logger)
        {
            this._context = context;
            this._logger = logger;

        }
        public ResultMethods<GetBussinessHome> GetBriefBussiness()
        {
            try
            {
                var products = _context.Products.Include(a => a.AddressInfo).Include(a => a.Category)
                    .Include(a => a.Images).AsQueryable();

                var Residence = products.Where(p => p.Category.ParentCategory.Id == 1)
                    .Select(p =>
                         new ProdoctbriefDto()
                         {
                             BussinessId = p.Id,
                             City = p.AddressInfo.city,
                             LowPrice = p.lowPrice,
                             Name = p.Name,
                             Score = p.Score,
                             Src = p.Images.FirstOrDefault().Src
                         })
                  .ToList().TakeLast(4);

                var Restaurant = products.Where(p => p.Category.ParentCategory.Id == 2)
                   .Select(p =>
                         new ProdoctbriefDto()
                         {
                             BussinessId = p.Id,
                             City = p.AddressInfo.city,
                             LowPrice = p.lowPrice,
                             Name = p.Name,
                             Score = p.Score,
                             Src = p.Images.FirstOrDefault().Src
                         })
                  .ToList().TakeLast(8);
                var mostVisited = products.OrderByDescending(a => a.ViewCount)
                   .Select(p =>
                         new ProdoctbriefDto()
                         {
                             BussinessId = p.Id,
                             City = p.AddressInfo.city,
                             LowPrice = p.lowPrice,
                             Name = p.Name,
                             Score = p.Score,
                             Src = p.Images.FirstOrDefault().Src
                         })
                  .ToList().TakeLast(8);

                return new ResultMethods<GetBussinessHome>()
                {
                    Data = new GetBussinessHome()
                    {
                        ProdoctbriefsResidence = Residence,
                        ProdoctbriefsRestaurant = Restaurant,
                        MostVisited = mostVisited
                    },
                    Message = "",
                    Res = resMethod.Success
                };


            }
            catch (Exception ex)
            {
                _logger.LogError($"گرفتن اطلاعات کسب و کار با مشکل {ex.Message}");
                return new ResultMethods<GetBussinessHome>()
                {
                    Data = null,
                    Message = $"گرفتن اطلاعات کسب و کار با مشکل { ex.Message }",
                    Res = resMethod.Error
                };

            }
        }

        public ProdoctbriefDto GetBussiness(long id)
        {
            var Product = _context.Products.Include(a => a.AddressInfo)
                .Select(p =>
                             new ProdoctbriefDto()
                             {
                                 BussinessId = p.Id,
                                 City = p.AddressInfo.city,
                                 LowPrice = p.lowPrice,
                                 Name = p.Name,
                                 Score = p.Score,
                                 Src = p.Images.FirstOrDefault().Src
                             }).FirstOrDefault(a => a.BussinessId == id);
            return Product;
        }
    }
}
