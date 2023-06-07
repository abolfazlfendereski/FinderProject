using AutoMapper;
using EndPoint.FinderProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using FinderProject.Application.Interfaces.FacadPattern;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;
using System.Text;
using FinderProject.Domian.Dto;
using EndPoint.FinderProject.Areas.Admin.Models;

namespace EndPoint.FinderProject.Controllers
{
    public class HomeController : SiteBaseController
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IFacadePatternInterfaces _facadePattern;
        private readonly IFacadePatternInterFaceBussiness _facadeBussiness;
        private readonly IMapper _mapper;
        private readonly IDistributedCache _cache;
        private readonly IFacadePatternNewsAndAdvertisingInterfaces _facadeNewsAndAdvertising;

        public HomeController(ILogger<HomeController> logger,IFacadePatternInterfaces facadePattern
            ,IFacadePatternInterFaceBussiness facadeBussiness,IMapper mapper,IDistributedCache cache,
            IFacadePatternNewsAndAdvertisingInterfaces facadeNewsAndAdvertising
            )
        {
            this._facadePattern = facadePattern;
            this._facadeBussiness = facadeBussiness;
            _logger = logger;
            _mapper = mapper;
            _cache = cache;
            this._facadeNewsAndAdvertising = facadeNewsAndAdvertising;
        }

        public IActionResult Index()
        {
            var ViewModel = new HomeViewModel();
            
            var resultCacheResidence = _cache.GetAsync("BussinessBriefHomeResidence").Result;
            var resultCacheRestaurant = _cache.GetAsync("BussinessBriefHomeRestaurant").Result;
            var resultCacheMostvisited = _cache.GetAsync("BussinessBriefHomeMostvisited").Result;
            if (resultCacheResidence ==null)
            {              
                var getBussinessData = _facadeBussiness.getBussinessInfoService.GetBriefBussiness().Data;
                //Add Data To Redis Cache
                var JsonDataResidence = JsonSerializer.Serialize(getBussinessData.ProdoctbriefsResidence);
                var JsonDataRestaurant = JsonSerializer.Serialize(getBussinessData.ProdoctbriefsRestaurant);
                byte[] ArrayByteDataResidence = Encoding.UTF8.GetBytes(JsonDataResidence);
                byte[] ArrayByteDataRestaurant = Encoding.UTF8.GetBytes(JsonDataRestaurant);
                var cacheOption = new DistributedCacheEntryOptions() { SlidingExpiration = TimeSpan.FromMinutes(2) };
                _cache.SetAsync("BussinessBriefHomeResidence", ArrayByteDataResidence, cacheOption);
                _cache.SetAsync("BussinessBriefHomeRestaurant", ArrayByteDataRestaurant, cacheOption);
                ViewModel.AdvertisingSrc = _mapper.Map<AdvertisingViewModel>( _facadeNewsAndAdvertising.GetAdvertisingService.GetLast().Data);
                ViewModel.News = _facadeNewsAndAdvertising.GetFewNewsService.Execute().Data;
                ViewModel.BriefResidenceVM = _mapper.Map<List<ProdoctBriefVM>>(getBussinessData.ProdoctbriefsResidence);
                ViewModel.BriefRestaurantVM = _mapper.Map<List<ProdoctBriefVM>>(getBussinessData.ProdoctbriefsRestaurant);
                ViewModel.MostVisited = _mapper.Map<List<ProdoctBriefVM>>(getBussinessData.MostVisited);
                var JsonDataMostVisited = JsonSerializer.Serialize(getBussinessData.MostVisited);
                byte[] ArrayByteDataMostVisited = Encoding.UTF8.GetBytes(JsonDataMostVisited);
                _cache.SetAsync("BussinessBriefHomeMostvisited", ArrayByteDataMostVisited, cacheOption);
            }
            else
            {
                ViewModel.AdvertisingSrc = _mapper.Map<AdvertisingViewModel>(_facadeNewsAndAdvertising.GetAdvertisingService.GetLast().Data);
                ViewModel.News = _facadeNewsAndAdvertising.GetFewNewsService.Execute().Data;
                ViewModel.BriefResidenceVM = JsonSerializer.Deserialize<List<ProdoctBriefVM>>(resultCacheResidence);
                ViewModel.BriefRestaurantVM = JsonSerializer.Deserialize<List<ProdoctBriefVM>>(resultCacheRestaurant);
                ViewModel.MostVisited = JsonSerializer.Deserialize<List<ProdoctBriefVM>>(resultCacheMostvisited);
                
            }        
            
            return View(ViewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
