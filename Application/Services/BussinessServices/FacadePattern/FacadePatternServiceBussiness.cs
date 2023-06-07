
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinderProject.Application.Interfaces.FacadPattern;
using FinderProject.Application.Services.BussinessServices.Commands;
using FinderProject.Application.Services.BussinessServices.Queries;
using FinderProject.Domian.IContext;
using FinderProject.Application.Services.bussinessQueryServices.Queries;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Caching.Distributed;

namespace FinderProject.Application.Services.BussinessServices.FacadePattern
{
    public class FacadePatternServiceBussiness : IFacadePatternInterFaceBussiness
    {
        private readonly IApplicationDbContext _context;
        private readonly IDistributedCache _cache;
        private readonly ILogger<AddBussinessService> _loggerAddBussinessService;
        private readonly ILogger<GetBussinessInfoService> _loggerGetBussinessInfo;
        private readonly ILogger<GetAllBussinessService> _loggerGetAllBussinessService;
        private readonly ILogger<ManagerAndAdminGetAllBussinessService> _loggerManagerAndAdminGetAll;
        private readonly ILogger<DeleteBussinessService> _loggerDeleteBussinessService;
        private readonly ILogger<MADetailBussinessService> _loggerMADetailBussinessService;
        private readonly ILogger<SiteDetailBussinessService> _loggerSiteDetailBussinessService;
        public FacadePatternServiceBussiness(IApplicationDbContext context,
            IDistributedCache cache,
            ILogger<GetAllBussinessService> loggerGetAllBussinessService
            , ILogger<AddBussinessService> loggerAddBussinessService, ILogger<GetBussinessInfoService> loggerGetBussinessInfo
            , ILogger<ManagerAndAdminGetAllBussinessService> loggerManagerAndAdminGetAll, ILogger<DeleteBussinessService> loggerDeleteBussinessService
            , ILogger<MADetailBussinessService> loggerMADetailBussinessService
            ,ILogger<SiteDetailBussinessService> loggerSiteDetailBussinessService
            )
        {
            this._context = context;
            this._cache = cache;
            this._loggerAddBussinessService = loggerAddBussinessService;
            this._loggerGetBussinessInfo = loggerGetBussinessInfo;
            this._loggerGetAllBussinessService = loggerGetAllBussinessService;
            this._loggerManagerAndAdminGetAll = loggerManagerAndAdminGetAll;
            this._loggerDeleteBussinessService =loggerDeleteBussinessService;
            this._loggerMADetailBussinessService = loggerMADetailBussinessService;
            this._loggerSiteDetailBussinessService = loggerSiteDetailBussinessService;
        }

        private IAddBussinessService _AddBussinessService;

        public IAddBussinessService AddBussinessService
        {
            get
            {
                return _AddBussinessService = _AddBussinessService ?? new AddBussinessService(_context, _loggerAddBussinessService);
            }
        }
        private IGetBussinessInfoService _getBussinessInfoService;
        public IGetBussinessInfoService getBussinessInfoService
        {
            get
            {
                return _getBussinessInfoService = _getBussinessInfoService ?? new GetBussinessInfoService(_context, _loggerGetBussinessInfo);
            }
        }

        private IGetAllBussinessService _GetAllBussinessService;
        public IGetAllBussinessService GetAllBussinessService
        {
            get
            {
                return _GetAllBussinessService = _GetAllBussinessService ?? new GetAllBussinessService(_context, _loggerGetAllBussinessService);
            }
        }

        private IManagerAndAdminGetAllBussinessService _managerAndAdminGetAllBussinessService;
        public IManagerAndAdminGetAllBussinessService managerAndAdminGetAllBussinessService
        {
            get
            {
                return _managerAndAdminGetAllBussinessService = _managerAndAdminGetAllBussinessService ?? new ManagerAndAdminGetAllBussinessService(_context, _loggerManagerAndAdminGetAll);
            }
        }
        private IDeleteBussinessService _deleteBussinessService;
        public IDeleteBussinessService deleteBussinessService
        {
            get
            {
                return _deleteBussinessService = _deleteBussinessService ?? new DeleteBussinessService(_context, _loggerDeleteBussinessService);
            }
        }
        private IMADetailBussinessService _MADetailBussinessService;
        public IMADetailBussinessService MADetailBussinessService
        {
            get
            {
                return _MADetailBussinessService = _MADetailBussinessService ?? new MADetailBussinessService(_context, _loggerMADetailBussinessService);
            }
        }
        private ISiteDetailBussinessService _SiteDetailBussinessService;
        public ISiteDetailBussinessService SiteDetailBussinessService
        {
            get
            {
                return _SiteDetailBussinessService = _SiteDetailBussinessService ?? new SiteDetailBussinessService(_context,_loggerSiteDetailBussinessService,_cache);
            }
        }
        private IAddCommentService _addCommentService;
        public IAddCommentService AddCommentService
        {
            get
            {
                return _addCommentService = _addCommentService ?? new AddCommentService(_context);
            }
        }
        private IDetailCommentSiteService _DetailCommentSiteService;
        public IDetailCommentSiteService DetailCommentSiteService
        {
            get
            {
                return _DetailCommentSiteService = _DetailCommentSiteService ?? new DetailCommentSiteService(_context);
            }
        }
        private IDetailInformationServer _DetailInformationServer;
        public IDetailInformationServer DetailInformationServer
        {
            get
            {
                return _DetailInformationServer = _DetailInformationServer ?? new DetailInformationServer(_context, _cache);
            }
        }
       
    }
}
