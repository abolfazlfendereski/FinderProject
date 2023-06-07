using FinderProject.Common.ExtentionMethod;
using FinderProject.Common.Results;
using FinderProject.Domian.Dto;
using FinderProject.Domian.IContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinderProject.Application.Services.bussinessQueryServices.Queries
{
    public interface IGetAllBussinessService
    {
        public ResultMethods<GetAllBussinessDto> Execute(ParametrGetAllProduct parametr);
    }
    public class GetAllBussinessService : IGetAllBussinessService
    {
        private readonly IApplicationDbContext _context;
        private readonly ILogger<GetAllBussinessService> _logger;

        public GetAllBussinessService(IApplicationDbContext context, ILogger<GetAllBussinessService> logger)
        {
            this._context = context;
            this._logger = logger;
        }
        public ResultMethods<GetAllBussinessDto> Execute(ParametrGetAllProduct parametr)
        {
            try
            {
                var bussinessQuery = _context.Products.Include(a => a.AddressInfo).Include(a => a.Images)
                    .Include(a => a.Category).Include(a => a.Possibilities).Include(a => a.HotelFeatures).AsQueryable();
                if (parametr.categoryId != null)
                {
                    bussinessQuery = bussinessQuery.Where(b => b.Category.ParentCategory.Id == parametr.categoryId).AsQueryable();
                }
                if (parametr.searchKey != null)
                {
                    bussinessQuery = bussinessQuery.Where(b => b.Name == parametr.searchKey ||
                    b.AddressInfo.city == parametr.searchKey || b.AddressInfo.Mantaghe == parametr.searchKey).AsQueryable();
                }
                if (parametr.City!=null && parametr.region !=null)
                {
                    bussinessQuery = bussinessQuery.Where(b => b.AddressInfo.city == parametr.City && b.AddressInfo.Mantaghe == parametr.region).AsQueryable();
                }
                if (parametr.score !=null || parametr.NumberRoom !=null || parametr.LowPrice !=null && parametr.MaxPrice != null)
                {
                    bussinessQuery = bussinessQuery.Where(p => p.Score == parametr.score || p.numberRoom == parametr.NumberRoom
                      || p.lowPrice >= parametr.LowPrice && p.maxPrice <= parametr.MaxPrice).AsQueryable();
                }
               
                switch (parametr.Ordering)
                {
                    case Ordering.Newest:
                        bussinessQuery = bussinessQuery.OrderByDescending(a => a.Id).AsQueryable();
                        break;
                    case Ordering.MostVisited:
                        bussinessQuery = bussinessQuery.OrderByDescending(a => a.ViewCount).AsQueryable();
                        break;
                    case Ordering.PriceUpToDown:
                        bussinessQuery = bussinessQuery.OrderBy(a => a.maxPrice).AsQueryable();
                        break;
                    case Ordering.PriceLowToHigh:
                        bussinessQuery = bussinessQuery.OrderBy(a => a.lowPrice).AsQueryable();
                        break;
                    case Ordering.HighScore:
                        bussinessQuery = bussinessQuery.OrderBy(a => a.Score).AsQueryable();
                        break;
                    case Ordering.LowScore:
                        bussinessQuery = bussinessQuery.OrderByDescending(a => a.Score).AsQueryable();
                        break;
                    default:
                        break;
                }
                int totalRow = 0;
                var bussiness = bussinessQuery.ToPage(page: parametr.page, pageSize: parametr.pageSize, totalRow: out totalRow);
                if (bussiness.Count() == 0)
                {
                    return new ResultMethods<GetAllBussinessDto>()
                    {
                        Data = new GetAllBussinessDto()
                        {

                            ProdoctbriefsDto = new List<ProdoctbriefDto>()
                            {
                                new ProdoctbriefDto()
                                {
                                    CategoryName="هیچ کسب و کاری هنوز ثبت نشده است"
                                }
                            }
                        },
                        Message = "اطلاعات با موفقیت برگردانده شد",
                        Res = resMethod.Success,
                    };
                }

                return new ResultMethods<GetAllBussinessDto>()
                {
                    Data = new GetAllBussinessDto()
                    {
                        CategoryName = bussiness.ToList().Count() == 0 || parametr.categoryId == null || string.IsNullOrEmpty(parametr.searchKey) ? "هیچ دسته بندی انتخاب یا کلمه ای جست و جو نشده است" : null,
                        totalRow = totalRow,
                        ProdoctbriefsDto = bussiness.Select(a => new ProdoctbriefDto()
                        {
                            BussinessId=a.Id,
                            City = a.AddressInfo.city,
                            LowPrice = a.lowPrice,
                            Name = a.Name,
                            Score = a.Score,
                            Src = a.Images.FirstOrDefault().Src,
                            CategoryName = a.Category.ParentCategory.Name == null ? parametr.searchKey : a.Category.ParentCategory.Name
                        }).ToList(),
                    },
                    Message = "اطلاعات با موفقیت برگردانده شد",
                    Res = resMethod.Success,
                };
            }
            catch (Exception ex)
            {
                _logger.LogError($"گرفتن اطلاعات کسب و کار با مشکل {ex.Message}");
                return new ResultMethods<GetAllBussinessDto>()
                {
                    Data = null,
                    Message = $"گرفتن اطلاعات کسب و کار با مشکل {ex.Message}",
                    Res = resMethod.Error,
                };
            }


        }
    }
}
