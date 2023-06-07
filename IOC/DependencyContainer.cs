using Microsoft.Extensions.DependencyInjection;

using FinderProject.Application.Interfaces.FacadPattern;

using FinderProject.Application.Services.CategoryServices.Commands;
using FinderProject.Application.Services.CategoryServices.FacadPattern;
using FinderProject.Application.Services.CategoryServices.Queries;

using FinderProject.Infra.Data.Context;

using FinderProject.Domian.IContext;
using FinderProject.Application.Services.BussinessServices.FacadePattern;
using FinderProject.Application.Services.NewsAndAdvertisingServices.FacadePattern;
using FinderProject.Application.Services.OrderServices.FacadePattern;
using FinderProject.Application.Services.PersonalInfoServices.FacadePattern;

namespace IOC
{
    public class DependencyContainer
    {
        public static void RegisterService(IServiceCollection service )
        {
            //#region Category Service
           
            //service.AddScoped<IAddNewCategory, AddNewCategory>();
            //service.AddScoped<IGetcategoryService, GetCategoryService>();
            //service.AddScoped<IDeleteCategoryService, DeleteCategoryService>();
           
            //#endregion

            //Add uploadImage Service
            
            //Add Facade Pattern
            service.AddScoped<IFacadePatternInterfaces, FacadPatternCategoryServices>();
            service.AddScoped<IFacadePatternInterFaceBussiness, FacadePatternServiceBussiness>();
            service.AddScoped<IFacadePatternNewsAndAdvertisingInterfaces, FacadePattern>();
            service.AddScoped<IFacadePatternOrderInterFace, FacadePatternOrderService>();
            service.AddScoped<IFacadePatternPersonalInformationInterface, FacadePersonalInformationPattern>();
            //Add Repository Of DB
            service.AddScoped<IApplicationDbContext, ApplicationDBContext>();
        }
    }
}
