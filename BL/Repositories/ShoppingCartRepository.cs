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
    public class ShoppingCartRepository : BaseRepository<ShoppingCart>
    {
        private DbContext EC_DbContext;

        public ShoppingCartRepository(DbContext EC_DbContext) : base(EC_DbContext)
        {
            this.EC_DbContext = EC_DbContext;
        }
        #region CRUB

        public List<ShoppingCart> GetAllShoppingCart()
        {
            return GetAll().ToList();
        }

        public bool InsertShoppingCart(ShoppingCart shoppingCart)
        {
            return Insert(shoppingCart);
        }
        public void UpdateShoppingCart(ShoppingCart product)
        {
            Update(product);
        }
        public void DeleteShoppingCart(string id)
        {
            Delete(id);
        }

        public bool CheckShoppingCartExists(ShoppingCart shoppingCart)
        {
            return GetAny(l => l.Id == shoppingCart.Id);
        }
        public ShoppingCart GetShoppingCartById(string id)
        {
            return GetWhere(l => l.Id == id)
                .Include(s => s.ShoppingCartProducts)
                .FirstOrDefault();
        }
        #endregion
    }
}
