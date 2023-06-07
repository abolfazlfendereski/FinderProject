using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinderProject.Application.Services.CategoryServices.Commands;
using FinderProject.Domian.Entities;
using FinderProject.Common.Results;
namespace EndPoint.FinderProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : BaseController
    {
        private IAddNewCategory _addNewCategory;
        public CategoryController(IAddNewCategory addNewCategory)
        {
            _addNewCategory = addNewCategory;
        }
        public IActionResult AddCategory(int? parentid)
        {
            ViewBag.parentid = parentid;
            
            return View();
        }
        [HttpPost]

        public IActionResult AddCategory(string Name,long? Parentid)
        {
            if (ModelState.IsValid)
            {
                var result = _addNewCategory.AddCategory(Name,Parentid);
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
                }
            }
            return View();
        }
    }
}
