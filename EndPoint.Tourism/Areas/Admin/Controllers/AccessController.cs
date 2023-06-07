using AutoMapper;
using EndPoint.FinderProject.Areas.Admin.Models;
using EndPoint.FinderProject.HelpService.UploadImage;
using FinderProject.Application.Interfaces.FacadPattern;
using FinderProject.Domian.Dto;
using FinderProject.Domian.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EndPoint.FinderProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AccessController : BaseController
    {
        private readonly IFacadePatternNewsAndAdvertisingInterfaces _facade;
        private readonly IUploadImage _upload;
        private readonly IMapper mapper;

        public AccessController(IFacadePatternNewsAndAdvertisingInterfaces facade, IUploadImage upload,IMapper mapper)
        {
            this._facade = facade;
            this._upload = upload;
            this.mapper = mapper;
        }
        [HttpGet]
        public IActionResult AddNews()
        {

            return View();
        }
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult AddNews(NewsViewModel Vm)
        {                   
            var dto = mapper.Map<NewsDto>(Vm);
            dto.ImageNews = _upload.UploadFile(Vm.ImageFile, "News");
            var result = _facade.AddNewsService.Execute(dto);
            switch (result.Res)
            {
                case global::FinderProject.Common.Results.resMethod.Success:
                    TempData[SuccessMessage] = result.Message;
                    break;
                case global::FinderProject.Common.Results.resMethod.Error:
                    TempData[SuccessMessage] = result.Message;
                    break;
                case global::FinderProject.Common.Results.resMethod.Warning:
                    TempData[SuccessMessage] = result.Message;
                    break;
                case global::FinderProject.Common.Results.resMethod.Info:
                    TempData[SuccessMessage] = result.Message;
                    break;                
            }
            return View();
        }
        [HttpGet]
        public IActionResult AddAdvertising()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddAdvertising(AdvertisingViewModel model)
        {
            string src = _upload.UploadFile(model.ImageFile, "Advertising");
            var dto = mapper.Map<Advertising>(model);
            dto.AdvertisingSrc = src;
            var result = _facade.AddAdvertisingService.Execute(dto);            
            switch (result.Res)
            {
                case global::FinderProject.Common.Results.resMethod.Success:
                    TempData[SuccessMessage] = result.Message;
                    break;
                case global::FinderProject.Common.Results.resMethod.Error:
                    TempData[SuccessMessage] = result.Message;
                    break;
                case global::FinderProject.Common.Results.resMethod.Warning:
                    TempData[SuccessMessage] = result.Message;
                    break;
                case global::FinderProject.Common.Results.resMethod.Info:
                    TempData[SuccessMessage] = result.Message;
                    break;
            }
            return View();
        }
        [HttpGet]
        public IActionResult GetAllAdvertising()
        {
            var res = _facade.GetAdvertisingService.GetAll();
            switch (res.Res)
            {
                case global::FinderProject.Common.Results.resMethod.Success:
                    TempData[SuccessMessage] = res.Message;
                    break;
                case global::FinderProject.Common.Results.resMethod.Error:
                    break;
                case global::FinderProject.Common.Results.resMethod.Warning:
                    break;
                case global::FinderProject.Common.Results.resMethod.Info:
                    break;
            }
            return View(mapper.Map<List<AdvertisingViewModel>>(res.Data));
        }
        [HttpGet]
        public IActionResult GetAllNews()
        {
            var result = _facade.GetAllNewsService.Execute();
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
