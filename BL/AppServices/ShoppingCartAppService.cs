using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.ViewModel;
using DAL;
using BL.Bases;

namespace BL.AppServices
{
    public class ShoppingCartAppService : AppServiceBase
    {
        #region CURD

        public List<ShoppingCartViewModel> GetAllShoppingCart()
        {

            return Mapper.Map<List<ShoppingCartViewModel>>(TheUnitOfWork.ShoppingCart.GetAllShoppingCart());
        }
        public ShoppingCartViewModel GetShoppingCart(string id)
        {
            return Mapper.Map<ShoppingCartViewModel>(TheUnitOfWork.ShoppingCart.GetShoppingCartById(id));
        }

        private ShoppingCart GetShoppingCartNotViewModel(string id)
        {
            return TheUnitOfWork.ShoppingCart.GetShoppingCartById(id);
        }



        public bool SaveNewShoppingCart(ShoppingCartViewModel ShoppingCartViewModel)
        {
            bool result = false;
            var ShoppingCart = Mapper.Map<ShoppingCart>(ShoppingCartViewModel);
            if (TheUnitOfWork.ShoppingCart.Insert(ShoppingCart))
            {
                result = TheUnitOfWork.Commit() > new int();
            }
            return result;
        }


        public bool UpdateShoppingCart(ShoppingCartViewModel ShoppingCartViewModel)
        {
            ShoppingCart shoppingCart = GetShoppingCartNotViewModel(ShoppingCartViewModel.Id);
            Mapper.Map(ShoppingCartViewModel, shoppingCart);
            TheUnitOfWork.ShoppingCart.Update(shoppingCart);
            TheUnitOfWork.Commit();

            return true;
        }


        public bool DeleteShoppingCart(string id)
        {
            bool result = false;

            TheUnitOfWork.ShoppingCart.Delete(id);
            result = TheUnitOfWork.Commit() > new int();

            return result;
        }

        public bool CheckOrderExists(ShoppingCartViewModel ShoppingCartViewModel)
        {
            ShoppingCart ShoppingCart = Mapper.Map<ShoppingCart>(ShoppingCartViewModel);
            return TheUnitOfWork.ShoppingCart.CheckShoppingCartExists(ShoppingCart);
        }

        public void AddProduct(string userId, int productId)
        {
            ShoppingCartAppService shoppingCartAppService = new ShoppingCartAppService();
            ProductAppService ProductsAppService = new ProductAppService();
            ShoppingCartViewModel shoppingCart = shoppingCartAppService.GetShoppingCart(userId);
            if (shoppingCart == null)
            {
                shoppingCart = new ShoppingCartViewModel();
                shoppingCart.Id = userId;
                shoppingCart.totalPrice = 0;
                shoppingCartAppService.SaveNewShoppingCart(shoppingCart);
            }
            if (shoppingCart.ShoppingCartProducts == null)
            {
                shoppingCart.ShoppingCartProducts = new List<ShoppingCartProducts>();
                shoppingCart.ShoppingCartProducts.Add(new ShoppingCartProducts() { Quantity = 1, productId = productId });
                shoppingCart.totalPrice += ProductsAppService.GetProduct(productId).Price;
            }
            else
            {
                bool productAlreadyAdded = false;
                foreach (ShoppingCartProducts shoppingCartProducts in shoppingCart.ShoppingCartProducts)
                {
                    if (shoppingCartProducts.productId == productId)
                    {
                        productAlreadyAdded = true;
                    }
                }
                if (!productAlreadyAdded)
                {
                    shoppingCart.ShoppingCartProducts.Add(new ShoppingCartProducts() { Quantity = 1, productId = productId });
                    shoppingCart.totalPrice += ProductsAppService.GetProduct(productId).Price;
                }
            }
            shoppingCartAppService.UpdateShoppingCart(shoppingCart);
        }
        #endregion

    }
}
