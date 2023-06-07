using FinderProject.Application.Services.OrderServices.Commad;
using FinderProject.Application.Services.OrderServices.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinderProject.Application.Interfaces.FacadPattern
{
   public interface IFacadePatternOrderInterFace
    {
        IAddOrderService AddOrderService { get; }
        IGetAllOrdersServiceAdminAndManagerPanel GetAllOrdersServiceAdminAndManagerPanel { get; }
    }
}
