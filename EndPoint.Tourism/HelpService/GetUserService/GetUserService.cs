using FinderProject.Domian.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EndPoint.FinderProject.HelpService.GetUserService
{
    public class GetUserService
    {
        private readonly UserManager<User> userManager;
        public GetUserService(UserManager<User> userManager)
        {
            this.userManager = userManager;
        }
        public  async Task<User> GetUser(string userId)
        {
            var User =await userManager.FindByIdAsync(userId);
            return User;
        }
    }
}
