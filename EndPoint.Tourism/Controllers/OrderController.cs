using AutoMapper;
using EndPoint.FinderProject.Models;
using FinderProject.Application.Interfaces.FacadPattern;
using FinderProject.Domian.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EndPoint.FinderProject.Controllers
{
    [Authorize(Roles = "Customer")]
    public class OrderController : SiteBaseController
    {
        private readonly IFacadePatternInterFaceBussiness _facadePattern;
        private readonly IFacadePatternOrderInterFace _orderFacade;
        private readonly IMapper _mapper;

        public OrderController(IFacadePatternInterFaceBussiness facadePattern,
            IFacadePatternOrderInterFace orderFacade,IMapper mapper)
        {
            this._facadePattern = facadePattern;
            this._orderFacade = orderFacade;
            this._mapper = mapper;
        }
        [HttpGet]
        public IActionResult bookBussiness(long id)
        {
            var Product = _facadePattern.getBussinessInfoService.GetBussiness(id);
            return View(Product);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult bookBussiness(AddOrderBussinessViewModel model)
        {
            var bussiness = _mapper.Map<BookBussinessDto>(model);
            var result = _orderFacade.AddOrderService.Execute(bussiness);
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
            var Product = _facadePattern.getBussinessInfoService.GetBussiness(model.BussinessId);
            if (Product.CategoryName=="هتل")
            {
                // Use ZarinPal to Pay
            }
            return View(Product);
        }      
       

        //public async Task<IActionResult> Index()
        //{

        //    Cookiemanager cookiemanager = new Cookiemanager();
        //    BlCart blCart = new BlCart();
        //    var Userid = ClailmUtility.GetUserId(User);
        //    var Product = blCart.ListCart(cookiemanager.GetBrowserId(HttpContext), Userid);
        //    if (Product.Sum > 0)
        //    {

        //        var Result = bll.GetRequest(Userid, Product.Sum);
        //        //درگاه پرداخت
        //        var result = await _payment.Request(new DtoRequest()
        //        {

        //            CallbackUrl = $"https://localhost:44326/Order/ResultPay?guid={Result.Id}",
        //            Description = $"پرداخت شماره :1",
        //            Email = Result.Email,
        //            Amount = Convert.ToInt32(Result.Amount),
        //            MerchantId = "XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX"
        //        }, ZarinPal.Class.Payment.Mode.sandbox);
        //        return Redirect($"https://sandbox.zarinpal.com/pg/StartPay/{result.Authority}");

        //    }
        //    else
        //    {
        //        return RedirectToAction("index", "Cart");
        //    }

        //}
        //public async Task<IActionResult> ResultPay(Guid guid, string Status, string authority)
        //{
        //    var Userid = ClailmUtility.GetUserId(User);
        //    var verification = await _payment.Verification(new DtoVerification
        //    {
        //        Amount = bll.GetAmount(guid),
        //        MerchantId = "XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX",
        //        Authority = authority
        //    }, Payment.Mode.sandbox);
        //    if (verification.Status == -33)
        //    {
        //        bll.AddOrder(new orderdto() { Authority = authority, RefId = verification.RefId, Userid = Userid });
        //        return RedirectToAction("SuccessPay");
        //    }
        //    else
        //    {
        //        return RedirectToAction("Failure");
        //    }
        //}
    }
}
