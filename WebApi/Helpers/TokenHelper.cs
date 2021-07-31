using BL.ViewModel;
using DAL;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Web;

namespace WebApi.Helpers
{
    public class TokenHelper
    {
        public  static LoginRepsonse GenerateToken(ApplicationUserIDentity identityUser, bool isAdmin)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Helpers.ConfigHelper.GetSecurityKey());
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                                    new Claim(ClaimTypes.Name, identityUser.UserName),
                                    new Claim("UserId", identityUser.Id),
                                    new Claim("IsAdmin", isAdmin.ToString().ToLower()),
                                    new Claim("Email", identityUser.Email)
                }),
                Expires = DateTime.UtcNow.AddMinutes(ConfigHelper.GetTokenValidDuration()),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            string tokenStr = tokenHandler.WriteToken(token);

            return new LoginRepsonse()
            {
                Status = ResposeStatus.Succeeded,
                Message = "You  Logged in succeesfully" + (isAdmin ? " as Admin" : "") + " and your token generated successfully",
                Token = tokenStr,
                RefreshToken = "",
                UserName = identityUser.UserName,
                UserId = identityUser.Id,
                IsAdmin = isAdmin
            };
        }

    }
}