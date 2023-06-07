using FinderProject.Application.Services.NewsAndAdvertisingServices.Commands;
using FinderProject.Application.Services.NewsAndAdvertisingServices.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinderProject.Application.Interfaces.FacadPattern
{
   public interface IFacadePatternNewsAndAdvertisingInterfaces
    {
        IAddNewsService AddNewsService { get; }
        IGetFewNewsService GetFewNewsService { get; }
        IAddAdvertisingService AddAdvertisingService { get; }
        IGetAdvertisingService GetAdvertisingService { get; }
        IGetAllNewsService GetAllNewsService { get; }
    }
}
