using EndPoint.FinderProject.HelpService.EmailService;
using EndPoint.FinderProject.Models;
using EndPoint.FinderProject.Models.EmailClasses;
using FinderProject.Domian.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace EndPoint.FinderProject.Controllers
{
    public class AccountController : SiteBaseController
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IEmailService _emailService;

        public AccountController(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, SignInManager<User> signInManager, IEmailService emailService)
        {
            this._userManager = userManager;
            this._roleManager = roleManager;
            this._signInManager = signInManager;
            _emailService = emailService;
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(string returnUrl,RegisterViewModel model)
        {
            returnUrl = string.IsNullOrEmpty(returnUrl) ? "/Home/Index" : returnUrl;
            if (ModelState.IsValid)
            {
                await CreateAdminAndManager();
                await CreateRoles();
                var user = new User()
                {
                    UserName=model.Email,
                    Email = model.Email,
                    FullName = model.FullName
                };
                var result =await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user,"Customer");
                    return Redirect(Url.IsLocalUrl(returnUrl)?returnUrl:"/Home/Index");
                }
                else
                {
                     AddErrors(result);
                }
            }
            ViewBag.returnurl = returnUrl;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(string returnUrl,LoginViewModel model)
        {
            returnUrl = string.IsNullOrEmpty(returnUrl) ? "/Home/Index" : returnUrl;
            if (ModelState.IsValid)
            {
                await CreateAdminAndManager();
                var user =await _userManager.FindByEmailAsync(model.Email);
                if (user != null)
                {
                    if (await _userManager.IsInRoleAsync(user,"Manager"))
                    {
                        return Redirect("/Manager/Home/Index");
                    }
                    else if (await _userManager.IsInRoleAsync(user, "Admin"))
                    {
                        return Redirect("/Admin/Home/Index");
                    }
                    else
                    {
                        var result = await _signInManager.PasswordSignInAsync(user, model.Password, false, false);
                        if (result.Succeeded)
                        {
                            return Redirect(Url.IsLocalUrl(returnUrl) ? returnUrl : "/Home/Index");
                        }
                    }
                   
                   
                }
                else
                {
                    ModelState.AddModelError("","چنین کاربری موجود نمیباشد");
                }
            }
            return RedirectToAction("Index", "Home");
        }
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index","Home");
        }         
        [HttpPost]        
        public async Task<IActionResult> ForgotPassword(string Email)
        {
            if (Email !=null)
            {
                var user = await _userManager.FindByEmailAsync(Email);
                var TokenResetPassword = await _userManager.GeneratePasswordResetTokenAsync(user);
                var redirectUrl = Url.Action("ConfirmResetPassword", "Account", new { user, TokenResetPassword }, protocol: HttpContext.Request.Scheme);

                var result = _emailService.SendMail(new MailData
                {
                    Email = Email,
                    EmailToName = Email,
                    Subject = "ResetPassword",
                    Body = " Please reset your password by clicking here: < a href =\"" + redirectUrl + "\">link</a>"
                });
            }
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public IActionResult ConfirmResetPassword(string TokenResetPassword)
        {
            return TokenResetPassword == null ? View("Error") : View(new ResetPasswordViewModel() {TokenResetPassword=TokenResetPassword } );
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmResetPassword(ResetPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user =await _userManager.FindByEmailAsync(model.Email);
                if (user!=null)
                {
                    var result =await _userManager.ResetPasswordAsync(user,model.TokenResetPassword,model.Password);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        return View("Error");
                    }
                }
            }
            return View();
        }
        
        public IActionResult ExternalLogin(string provider)
        {
            var RedirectUrl = Url.Action("CallBackExternalLogin", "Account");
            var properties = _signInManager.ConfigureExternalAuthenticationProperties(provider,RedirectUrl);
            return new ChallengeResult(provider, properties);
        }
        public async Task<IActionResult> CallBackExternalLogin(string returnUrl, string remoteError = null)
        {
            if (remoteError != null)
            {
                ModelState.AddModelError("", $"Error : {remoteError}");
            }
            var model = new loginViewModel()
            {
                ReturnUrl = returnUrl,
                ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList()
            };
            var externalInfo = await _signInManager.GetExternalLoginInfoAsync();
            if (externalInfo == null)
            {
                ModelState.AddModelError("ErrorLoadingExternalLoginInfo", $"مشکلی پیش آمد");
                return View("Login", model);
            }
            var result = await _signInManager.ExternalLoginSignInAsync(externalInfo.LoginProvider, externalInfo.ProviderKey, isPersistent: false);

            if (result.Succeeded)
            {
                return Redirect(returnUrl);
            }
            var email = externalInfo.Principal.FindFirstValue(ClaimTypes.Email);//get the Current User login email or another information

            if (email != null)
            {
                var user = await _userManager.FindByEmailAsync(email);
                if (user == null)
                {
                    var userName = email.Split('@')[0];
                    user = new User()
                    {
                        UserName = (userName.Length <= 10 ? userName : userName.Substring(0, 10)),
                        Email = email,
                        EmailConfirmed = true
                    };

                    await _userManager.CreateAsync(user);
                }

                await _userManager.AddLoginAsync(user, externalInfo);//set the external Info For user in input
                await _signInManager.SignInAsync(user, false);

                return Redirect(returnUrl);
            }


            return View();

        }




        #region Internal methods
        [HttpPost]
        public async Task<IActionResult> IsEmailInUse(string email)
        {
            var result = await _userManager.FindByEmailAsync(email);
            if (result == null) return Json(true);
            return Json("ایمیل از قبل وارد شده است");
        }
        private async Task<IActionResult> CreateAdminAndManager()
        {
            var admin = await _userManager.FindByEmailAsync("AdminSite@info.com");
            var manager = await _userManager.FindByEmailAsync("ManagerSite@info.com");
            if (admin == null && manager == null)
            {
                //Create Admin Account
                var Admin = new User() { Email = "AdminSite@info.com", FullName = "AhamadFendereski",UserName= "AdminSite@info.com" };
                var AdminPass = "Abolfazl@56367773";
              var res1=  await _userManager.CreateAsync(Admin, AdminPass);
                await _userManager.AddToRoleAsync(Admin,"Admin");

                //Create Manager Account
                var Manager = new User() { Email = "ManagerSite@info.com", FullName = "ManagerFendereski" ,UserName= "ManagerSite@info.com" };
                var ManagerPass = "Abolfazl@56376683";
               var res2= await _userManager.CreateAsync(Manager, ManagerPass);
                await _userManager.AddToRoleAsync(Manager, "Manager");
            }
            return null;
        }
        private async Task<IActionResult> CreateRoles()
        {
            var RoleAdmin = await _roleManager.RoleExistsAsync("Admin");
            var RoleManager = await _roleManager.RoleExistsAsync("Manager");
            var RoleCustomer = await _roleManager.RoleExistsAsync("Customer");
            if (RoleAdmin==false && RoleCustomer==false && RoleManager==false )
            {
                await _roleManager.CreateAsync(new IdentityRole() {Name="Admin" });
                await _roleManager.CreateAsync(new IdentityRole() {Name="Manager" });
                await _roleManager.CreateAsync(new IdentityRole() {Name="Customer" });
            }
            return null;
        }
        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }
        #endregion
    }
}
    