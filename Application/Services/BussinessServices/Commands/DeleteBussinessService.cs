using FinderProject.Common.Results;
using FinderProject.Domian.IContext;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinderProject.Application.Services.BussinessServices.Commands
{
    public interface IDeleteBussinessService
    {
        public ResultMethodsWithOutData Delete(long id);
    }
    public class DeleteBussinessService : IDeleteBussinessService
    {
        private readonly IApplicationDbContext _context;
        private readonly ILogger<DeleteBussinessService> _logger;

        public DeleteBussinessService(IApplicationDbContext context, ILogger<DeleteBussinessService> logger)
        {
            this._context = context;
            this._logger = logger;
        }
        public ResultMethodsWithOutData Delete(long id)
        {
            var product=  _context.Products.FirstOrDefault(a => a.Id == id);
            try
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
                return new ResultMethodsWithOutData()
                {
                    Message = "حذف با موفقیت انجام شد",
                    Res = resMethod.Success
                };
            }
            catch (Exception ex)
            {
                _logger.LogError($"حذف با مشکل{ex.Message}رو به رو شد");
                return new ResultMethodsWithOutData()
                {
                    Message = $"حذف با مشکل{ex.Message}رو به رو شد",
                    Res = resMethod.Error
                };
            }
           
        }
    }
}
