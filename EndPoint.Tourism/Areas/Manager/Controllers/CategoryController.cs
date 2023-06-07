using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinderProject.Application.Interfaces.FacadPattern;
using FinderProject.Application.Services.CategoryServices.Commands;
using FinderProject.Application.Services.CategoryServices.Queries;
using FinderProject.Domian.Entities;
using FinderProject.Common.Results;
namespace EndPoint.FinderProject.Areas.Manager.Controllers
{
    [Area("Manager")]
    public class CategoryController : BaseController
    {
        private readonly IFacadePatternInterfaces _facadePattern;
        public CategoryController(IFacadePatternInterfaces facadePattern)
        {
            _facadePattern = facadePattern;
        }

        public IActionResult AddCategory(int? parentid)
        {
            ViewBag.parentid = parentid;
            return View();
        }
        [HttpPost]        
        public IActionResult AddCategory(string Name,long? Parentid)
        {
           if(ModelState.IsValid) { 
            var result = _facadePattern.AddNewCategory.AddCategory(Name,Parentid);
            switch (result.Res)
            {
                case resMethod.Success:
                    TempData[SuccessMessage] = result.Message;
                    break;
                case resMethod.Error:
                    TempData[ErrorMessage] = result.Message;
                    break;
                case resMethod.Warning:
                    TempData[WarningMessage] = result.Message;
                    break;
                case resMethod.Info:
                    break;
                default:
                    break;
            }
            }
            return View();
        }

        public IActionResult ShowCategory(long? parentid)
        {
            var res = _facadePattern.getCategoryService.GetCategory(parentid);
            switch (res.Res)
            {
                case resMethod.Success:
                    TempData[SuccessMessage] = res.Message;
                    break;
                case resMethod.Error:
                    TempData[ErrorMessage] = res.Message;
                    break;
                case resMethod.Warning:
                    break;
                case resMethod.Info:
                    break;
                default:
                    break;
            }
            return View(res.Data);
        }
        public IActionResult deleteCategory(long id)
        {
          var res= _facadePattern.DeleteCategoryService.DeleteCategory(id);
            switch (res.Res)
            {
                case resMethod.Success:
                    TempData[SuccessMessage] = res.Message;
                    break;
                case resMethod.Error:
                    break;
                case resMethod.Warning:
                    break;
                case resMethod.Info:
                    break;
                default:
                    break;
            }
            return RedirectToAction("ShowCategory");
        }
    }
}
