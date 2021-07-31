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
    public class OrderRepository : BaseRepository<Order>
    {
        private DbContext EC_DbContext;

        public OrderRepository(DbContext EC_DbContext) : base(EC_DbContext)
        {
            this.EC_DbContext = EC_DbContext;
        }
        #region CRUB

        public List<Order> GetAllOrder()
        {
            return GetAll().ToList();
        }

        public bool InsertOrder(Order order)
        {
            return Insert(order);
        }
        public void UpdateOrder(Order order)
        {
            Update(order);
        }
        public void DeleteOrder(int id)
        {
            Delete(id);
        }

        public bool CheckOrderExists(Order order)
        {
            return GetAny(l => l.Id == order.Id);
        }
        public Order GetOrderById(int id)
        {
            return GetFirstOrDefault(l => l.Id == id);
        }

        public List<Order> OrderByTimeDecending()
        {
            return EC_DbContext.Set<Order>().OrderByDescending(o => o.DateTime).Include(o=>o.appUser).ToList();
        }
        #endregion
    }
}
