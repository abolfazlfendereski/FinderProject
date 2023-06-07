using FinderProject.Application.Interfaces.FacadPattern;
using FinderProject.Application.Services.OrderServices.Commad;
using FinderProject.Application.Services.OrderServices.Queries;
using FinderProject.Domian.IContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinderProject.Application.Services.OrderServices.FacadePattern
{
   public class FacadePatternOrderService: IFacadePatternOrderInterFace
    {
        private readonly IApplicationDbContext _context;

        public FacadePatternOrderService(IApplicationDbContext context)
        {
            this._context = context;
        }
        private IAddOrderService _AddOrderService;
        public IAddOrderService AddOrderService
        {
            get
            {
                return _AddOrderService = _AddOrderService ?? new AddOrderService(_context);
            }
        }
        private IGetAllOrdersServiceAdminAndManagerPanel _GetAllOrdersServiceAdminAndManagerPanel;
        public IGetAllOrdersServiceAdminAndManagerPanel GetAllOrdersServiceAdminAndManagerPanel
        {
            get
            {
                return _GetAllOrdersServiceAdminAndManagerPanel = _GetAllOrdersServiceAdminAndManagerPanel ?? new GetAllOrdersServiceAdminAndManagerPanel(_context);
            }
        }
    }
}
