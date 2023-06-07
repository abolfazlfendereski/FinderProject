using AutoMapper;

using FinderProject.Application.Interfaces.FacadPattern;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EndPoint.FinderProject.Areas.Manager.Models;
using EndPoint.FinderProject.Models;

namespace EndPoint.FinderProject.Areas.Manager.Controllers
{
    [Area("Manager")]
    public class BussinessController : BaseController
    {
        private readonly IFacadePatternInterFaceBussiness _facadeBussiness;
        private readonly IFacadePatternInterfaces _facadePattern;
        private readonly IMapper _mapper;
        private readonly IFacadePatternOrderInterFace _facadePatternOrder;
        public BussinessController(IFacadePatternInterFaceBussiness facadeBussiness, IMapper mapper, IFacadePatternInterfaces facadePattern, IFacadePatternOrderInterFace facadePatternOrder)
        {
            this._facadeBussiness = facadeBussiness;
            this._mapper = mapper;
            this._facadePattern = facadePattern;
            _facadePatternOrder = facadePatternOrder;
        }
        [HttpGet]
        public IActionResult Index(string searchKey,long?categoryid,int page=1,int pageSize=15)
        {
            var result = _facadeBussiness.managerAndAdminGetAllBussinessService.Execute(categoryid,searchKey,page,pageSize);
            var Vm = new GetAllBussinessManagerAndAdminViewModel()
            {
                Category=_facadePattern.getCategoryService.GetCategory(null).Data
                .Select(a=>new CategoryManagerAdminPanle() {CategoryName=a.Name,id=a.id }).ToList(),
                ProdoctBriefVM = _mapper.Map<List<ProdoctBriefVM>>(result.Data.ProdoctbriefsDto),
                totalRow = result.Data.totalRow
            };
           
            switch (result.Res)
            {
                case global::FinderProject.Common.Results.resMethod.Success:
                    TempData[SuccessMessage] = result.Message;
                    break;
                case global::FinderProject.Common.Results.resMethod.Error:
                    TempData[ErrorMessage] = result.Message;
                    break;
                case global::FinderProject.Common.Results.resMethod.Warning:
                    TempData[WarningMessage] = result.Message;
                    break;
                case global::FinderProject.Common.Results.resMethod.Info:
                    TempData[InfoMessage] = result.Message;
                    break;
                
            }
            return View(Vm);
        }
        [HttpPost]
        public IActionResult DeleteBussiness(long id)
        {
          var result=  _facadeBussiness.deleteBussinessService.Delete(id);
            switch (result.Res)
            {
                case global::FinderProject.Common.Results.resMethod.Success:
                    TempData[SuccessMessage] = result.Message;
                    break;
                case global::FinderProject.Common.Results.resMethod.Error:
                    TempData[ErrorMessage] = result.Message;
                    break;
                case global::FinderProject.Common.Results.resMethod.Warning:
                    break;
                case global::FinderProject.Common.Results.resMethod.Info:
                    break;
              
            }
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult DetailBussiness(long id)
        {
            var result = _facadeBussiness.MADetailBussinessService.Execute(id);
            switch (result.Res)
            {
                case global::FinderProject.Common.Results.resMethod.Success:
                    TempData[SuccessMessage] = result.Message;
                    break;
                case global::FinderProject.Common.Results.resMethod.Error:
                    TempData[ErrorMessage] = result.Message;
                    break;
                case global::FinderProject.Common.Results.resMethod.Warning:
                    break;
                case global::FinderProject.Common.Results.resMethod.Info:
                    break;
                default:
                    break;
            }
            return View(result.Data);
        }
        [HttpGet]
        public IActionResult GetAllOrders()
        {
            var result = _facadePatternOrder.GetAllOrdersServiceAdminAndManagerPanel.Execute();
            switch (result.Res)
            {
                case global::FinderProject.Common.Results.resMethod.Success:
                    TempData[SuccessMessage] = result.Message;
                    break;
                case global::FinderProject.Common.Results.resMethod.Error:
                    break;
                case global::FinderProject.Common.Results.resMethod.Warning:
                    break;
                case global::FinderProject.Common.Results.resMethod.Info:
                    break;

            }
            return View(result.Data);
        }

    }
}
