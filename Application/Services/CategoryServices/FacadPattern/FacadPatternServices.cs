using FinderProject.Application.Interfaces.FacadPattern;

using FinderProject.Application.Services.CategoryServices.Commands;
using FinderProject.Application.Services.CategoryServices.Queries;
using Microsoft.Extensions.Logging;
using FinderProject.Domian.IContext;

namespace FinderProject.Application.Services.CategoryServices.FacadPattern
{
    public class FacadPatternCategoryServices : IFacadePatternInterfaces
    {
        private readonly IApplicationDbContext _db;
       
        public FacadPatternCategoryServices(IApplicationDbContext context)
        {
            _db = context;
           
        }
        private IAddNewCategory _AddNewCategory;
        public IAddNewCategory AddNewCategory { 
            
            get 
            {
                return _AddNewCategory = _AddNewCategory ?? new AddNewCategory(_db) ;

            } 
        }
        private IGetcategoryService _getcategoryService;
        public IGetcategoryService getCategoryService
        {
            get
            {
                return _getcategoryService = _getcategoryService ?? new GetCategoryService(_db);
            }
        }
        private IDeleteCategoryService _deleteCategoryService;
        
        public IDeleteCategoryService DeleteCategoryService
        {
            get
            {
                return _deleteCategoryService = _deleteCategoryService ?? new DeleteCategoryService(_db);
            }
        }
    }
}
