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
    public class OrderedProductsRepository : BaseRepository<OrderedProducts>
    {
        private DbContext EC_DbContext;

        public OrderedProductsRepository(DbContext EC_DbContext) : base(EC_DbContext)
        {
            this.EC_DbContext = EC_DbContext;
        }
        #region CRUB

        public List<OrderedProducts> GetAllOrderedProducts()
        {
            return GetAll().ToList();
        }

        public bool InsertOrderedProducts(OrderedProducts orderedProducts)
        {
            return Insert(orderedProducts);
        }
        public void UpdateOrderedProducts(OrderedProducts orderedProducts)
        {
            Update(orderedProducts);
        }
        public void DeleteOrderedProducts(int id)
        {
            Delete(id);
        }

        public bool CheckOrderedProductsExists(OrderedProducts orderedProducts)
        {
            return GetAny(l => l.Id == orderedProducts.Id);
        }
        public OrderedProducts GetOrderedProductsById(int id)
        {
            return GetFirstOrDefault(l => l.Id == id);
        }
        #endregion
    }
}
