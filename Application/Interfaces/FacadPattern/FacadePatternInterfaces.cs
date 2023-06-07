using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinderProject.Application.Services.CategoryServices.Commands;
using FinderProject.Application.Services.CategoryServices.Queries;

namespace FinderProject.Application.Interfaces.FacadPattern
{
   public interface IFacadePatternInterfaces
    {
        IAddNewCategory AddNewCategory { get; }
        IGetcategoryService getCategoryService { get; }
        IDeleteCategoryService DeleteCategoryService { get; }
    }
}
