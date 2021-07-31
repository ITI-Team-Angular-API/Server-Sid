using BL.AppServices;
using BL.ViewModel;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web;
using Microsoft.AspNet.Identity.Owin;
using DAL;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using WebApi.Helpers;
using AutoMapper;
using BL.Configur;

namespace WebApi.Controllers
{
    [RoutePrefix("api/Account")]
    public class AccountController : ApiController
    {
        AccountAppService accountAppService = new AccountAppService();

       
        [HttpGet]
        [Route("testAction")]
        public KeyValuePair<string,string> TestAction()
        {
            return new KeyValuePair<string, string>("12",  "Barm");
        }
        //public enum ResposeStatus
        //{
        //    Succeeded,
        //    Failed,
        //    Exception,

        //}
        //public class Response
        //{
        //    public ResposeStatus Status { get; set; }
        //    public string Message { get; set; }
        //}
        [HttpPost]
        [Route("register")]
        public IHttpActionResult Register(RegisterViewodel user)
        {
            if (ModelState.IsValid == false)
            {               
                return Ok(new RegisterResponse()
                {
                    Status = ResposeStatus.Failed,
                    Message = "You should supply the following details : Username, Password, Confirmpassword"
                });
            }
            else
            {

                IdentityResult result = accountAppService.Register(user);
                if (result.Succeeded)
                {
                    IAuthenticationManager owinMAnager = HttpContext.Current.GetOwinContext().Authentication;
                    ApplicationUserIDentity identityUser = accountAppService.Find(user.UserName, user.Password);

                    LoginRepsonse response = TokenHelper.GenerateToken(identityUser, false);
                    //return (RegisterResponse) response;
                    
                    return Ok(new RegisterResponse() { 
                    IsAdmin = response.IsAdmin,
                    Message = response.Message,
                    RefreshToken = response.RefreshToken,
                    Token = response.Token,
                    Status = response.Status,
                    UserId = response.UserId,
                    UserName = response.UserName
                    });
                }
                else
                {
                    return Ok( new RegisterResponse()
                    {
                        Status = ResposeStatus.Failed,
                        Message = string.Join(", ", result.Errors.ToArray())
                    });
                }
            }
        }
        //public IHttpActionResult test(LoginViewModel user)
        //{
        //    { return BadRequest(ModelState); }

        //}
        [Route("Login")]
        public IHttpActionResult Login(LoginViewModel user)
        {
            if (string.IsNullOrEmpty(user.UserName) || string.IsNullOrEmpty(user.Password))
            {
                return Ok(new RegisterResponse()
                {
                    Status = ResposeStatus.Failed,
                    Message = "You should supply the following details : Username, Password"
                });
            }
            else
            {
                ApplicationUserIDentity identityUser = accountAppService.Find(user.UserName, user.Password);

                if (identityUser != null)
                {
                    IAuthenticationManager owinMAnager = HttpContext.Current.GetOwinContext().Authentication;
                    //SignIn

                    /*SignInManager<ApplicationUserIDentity, string> signinmanager =
                        new SignInManager<ApplicationUserIDentity, string>(
                            new ApplicationUserManager(), owinMAnager
                            );
                    signinmanager.SignIn(identityUser, true, true);*/

                    var isAdmin = accountAppService.HasRole(identityUser.Id, "Admin");

                    TokenHelper a = new TokenHelper();

                    return Ok( TokenHelper.GenerateToken(identityUser, isAdmin));


                }
                else
                {
                    // ModelState.AddModelError("", "Not Valid Username OR Password");
                    // return View(user);
                  

                    return Ok(new RegisterResponse()
                    {
                        Status = ResposeStatus.Failed,
                        Message = "Your Username OR Password is invalid"
                    });
                }

            }
        
        }

        //private static LoginRepsonse GenerateToken(ApplicationUserIDentity identityUser, bool isAdmin)
        //{
        //    var tokenHandler = new JwtSecurityTokenHandler();
        //    var key = Encoding.ASCII.GetBytes(Helpers.ConfigHelper.GetSecurityKey());
        //    var tokenDescriptor = new SecurityTokenDescriptor
        //    {
        //        Subject = new ClaimsIdentity(new Claim[]
        //        {
        //                            new Claim(ClaimTypes.Name, identityUser.UserName),
        //                            new Claim("UserId", identityUser.Id),
        //                            new Claim("IsAdmin", isAdmin.ToString().ToLower()),
        //                            new Claim("Email", identityUser.Email)
        //        }),
        //        Expires = DateTime.UtcNow.AddMinutes(ConfigHelper.GetTokenValidDuration()),
        //        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
        //            SecurityAlgorithms.HmacSha256Signature)
        //    };
        //    var token = tokenHandler.CreateToken(tokenDescriptor);
        //    string tokenStr = tokenHandler.WriteToken(token);

        //    return new LoginRepsonse()
        //    {
        //        Status = ResposeStatus.Succeeded,
        //        Message = "You  Logged in succeesfully" + (isAdmin ? " as Admin" : "") + " and your token generated successfully",
        //        Token = tokenStr,
        //        RefreshToken = "",
        //        UserName = identityUser.UserName,
        //        UserId = identityUser.Id
        //    };
        //}

        //[Authorize]
        //[Route("Logout")]

        //public IHttpActionResult Logout()
        //{
        //    IAuthenticationManager owinMAnager = HttpContext.Current.GetOwinContext().Authentication;

        //    owinMAnager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
        //    return Ok();
        //}

    }
}
