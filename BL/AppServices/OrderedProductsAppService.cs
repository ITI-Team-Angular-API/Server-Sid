using BL.Bases;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.AppServices
{
    class OrderedProductsAppService : AppServiceBase
    {
        #region CURD

        public List<OrderedProducts> GetAllOrderedProducts()
        {

            return TheUnitOfWork.OrderedProducts.GetAllOrderedProducts();
        }
        public OrderedProducts GetOrderedProducts(int id)
        {
            return TheUnitOfWork.OrderedProducts.GetOrderedProductsById(id);
        }



        public bool SaveNewOrderedProducts(OrderedProducts orderedProducts)
        {
            bool result = false;
            if (TheUnitOfWork.OrderedProducts.Insert(orderedProducts))
            {
                result = TheUnitOfWork.Commit() > new int();
            }
            return result;
        }


        public bool UpdateOrderedProducts(OrderedProducts orderedProducts)
        {
            TheUnitOfWork.OrderedProducts.Update(orderedProducts);
            TheUnitOfWork.Commit();

            return true;
        }


        public bool DeleteOrderedProducts(int id)
        {
            bool result = false;

            TheUnitOfWork.OrderedProducts.Delete(id);
            result = TheUnitOfWork.Commit() > new int();

            return result;
        }

        public bool CheckOrderExists(OrderedProducts orderedProducts)
        {
            return TheUnitOfWork.OrderedProducts.CheckOrderedProductsExists(orderedProducts);
        }
        #endregion

    }
}
