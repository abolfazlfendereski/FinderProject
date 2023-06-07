using FinderProject.Application.Interfaces.FacadPattern;
using FinderProject.Application.Services.NewsAndAdvertisingServices.Commands;
using FinderProject.Application.Services.NewsAndAdvertisingServices.Queries;
using FinderProject.Domian.IContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinderProject.Application.Services.NewsAndAdvertisingServices.FacadePattern
{
    public class FacadePattern: IFacadePatternNewsAndAdvertisingInterfaces
    {
        private readonly IApplicationDbContext _context;

        public FacadePattern(IApplicationDbContext context)
        {
            this._context = context;
        }
        private IAddNewsService _AddNewsService;
        public IAddNewsService AddNewsService
        {
            get
            {
                return _AddNewsService = _AddNewsService ?? new AddNewsService(_context);
            }
        }
        private IGetFewNewsService _GetFewNewsService;
        public IGetFewNewsService GetFewNewsService
        {
            get
            {
                return _GetFewNewsService = _GetFewNewsService ?? new GetFewNewsService(_context);
            }
        }
        private IAddAdvertisingService _AddAdvertisingService;
        public IAddAdvertisingService AddAdvertisingService
        {
            get
            {
                return _AddAdvertisingService = _AddAdvertisingService ?? new AddAdvertisingService(_context);
            }
        }
        private IGetAdvertisingService _GetAdvertisingService;
        public IGetAdvertisingService GetAdvertisingService
        {
            get
            {
                return _GetAdvertisingService = _GetAdvertisingService ?? new GetAdvertisingService(_context);
            }
        }
        private IGetAllNewsService _GetAllNewsService;
        public IGetAllNewsService GetAllNewsService
        {
            get
            {
                return _GetAllNewsService = _GetAllNewsService ?? new GetAllNewsService(_context);
            }
        }
    }
}
