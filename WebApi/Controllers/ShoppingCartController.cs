using AutoMapper;
using BL.AppServices;
using BL.Configur;
using BL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace WebApi.Controllers
{
    [RoutePrefix("api/ShoppingCart")]
    public class ShoppingCartController : ApiController

    {
        protected readonly IMapper Mapper = MapperConfig.Mapper;
        ShoppingCartAppService shoppingCartAppService = new ShoppingCartAppService();
        ProductAppService ProductsAppService = new ProductAppService();
        ShoppingCartProductsAppService shoppinfCartProductAppService = new ShoppingCartProductsAppService();
       
        [HttpGet]
        [Route("ViewCart")]
        //[Authorize]
        
        public IHttpActionResult ViewCart()

        //public List<ProductViewModel> ViewCart()
        {
            AccountAppService accountAppService = new AccountAppService();
            string id = accountAppService.FindByName(User.Identity.Name).Id;
            var shopCart = shoppingCartAppService.GetShoppingCart(id);
            //if (shopCart == null)
            //    return View(shopCart);
            var Products = new List<ProductViewModel>();
            foreach (var item in shopCart.ShoppingCartProducts)
            {
                Products.Add(ProductsAppService.GetProduct(item.productId));
            }
          //  ViewBag.ShopingCartProducrs = Products;
            return Ok (Products);
        }
        [HttpPost]
        [Route("RemoveProduct")]
        [Authorize]
        public IHttpActionResult RemoveProduct(int ShopCartProductId, double price, int quantity)
        {
            AccountAppService accountAppService = new AccountAppService();
            string ShopCartId = accountAppService.FindByName(User.Identity.Name).Id;

            var shoppingcart = shoppingCartAppService.GetShoppingCart(ShopCartId);
            //var productId = shoppinfCartProductAppService.GetShoppingCartProducts(ShopCartProductId).productId;
            shoppingcart.totalPrice -= price * quantity; //shoppinfCartProductAppService.GetShoppingCartProducts(ShopCartProductId).Quantity * ProductsAppService.GetProduct(productId).Price;

            shoppinfCartProductAppService.DeleteShoppingCartProducts(ShopCartProductId);
            shoppingCartAppService.UpdateShoppingCart(shoppingcart);
            //  return RedirectToAction("ViewCart", new { id = ShopCartId });
            return Ok(shoppingCartAppService.GetShoppingCart(shoppingcart.Id));
        }

    }
}