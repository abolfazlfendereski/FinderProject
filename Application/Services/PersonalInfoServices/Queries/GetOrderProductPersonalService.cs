using FinderProject.Domian.Dto;
using FinderProject.Domian.IContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinderProject.Application.Services.PersonalInfoServices.Queries
{
    public interface IGetOrderProductPersonalService
    {
        public List<GetMyOrdersDto> GetOrderProductPersonal(string userid);
        public List<GetMyOrdersDto> GetOrdersPersonalInformation(string userid);
        public bool HasBussiness(string userid);
    }
    public class GetOrderProductPersonalService : IGetOrderProductPersonalService
    {
        private readonly IApplicationDbContext context;

        public GetOrderProductPersonalService(IApplicationDbContext context)
        {
            this.context = context;
        }
        public List<GetMyOrdersDto> GetOrderProductPersonal(string userid)
        {
            var orders = context.Orders.Include(a => a.Product).ThenInclude(a => a.AddressInfo)
                .Include(a => a.Product.Images).Include(a => a.Product.Category)
                .Where(a => a.Userid == userid)
                .Select(a => new GetMyOrdersDto()
                {
                    BookBussinessDtos = new BookBussinessDto()
                    {
                        BussinessId = a.Id,
                      
                        FromDate = a.FromDate,
                        
                        Number = a.Number,
                     
                        ToDate = a.ToDate
                    },
                    ProdoctbriefDtos = new ProdoctbriefDto()
                    {
                        BussinessId = a.ProductId,
                        Categoryid = a.Product.CategoryId,
                        CategoryName = a.Product.Category.Name,
                        City = a.Product.AddressInfo.city,
                        Name = a.Product.Name,
                        LowPrice = a.Product.lowPrice,
                        Score = a.Product.Score,
                        Src = a.Product.Images.FirstOrDefault().Src
                    }
                }).ToList();
            return orders;
        }
        public bool HasBussiness(string userid)
        {
            var product = context.Products.Any(a => a.UserId == userid);
            return product;
        }
        public List<GetMyOrdersDto> GetOrdersPersonalInformation(string userid)
        {
            var orders = context.Orders.Include(a => a.Product).Include(a => a.User).ThenInclude(a => a.PersonalInformation)
                  .Where(a => a.Product.UserId == userid)
                  .Select(a => new GetMyOrdersDto()
                  {
                      BookBussinessDtos = new BookBussinessDto()
                      {
                          BussinessId = a.Id,
                          Codemeli = a.Codemeli,
                          Family = a.Family,
                          FromDate = a.FromDate,
                          Name = a.Name,
                          Number = a.Number,
                          PhoneNumber = a.PhoneNumber,
                          ToDate = a.ToDate
                      },
                      ProdoctbriefDtos = new ProdoctbriefDto()
                      {
                          BussinessId = a.ProductId,
                          Categoryid = a.Product.CategoryId,
                          CategoryName = a.Product.Category.Name,
                          City = a.Product.AddressInfo.city,
                          Name = a.Product.Name,
                          LowPrice = a.Product.lowPrice,
                          Score = a.Product.Score,
                          Src = a.Product.Images.FirstOrDefault().Src
                      }
                  }).ToList();
            return orders;
        }
    }
}
