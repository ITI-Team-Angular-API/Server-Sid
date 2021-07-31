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
    public class ShoppingCartProductsRepository : BaseRepository<ShoppingCartProducts>
    {
        private DbContext EC_DbContext;

        public ShoppingCartProductsRepository(DbContext EC_DbContext) : base(EC_DbContext)
        {
            this.EC_DbContext = EC_DbContext;
        }
        #region CRUB

        public List<ShoppingCartProducts> GetAllShoppingCartProducts()
        {
            return GetAll().ToList();
        }

        public bool InsertShoppingCartProducts(ShoppingCartProducts shoppingCartProducts)
        {
            return Insert(shoppingCartProducts);
        }
        public void UpdateShoppingCartProducts(ShoppingCartProducts shoppingCartProducts)
        {
            Update(shoppingCartProducts);
        }
        public void DeleteShoppingCartProducts(int id)
        {
            Delete(id);
        }

        public bool CheckShoppingCartProductsExists(ShoppingCartProducts shoppingCartProducts)
        {
            return GetAny(l => l.Id == shoppingCartProducts.Id);
        }
        public ShoppingCartProducts GetShoppingCartProductsById(int id)
        {
            return GetFirstOrDefault(l => l.Id == id);
        }
        #endregion
    }
}
