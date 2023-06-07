using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MansStore
{
    public static class ClailmUtility
    {
        public static string GetUserId(ClaimsPrincipal User)
        {
            if (User.Identity.Name==null)
            {
                return null;
            }
            else
            {
                var ClaimIdentity = User.Identity as ClaimsIdentity;
                string UserId = ClaimIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
                return UserId;
            } 
        }
    }
}
