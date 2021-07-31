using BL.Bases;
using DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Repositories
{
    public class FavouriteProductsRepository : BaseRepository<FavouriteProducts>
    {
        private DbContext EC_DbContext;

        public FavouriteProductsRepository(DbContext EC_DbContext) : base(EC_DbContext)
        {
            this.EC_DbContext = EC_DbContext;
        }
        #region CRUB

        public List<FavouriteProducts> GetAllFavouriteProducts()
        {
            return GetAll().ToList();
        }

        public bool InsertFavouriteProducts(FavouriteProducts favouriteProducts)
        {
            return Insert(favouriteProducts);
        }
        public void UpdateFavouriteProducts(FavouriteProducts favouriteProducts)
        {
            Update(favouriteProducts);
        }
        public void DeleteFavouriteProducts(int id)
        {
            Delete(id);
        }

        public bool CheckFavouriteProductsExists(FavouriteProducts favouriteProducts)
        {
            return GetAny(l => l.Id == favouriteProducts.Id);
        }
        public FavouriteProducts GetFavouriteProductsById(int id)
        {
            return GetFirstOrDefault(l => l.Id == id);
        }
        #endregion
    }
}
