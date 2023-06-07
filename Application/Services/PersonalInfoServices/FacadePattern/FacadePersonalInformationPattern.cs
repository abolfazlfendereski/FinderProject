using FinderProject.Application.Interfaces.FacadPattern;
using FinderProject.Application.Services.PersonalInfoServices.Commands;
using FinderProject.Application.Services.PersonalInfoServices.Queries;
using FinderProject.Domian.IContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinderProject.Application.Services.PersonalInfoServices.FacadePattern
{
   public class FacadePersonalInformationPattern: IFacadePatternPersonalInformationInterface
    {
        private readonly IApplicationDbContext _context;
        public FacadePersonalInformationPattern(IApplicationDbContext context)
        {
            this._context = context;
        }
        private IAddPersonalInformationService _AddPersonalInformationService;
        public IAddPersonalInformationService AddPersonalInformationService
        {
            get
            {
                return _AddPersonalInformationService = _AddPersonalInformationService ?? new AddPersonalInformationService(_context);
            }
        }
        private IGetInformationService _GetInformationService;
        public IGetInformationService GetInformationService
        {
            get
            {
                return _GetInformationService = _GetInformationService ?? new GetInformationService(_context);
            }
        }
        private IGetUserCommentsService _GetUserCommentsService;
        public IGetUserCommentsService GetUserCommentsService
        {
            get
            {
                return _GetUserCommentsService = _GetUserCommentsService ?? new GetUserCommentsService(_context);
            }
        }
        private IMarkProductService _MarkProductService;
        public IMarkProductService MarkProductService
        {
            get
            {
                return _MarkProductService = _MarkProductService ?? new MarkProductService(_context);
            }
        }
        private IGetFavoriteService _GetFavoriteService;
        public IGetFavoriteService GetFavoriteService
        {
            get
            {
                return _GetFavoriteService = _GetFavoriteService ?? new GetFavoriteService(_context);
            }
        }
        private IGetOrderProductPersonalService _GetOrderProductPersonalService;
        public IGetOrderProductPersonalService GetOrderProductPersonalService
        {
            get
            {
                return _GetOrderProductPersonalService = _GetOrderProductPersonalService ?? new GetOrderProductPersonalService(_context);
            }
        }
        private IGetUserBussinessService _GetUserBussinessService;
        public IGetUserBussinessService GetUserBussinessService
        {
            get
            {
                return _GetUserBussinessService = _GetUserBussinessService ?? new GetUserBussinessService(_context);
            }
        }
    }
}
