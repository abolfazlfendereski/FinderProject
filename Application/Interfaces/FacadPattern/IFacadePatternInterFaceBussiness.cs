using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinderProject.Application.Services.bussinessQueryServices.Queries;
using FinderProject.Application.Services.BussinessServices.Commands;
using FinderProject.Application.Services.BussinessServices.Queries;

namespace FinderProject.Application.Interfaces.FacadPattern
{
   public interface IFacadePatternInterFaceBussiness
    {
        IAddBussinessService AddBussinessService { get; }
        IGetBussinessInfoService getBussinessInfoService { get; }
        IGetAllBussinessService GetAllBussinessService  { get; }
        IManagerAndAdminGetAllBussinessService managerAndAdminGetAllBussinessService { get; }
        IDeleteBussinessService deleteBussinessService { get; }
        IMADetailBussinessService MADetailBussinessService { get; }
        ISiteDetailBussinessService SiteDetailBussinessService { get; }
        IAddCommentService AddCommentService { get; }
        IDetailCommentSiteService DetailCommentSiteService { get; }
        IDetailInformationServer DetailInformationServer { get; }
       
    }
}
