using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;

namespace WebApi.Helpers
{
    public class UserInfoHelper
    {
        public static UserInfo GetUserDetails() {
            var user = HttpContext.Current.User;
            if (user.Identity.IsAuthenticated)
            {
                var identity = (ClaimsIdentity)HttpContext.Current.User.Identity;
                IEnumerable<Claim> claims = identity.Claims;
                var email = claims.FirstOrDefault(c => c.Type == "Email")?.Value;
                var userName = claims.FirstOrDefault(c => c.Type.EndsWith("name"))?.Value;
                var userId = claims.FirstOrDefault(c => c.Type == "UserId")?.Value;

                return new UserInfo()
                {
                    Email = email,
                    UserName = userName,
                    UserId = userId,
                    IsAuthenticated = identity.IsAuthenticated
                };
            }
            else return null;
        }
    }
}