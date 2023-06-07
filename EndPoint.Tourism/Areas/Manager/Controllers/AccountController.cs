using FinderProject.Domian.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EndPoint.FinderProject.Areas.Manager.Controllers
{
    [Area("Manager")]
    public class AccountController : BaseController
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public AccountController(RoleManager<IdentityRole> roleManager, UserManager<User> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users =await _userManager.GetUsersInRoleAsync("Customer");
            return View(users);
        }
        public async Task<IActionResult> LockUser(string userid)
        {
            var user =await _userManager.FindByIdAsync(userid);
            if (user == null) return null;
            var result = await _userManager.SetLockoutEnabledAsync(user, true);
            await _userManager.SetLockoutEndDateAsync(user, DateTimeOffset.MaxValue);
            return Redirect("/Manager/Account/GetAllUsers");
        }
        public async Task<IActionResult> UnLockUser(string userid)
        {
            var user = await _userManager.FindByIdAsync(userid);
            var result = await _userManager.SetLockoutEnabledAsync(user,false);
            await _userManager.SetLockoutEndDateAsync(user, DateTimeOffset.Now);
            return Redirect("/Manager/Account/GetAllUsers"); 
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAdmins()
        {
            var admins =await _userManager.GetUsersInRoleAsync("Admin");
            return View(admins);
        }
        public async Task<IActionResult> LockAdmin(string adminid)
        {
            var user = await _userManager.FindByIdAsync(adminid);
            if (user == null) return null;
            var result = await _userManager.SetLockoutEnabledAsync(user, true);
            await _userManager.SetLockoutEndDateAsync(user, DateTimeOffset.MaxValue);
            
            return Redirect("/Manager/Account/GetAllAdmins");
        }
        public async Task<IActionResult> UnLockAdmin(string adminid)
        {
            var user = await _userManager.FindByIdAsync(adminid);
            var result = await _userManager.SetLockoutEnabledAsync(user, false);
            await _userManager.SetLockoutEndDateAsync(user, DateTimeOffset.Now);
            return Redirect("/Manager/Account/GetAllAdmins");
        }
    }
}
