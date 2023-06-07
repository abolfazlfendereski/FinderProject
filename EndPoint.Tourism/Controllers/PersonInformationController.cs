using FinderProject.Application.Interfaces.FacadPattern;
using FinderProject.Domian.Dto;
using FinderProject.Domian.Entities;
using MansStore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace EndPoint.FinderProject.Controllers
{
    [Authorize(Roles = "Customer")]
    public class PersonInformationController : SiteBaseController
    {
        private readonly IFacadePatternPersonalInformationInterface _personalInformation;
        private readonly IFacadePatternInterFaceBussiness _facadeBussiness;
        private readonly IFacadePatternInterfaces _facadeCategory;

        public PersonInformationController(IFacadePatternPersonalInformationInterface personalInformation, IFacadePatternInterFaceBussiness facadeBussiness, IFacadePatternInterfaces facadeCategory)
        {
            this._personalInformation = personalInformation;
            _facadeBussiness = facadeBussiness;
            _facadeCategory = facadeCategory;
        }
        [HttpGet]
        public IActionResult PersonalInformation()
        {
            var userid = ClailmUtility.GetUserId(User);
            var result = _personalInformation.GetInformationService.Execute(userid);
            result.HasBussiness = _personalInformation.GetOrderProductPersonalService.HasBussiness(userid);
            return View(result);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult PersonalInformation(PersonalInformationDto dto)
        {
            var userid = ClailmUtility.GetUserId(User);
            dto.UserId = userid;
            var result = _personalInformation.AddPersonalInformationService.Execute(dto);
            switch (result.Res)
            {
                case global::FinderProject.Common.Results.resMethod.Success:
                    TempData[SuccessMessage] = result.Message;
                    break;
                case global::FinderProject.Common.Results.resMethod.Error:
                    TempData[ErrorMessage] = result.Message;
                    break;
                case global::FinderProject.Common.Results.resMethod.Warning:
                    break;
                case global::FinderProject.Common.Results.resMethod.Info:
                    break;
            }
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult PersonalComments()
        {
            var userid = ClailmUtility.GetUserId(User);
            var result = new GetCommentPersonal()
            {
                HasBussiness = _personalInformation.GetOrderProductPersonalService.HasBussiness(userid),
                Comments = _personalInformation.GetUserCommentsService.Execute(userid),
                PersonalInformation = _personalInformation.GetInformationService.Execute(userid)
            };
            return View(result);
        }

        [HttpGet]
        public IActionResult PersonalFavorite()
        {

            var userid = ClailmUtility.GetUserId(User);
            var VM = new GetFavoritePersonal()
            {
                HasBussiness = _personalInformation.GetOrderProductPersonalService.HasBussiness(userid),
                ProdoctbriefDtos = _personalInformation.GetFavoriteService.Execute(userid),
                PersonalInformation = _personalInformation.GetInformationService.Execute(userid)
            };

            return View(VM);
        }
        
        public IActionResult AddFavorite(long id)
        {
            var userid = ClailmUtility.GetUserId(User);
            _personalInformation.MarkProductService.Execute(id, userid);
            return RedirectToAction("PersonalFavorite", "PersonInformation");
        }
        
        [HttpGet]
        public IActionResult GetMyOrders()
        {
            var userid = ClailmUtility.GetUserId(User);
            var result = _personalInformation.GetOrderProductPersonalService.GetOrderProductPersonal(userid);
            return View(result);
        }
        [HttpGet]
        public IActionResult GetAllOrders()
        {
            var userid = ClailmUtility.GetUserId(User);
            var result = _personalInformation.GetOrderProductPersonalService.GetOrdersPersonalInformation(userid);
            return View(result);
        }

        [HttpGet]
        public IActionResult GetUserBussiness()
        {
            var userid = ClailmUtility.GetUserId(User);
            var result = _personalInformation.GetUserBussinessService.Execute(userid); 
            return View(result);
        }

    }
}
