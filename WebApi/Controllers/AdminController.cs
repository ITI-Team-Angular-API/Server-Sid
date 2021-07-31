using BL.AppServices;
using BL.ViewModel;
using DAL;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using WebApi.Helpers;

namespace WebApi.Controllers
{
    // [Authorize(Roles = "Admin")]
    [RoutePrefix("api/Account")]
    public class AdminController : ApiController
    {

        AccountAppService accountAppService = new AccountAppService();
        [HttpPost]
        [Route("AddAdmin")]

        public IHttpActionResult AddAdmin(RegisterViewodel admin)
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

                IdentityResult result = accountAppService.Register(admin);
                if (result.Succeeded)
                {
                    IAuthenticationManager owinMAnager = HttpContext.Current.GetOwinContext().Authentication;
                    ApplicationUserIDentity identityUser = accountAppService.Find(admin.UserName, admin.Password);
                    accountAppService.AssignToRole(identityUser.Id, "Admin");

                    LoginRepsonse response = TokenHelper.GenerateToken(identityUser, true);
                    //return (RegisterResponse) response;

                    return Ok(new RegisterResponse()
                    {
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
                    return Ok(new RegisterResponse()
                    {
                        Status = ResposeStatus.Failed,
                        Message = string.Join(", ", result.Errors.ToArray())
                    });
                }
            }
        }

    }
}
