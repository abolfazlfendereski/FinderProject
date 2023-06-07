using FinderProject.Common.Results;
using FinderProject.Domian.Dto;
using FinderProject.Domian.IContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinderProject.Application.Services.OrderServices.Queries
{
    public interface IGetAllOrdersServiceAdminAndManagerPanel
    {
        public ResultMethods<List<OrderDto>> Execute();
    }
    public class GetAllOrdersServiceAdminAndManagerPanel : IGetAllOrdersServiceAdminAndManagerPanel
    {
        private readonly IApplicationDbContext _context;

        public GetAllOrdersServiceAdminAndManagerPanel(IApplicationDbContext context)
        {
            _context = context;
        }

        public ResultMethods<List<OrderDto>> Execute()
        {
            var result = _context.Orders.Include(a => a.Product)
                .ThenInclude(a => a.Category)
                .Select(a => new OrderDto()
                {
                    Category=a.Product.Category.ParentCategory.Name,
                    Codemeli=a.Codemeli,
                    Family=a.Family,
                    FromDate=a.FromDate,
                    Name=a.Name,
                    id=a.Id,
                    Number=a.Number,
                    PhoneNumber=a.PhoneNumber,
                    Product=a.Product.Name,
                    ToDate=a.ToDate
                }).ToList();
            return new ResultMethods<List<OrderDto>>()
            {
                Data=result,
                Message="همه رزرو ها برگردانده شد",
                Res=resMethod.Success
            };
        }
    }
}
