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

namespace FinderProject.Application.Services.BussinessServices.Queries
{
    public interface IManagerAndAdminGetAllBussinessService
    {
        public ResultMethods<GetAllBussinessDto> Execute(long? categoryid, string searchKey, int page, int pageSize);
    }
    public class ManagerAndAdminGetAllBussinessService : IManagerAndAdminGetAllBussinessService
    {
        private readonly IApplicationDbContext _context;
        private readonly ILogger<ManagerAndAdminGetAllBussinessService> _logger;

        public ManagerAndAdminGetAllBussinessService(IApplicationDbContext context, ILogger<ManagerAndAdminGetAllBussinessService> logger)
        {
            this._context = context;
            this._logger = logger;
        }
        public ResultMethods<GetAllBussinessDto> Execute(long? categoryid, string searchKey, int page, int pageSize)
        {
            try
            {
                var BussinessQuery = _context.Products.Include(p => p.Images).Include(p => p.AddressInfo)
                    .Include(p => p.Category).AsQueryable();
                if (categoryid != null)
                {
                    BussinessQuery = BussinessQuery.Where(p => p.Category.ParentCategory.Id == categoryid || p.Category.Id == categoryid).AsQueryable();
                }
                if (!string.IsNullOrWhiteSpace(searchKey))
                {
                    BussinessQuery = BussinessQuery.Where(p => p.Name.Contains(searchKey) ||
                      p.AddressInfo.city.Contains(searchKey) || p.AddressInfo.Mantaghe.Contains(searchKey)).AsQueryable();
                }
                int totalRow = 0;
                var bussiness = BussinessQuery.ToPage(page, pageSize, out totalRow);
                return new ResultMethods<GetAllBussinessDto>()
                {
                    Data = new GetAllBussinessDto()
                    {
                        ProdoctbriefsDto = bussiness.Select(p => new ProdoctbriefDto()
                        {
                            BussinessId = p.Id,
                            CategoryName = p.Category.Name,
                            Name = p.Name,
                            City = p.AddressInfo.city,
                            LowPrice = p.lowPrice,
                            Score = p.Score,
                        }).ToList(),
                        totalRow = totalRow
                    },
                    Message = "اطلاعات با موفقیت گرفته شد",
                    Res = resMethod.Success
                };
            }
            catch (Exception ex)
            {
                _logger.LogError($"گرفتن اطلاعات در پنل مدیریت و ادمین با مشکل {ex.Message}");
                return new ResultMethods<GetAllBussinessDto>()
                {
                    Data = null,
                    Message = $"گرفتن اطلاعات در پنل مدیریت و ادمین با مشکل {ex.Message}",
                    Res = resMethod.Error
                };               
            }
        }
    }
}
