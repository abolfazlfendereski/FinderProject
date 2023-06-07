using AutoMapper;
using EndPoint.FinderProject.HelpService.UploadImage;
using EndPoint.FinderProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinderProject.Application.Interfaces.FacadPattern;
using FinderProject.Common.Results;
using FinderProject.Domian.Dto;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;
using System.Text;
using MansStore;
using Microsoft.AspNetCore.Identity;
using FinderProject.Domian.Entities;
using EndPoint.FinderProject.HelpService.GetUserService;
using Microsoft.AspNetCore.Authorization;

namespace EndPoint.FinderProject.Controllers
{
    [Authorize(Roles = "Customer")]
    public class BussinessController : SiteBaseController
    {
        private readonly IFacadePatternInterfaces _facadePattern;
        private readonly IMapper _mapper;
        private readonly IUploadImage _upload;
        private readonly IFacadePatternPersonalInformationInterface _facadePatternPersonalInformation;
        private readonly IFacadePatternInterFaceBussiness _facadeBussiness;
        private readonly IDistributedCache _cache;
           

        public BussinessController(IFacadePatternInterfaces facadePattern
            , IMapper mapper, IUploadImage upload,IFacadePatternPersonalInformationInterface facadePatternPersonalInformation,
            IFacadePatternInterFaceBussiness facadeBussiness, IDistributedCache cache)
        {
            this._facadePattern = facadePattern;
            this._mapper = mapper;
            this._upload = upload;
            this._facadePatternPersonalInformation = facadePatternPersonalInformation;
            this._facadeBussiness = facadeBussiness;
            this._cache = cache;
        }


        [HttpGet]             
        public IActionResult AddBussiness()
        {

            long? parentid = null;
            AddBussinessViewModel viewModel = new AddBussinessViewModel();
            viewModel.Category = _facadePattern.getCategoryService.GetCategory(parentid).Data
                .Where(a => a.Parent == null).ToList();
            return View(viewModel);
        }
        public JsonResult subChange(long parentId)
        {

            var getsub = _facadePattern.getCategoryService.GetSubCate(parentId);

            return Json(getsub);
        }
        [HttpPost]
        //[AutoValidateAntiforgeryToken]
        public IActionResult AddBussiness(ProductViewModel model, List<product_Feacture> feactures=null
            , List<product_HotelFeacture> HotelFeactures = null, List<product_Possibilities> possibilities = null
            , List<product_TypeRoom> typeRooms = null, List<Product_SocialMedia> SocialMedia = null)
        {
            string[] latlngsplit = model.LanLng.Split("//");
            var request = new RequestDataBussiness()
            {
                AddressDto = new addressDto()
                {
                    Address = model.Address,
                    city = model.city,
                    codeposti = model.codeposti,
                    countery = model.countery,
                    latitude = latlngsplit[0],
                    longitude = latlngsplit[1],
                    Mantaghe = model.Mantaghe,
                    phoneNumber = model.phoneNumber
                },
            };
            var userid = ClailmUtility.GetUserId(User);
            request.Product = _mapper.Map<ProductDto>(model);
            request.feactures = _mapper.Map<List<product_FeactureDto>>(feactures);
            request.possibilities = _mapper.Map<List<product_PossibilitiesDto>>(possibilities);
            request.typeRooms = _mapper.Map<List<product_TypeRoomDto>>(typeRooms);
            request.SocialMedia = _mapper.Map<List<Product_SocialMediaDto>>(SocialMedia);
            List<Image_Dto> Image_Dto = new List<Image_Dto>();
            for (int i = 0; i < Request.Form.Files.Count; i++)
            {
                var file = Request.Form.Files[i];
                IFormFile Img = file;
                Image_Dto.Add(new Image_Dto() { Src = _upload.UploadFile(Img, "Product") });
            }
            request.ImagesSrc = Image_Dto;
            List<product_HotelFeactureDto> listFeature = new List<product_HotelFeactureDto>();
            string[] splithotelfeature;
            foreach (var hotelfeature in HotelFeactures)
            {
                splithotelfeature = hotelfeature.featurestring.Split("//");
                listFeature.Add(new product_HotelFeactureDto()
                {
                    DisPlayNameF = splithotelfeature[0],
                    valueF = splithotelfeature[1]
                });
            }
            request.HotelFeactures = listFeature;
            var result = _facadeBussiness.AddBussinessService.Execute(request,userid);
            switch (result.Res)
            {
                case resMethod.Success:
                    TempData[SuccessMessage] = result.Message;
                    break;
                case resMethod.Error:
                    TempData[ErrorMessage] = result.Message;
                    break;
                case resMethod.Warning:
                    break;
                case resMethod.Info:
                    break;
                default:
                    break;
            }
            AddBussinessViewModel viewModel = new AddBussinessViewModel();
            viewModel.Category = _facadePattern.getCategoryService.GetCategory(null).Data
                .Where(a => a.Parent == null).ToList();
            return View(viewModel);
        }

        [AllowAnonymous]
        public IActionResult GetAllBussiness(Ordering Ordering = Ordering.Newest, long? categoryId=null, int page = 1
            , int pageSize = 15, string searchKey = null, string City = null, string region = null, float? LowPrice = null,
            float? MaxPrice=null, byte? score=null, byte? NumberRoom=null)
        {
            ParametrGetAllProduct parametr = new ParametrGetAllProduct() {categoryId=categoryId,City=City,LowPrice=LowPrice,MaxPrice=MaxPrice,NumberRoom=NumberRoom,Ordering=Ordering,page=page,pageSize=pageSize,region=region,score=score,searchKey=searchKey };
            var result = _facadeBussiness.GetAllBussinessService.Execute(parametr);
            List<SelectListItem> selects = new List<SelectListItem>();
            
            var model = new GetAllBussnessViewModel()
            {
                CatgegoryName = result.Data.CategoryName,
                ProdoctBriefVM = _mapper.Map<List<ProdoctBriefVM>>(result.Data.ProdoctbriefsDto),
                totalRow = result.Data.totalRow,
                
                
            };
            switch (result.Res)
            {
                case resMethod.Success:
                    TempData[SuccessMessage] = result.Message;
                    break;
                case resMethod.Error:
                    TempData[ErrorMessage] = result.Message;
                    break;
                case resMethod.Warning:
                    break;
                case resMethod.Info:
                    break;
                default:
                    break;
            }

            return View(model);
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult DetailBussinessMain(long id)
        {
            var viewModel = new DetailMainViewModel();

            var CacheDetail = _cache.GetAsync($"DetailBussiness{id}").Result;
            if (CacheDetail == null)
            {
                var result = _facadeBussiness.SiteDetailBussinessService.Execute(id);
                var JsonDetailData = JsonSerializer.Serialize(result.Data);
                byte[] ArrayDetailByte = Encoding.UTF8.GetBytes(JsonDetailData);
                var option = new DistributedCacheEntryOptions() { SlidingExpiration = TimeSpan.FromMinutes(1) };
                _cache.SetAsync($"DetailBussiness{id}", ArrayDetailByte, option);
                #region Add Data To VM           
                viewModel = _mapper.Map<DetailMainViewModel>(result.Data.Product);
                viewModel.ImageSrc = result.Data.Images.Count() < 3 ? result.Data.Images.Take(2).ToList() : result.Data.Images;
                viewModel.phoneNumber = result.Data.Address.phoneNumber;
                viewModel.Address = result.Data.Address.city + " " + result.Data.Address.Mantaghe + " " + result.Data.Address.Address;
                viewModel.product_Socials = result.Data.socialMedias;
                viewModel.longitude = result.Data.Address.longitude;
                viewModel.latitude = result.Data.Address.latitude;
                viewModel.City = result.Data.Address.city;
                viewModel.RelatedBussiness = _mapper.Map<List<ProdoctBriefVM>>(result.Data.RelatedBussiness);
                #endregion
                switch (result.Res)
                {
                    case resMethod.Success:
                        TempData[SuccessMessage] = result.Message;
                        break;
                    case resMethod.Error:
                        TempData[ErrorMessage] = result.Message;
                        break;
                    case resMethod.Warning:
                        TempData[WarningMessage] = result.Message;
                        break;
                    case resMethod.Info:
                        TempData[InfoMessage] = result.Message;
                        break;
                }
            }
            else
            {
                var res = JsonSerializer.Deserialize<DetailBussinessDto>(CacheDetail);
                viewModel = _mapper.Map<DetailMainViewModel>(res.Product);
                viewModel.ImageSrc = res.Images.Count() <= 4 ? res.Images.Take(2).ToList() : res.Images;
                viewModel.phoneNumber = res.Address.phoneNumber;
                viewModel.Address = res.Address.city + " " + res.Address.Mantaghe + " " + res.Address.Address;
                viewModel.product_Socials = res.socialMedias;
                viewModel.longitude = res.Address.longitude;
                viewModel.latitude = res.Address.latitude;
                viewModel.City = res.Address.city;
                viewModel.RelatedBussiness = _mapper.Map<List<ProdoctBriefVM>>(res.RelatedBussiness);
            }
            return View(viewModel);
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult DetailBussinessInfo(long id)
        {
            var resultCache = _cache.GetAsync($"DetailBussiness{id}").Result;
            if (resultCache != null)
            {
                var DetailBussiness = JsonSerializer.Deserialize<InformationDetailDto>(resultCache);
                #region Add Data To VM
                var viewModel = _mapper.Map<DetailBussinessInfoViewModel>(DetailBussiness.Product);
                viewModel.Address = DetailBussiness.Address.city + " " + DetailBussiness.Address.Mantaghe + " " + DetailBussiness.Address.Address;
                viewModel.phoneNumber = DetailBussiness.Address.phoneNumber;
                viewModel.product_Socials = DetailBussiness.socialMedias;
                viewModel.longitude = DetailBussiness.Address.longitude;
                viewModel.latitude = DetailBussiness.Address.latitude;
                viewModel.feactures = DetailBussiness.feactures;
                viewModel.hotelFeactures = DetailBussiness.hotelFeactures;
                viewModel.possibilities = DetailBussiness.possibilities;
                viewModel.rooms = DetailBussiness.rooms;
                viewModel.City = DetailBussiness.Address.city;
                viewModel.RelatedBussiness = _mapper.Map<List<ProdoctBriefVM>>(DetailBussiness.RelatedBussiness);
                #endregion
                return View(viewModel);
            }
            else
            {
                var DetailBussiness = _facadeBussiness.DetailInformationServer.Execute(id);
                #region Add Data To VM
                var viewModel = _mapper.Map<DetailBussinessInfoViewModel>(DetailBussiness.Product);
                viewModel.Address = DetailBussiness.Address.city + " " + DetailBussiness.Address.Mantaghe + " " + DetailBussiness.Address.Address;
                viewModel.phoneNumber = DetailBussiness.Address.phoneNumber;
                viewModel.product_Socials = DetailBussiness.socialMedias;
                viewModel.longitude = DetailBussiness.Address.longitude;
                viewModel.latitude = DetailBussiness.Address.latitude;
                viewModel.feactures = DetailBussiness.feactures;
                viewModel.hotelFeactures = DetailBussiness.hotelFeactures;
                viewModel.possibilities = DetailBussiness.possibilities;
                viewModel.rooms = DetailBussiness.rooms;
                viewModel.City = DetailBussiness.Address.city;
                viewModel.RelatedBussiness = _mapper.Map<List<ProdoctBriefVM>>(DetailBussiness.RelatedBussiness);
                #endregion
                return View(DetailBussiness);
            }

        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult DetailBussinessReviews(long id)
        {
            var result = _facadeBussiness.DetailCommentSiteService.Execute(id);
            var resultCache = JsonSerializer.Deserialize<DetailBussinessDto>(_cache.GetAsync($"DetailBussiness{id}").Result);
            result.RelatedBussiness = resultCache.RelatedBussiness;
            result.PersonalInformationDto = _facadePatternPersonalInformation.GetInformationService.Execute(ClailmUtility.GetUserId(User));
            return View(result);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddComment(CommentDetailDto dto, long id)
        {
            var userid = ClailmUtility.GetUserId(User);
            dto.AddCommentProductDto.userId = userid;
            var Comment = _facadeBussiness.AddCommentService.Execute(dto.AddCommentProductDto, id);
            return RedirectToAction(nameof(DetailBussinessReviews), new { id = id });
        }

    }
}
