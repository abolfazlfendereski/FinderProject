using FinderProject.Application.Services.PersonalInfoServices.Commands;
using FinderProject.Application.Services.PersonalInfoServices.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinderProject.Application.Interfaces.FacadPattern
{
   public interface IFacadePatternPersonalInformationInterface
    {
        IAddPersonalInformationService AddPersonalInformationService { get; }
        IGetInformationService GetInformationService { get; }
        IGetUserCommentsService GetUserCommentsService { get; }
        IMarkProductService MarkProductService { get; }
        IGetFavoriteService GetFavoriteService { get; }
        IGetOrderProductPersonalService GetOrderProductPersonalService { get; }
        IGetUserBussinessService GetUserBussinessService { get; }
    }
}
