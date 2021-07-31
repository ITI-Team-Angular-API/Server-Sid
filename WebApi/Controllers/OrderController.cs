
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using BL.AppServices;
using BL.ViewModel;
using DAL;
namespace WebApi.Controllers
{
    [RoutePrefix("api/Order")]
    public class OrderController : ApiController
    {
        ProductAppService productAppService = new ProductAppService();
        OrderAppService orderAppService = new OrderAppService();
        VisaAppService visaAppService = new VisaAppService();
        PaypalAppService PaypalAppService = new PaypalAppService();

        ShoppingCartAppService shoppingCartAppService = new ShoppingCartAppService();
        //[Authorize]
        //[HttpGet]
        //public IHttpActionResult Checkout()
        //{
        //    return VisaViewModel;
        //}
        // [Authorize]
        [HttpPost]
        [Route("Checkout")]
        // public IHttpActionResult Checkout(VisaViewModel visa, string PaymentMethod)
        // public IHttpActionResult Checkout([FromBody] VisaPaypalViewModel visaPaypalViewModel, [FromBody] string PaymentMethod)
        //public IHttpActionResult Checkout( VisaViewModel visa,  PaypalViewModel paypal, [FromUri] string PaymentMethod)
        public IHttpActionResult Checkout([FromBody] VisaPaypalPaymentMethods VisaPaypalPaymentMethods)

        {
            var visa = VisaPaypalPaymentMethods.visa;
            var paypal = VisaPaypalPaymentMethods.paypal;
            var PaymentMethod = VisaPaypalPaymentMethods.PaymentMethod;
            PaymentMethodViewModel payMethod = new PaymentMethodViewModel();
            payMethod.Method = VisaPaypalPaymentMethods.PaymentMethod;

            AccountAppService accountAppService = new AccountAppService();
            string id = accountAppService.FindByName(User.Identity.Name).Id;
            var shopCart = shoppingCartAppService.GetShoppingCart(id);

            var order = new OrderViewModel
            {
                PaymentMethod = payMethod,
                userId = shopCart.Id,
                totalPrice = shopCart.totalPrice,
                DateTime = DateTime.Now,
                OrderedProducts = new List<OrderedProducts>()
                
            };
            foreach (var item in shopCart.ShoppingCartProducts)
            {
                var orderProduct = new OrderedProducts
                {
                    productId = item.productId,
                    Quantity = item.Quantity

                };
                //var product = productAppService.GetProduct(item.productId);
                //product.Quantity -= item.Quantity;
                //productAppService.UpdateProduct(product);
                order.OrderedProducts.Add(orderProduct);
            }
            //shoppingCartAppService.DeleteShoppingCart(id);

            orderAppService.SaveNewOrder(order);

            if (PaymentMethod == "Visa")
            {
                
                 visa.Id = payMethod.Id;
                visaAppService.SaveNewVisa(visa);
                return Ok("your payment is visa");

            } 
            else if (PaymentMethod == "Paypal")
            {
                paypal.Id = payMethod.Id;
                PaypalAppService.SaveNewPaypal(paypal);
                return Ok("your Payment method is Paypal");

            }
            return BadRequest("your Payment method is not allowed in our site");
        }


    }
}