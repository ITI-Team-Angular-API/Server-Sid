using BL.Bases;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.AppServices
{
    public class FavouriteProductsAppService : AppServiceBase
    {
        #region CURD

        public List<FavouriteProducts> GetAllFavouriteProducts()
        {

            return TheUnitOfWork.FavouriteProducts.GetAllFavouriteProducts();
        }
        public FavouriteProducts GetFavouriteProducts(int id)
        {
            return TheUnitOfWork.FavouriteProducts.GetFavouriteProductsById(id);
        }



        public bool SaveNewFavouriteProducts(FavouriteProducts favouriteProducts)
        {
            bool result = false;
            if (TheUnitOfWork.FavouriteProducts.Insert(favouriteProducts))
            {
                result = TheUnitOfWork.Commit() > new int();
            }
            return result;
        }


        public bool UpdateFavouriteProducts(FavouriteProducts favouriteProducts)
        {
            TheUnitOfWork.FavouriteProducts.Update(favouriteProducts);
            TheUnitOfWork.Commit();

            return true;
        }


        public bool DeleteFavouriteProducts(int id)
        {
            bool result = false;

            TheUnitOfWork.FavouriteProducts.Delete(id);
            result = TheUnitOfWork.Commit() > new int();

            return result;
        }

        public bool CheckFavouriteProductsExists(FavouriteProducts favouriteProducts)
        {
            return TheUnitOfWork.FavouriteProducts.CheckFavouriteProductsExists(favouriteProducts);
        }

        public void AddProductToUserList(string userId, int productId)
        {
          
            FavouriteProducts newFavList = new FavouriteProducts
            {
                userId = userId,
                productId = productId
            };
            SaveNewFavouriteProducts(newFavList);
        }
        #endregion

    }
}
