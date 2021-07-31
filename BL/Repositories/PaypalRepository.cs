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
    public class PaypalRepository : BaseRepository<Paypal>
    {
        private DbContext EC_DbContext;

        public PaypalRepository(DbContext EC_DbContext) : base(EC_DbContext)
        {
            this.EC_DbContext = EC_DbContext;
        }
        #region CRUB

        public List<Paypal> GetAllPaypal()
        {
            return GetAll().ToList();
        }

        public bool InsertPaypal(Paypal paypal)
        {
            return Insert(paypal);
        }
        public void UpdatePaypal(Paypal paypal)
        {
            Update(paypal);
        }
        public void DeletePaypal(int id)
        {
            Delete(id);
        }

        public bool CheckPaypalExists(Paypal paypal)
        {
            return GetAny(l => l.Id == paypal.Id);
        }
        public Paypal GetPaypalById(int id)
        {
            return GetFirstOrDefault(l => l.Id == id);
        }
        #endregion
    }
}
