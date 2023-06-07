using EndPoint.FinderProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinderProject.Application.Interfaces.FacadPattern;

namespace EndPoint.FinderProject.ViewComponents
{
    public class SubCategoryComponent: ViewComponent
    {
        private readonly IFacadePatternInterfaces _facade;
        public SubCategoryComponent(IFacadePatternInterfaces facade)
        {
            this._facade = facade;
        }
        public IViewComponentResult Invoke(long id = 1)
        {
            return null;
        }
    }
}
