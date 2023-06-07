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

namespace FinderProject.Application.Services.OrderServices.Commad
{
    public interface IAddOrderService
    {
        public ResultMethodsWithOutData Execute(BookBussinessDto dto);
    }
    public class AddOrderService : IAddOrderService
    {
        private readonly IApplicationDbContext _context;

        public AddOrderService(IApplicationDbContext context)
        {
            this._context = context;
        }
        public ResultMethodsWithOutData Execute(BookBussinessDto dto)
        {
            var order = ObjectMapper.Mapper.Map<Order>(dto);
            var product = _context.Products.FirstOrDefault(a=>a.Id==dto.BussinessId);
            order.Product = product;
            _context.Orders.Add(order);
            _context.SaveChanges();
            return new ResultMethodsWithOutData(){
                Message="رزرو با موفقیت انجام شد",
                Res=resMethod.Success
            };
        }
    }
}
