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

namespace WebApi.Controllers
{
    [RoutePrefix("api/Home")]
    public class HomeController : ApiController
    {
        //AccountAppService accountAppService = new AccountAppService();
        CategoryAppService categoryAppService = new CategoryAppService();
        ProductAppService productAppService = new ProductAppService();

        [HttpGet]
        [Route("GetUserInfo")]
        public UserInfo GetUserInfo()
        {
            var currentUserInfo = UserInfoHelper.GetUserDetails();
            return currentUserInfo;
        }
        [HttpGet]
        [Route("Search")]
        public List<ProductViewModel> Search(string proName)
        {
            //ViewBag.categories = categoryAppService.GetAllCategories();
            List<ProductViewModel> productViewModels = productAppService.Search(proName);
            //return View("index", productViewModels);
            return productViewModels;
        }
        [HttpGet]
        [Route("GetProductById")]
        public ProductViewModel Product(int id)
        {
            ProductViewModel productViewModel = productAppService.GetProduct(id);
            return productViewModel;
        }



    }
}
