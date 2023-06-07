using Microsoft.AspNetCore.Authentication;
using System.Collections.Generic;

namespace EndPoint.FinderProject.Controllers
{
    public class loginViewModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }
        public string ReturnUrl { get; set; }
        public IList<AuthenticationScheme> ExternalLogins { get; set; }
    }
}