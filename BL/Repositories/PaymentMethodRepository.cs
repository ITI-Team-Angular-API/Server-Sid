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
    public class PaymentMethodRepository : BaseRepository<PaymentMethod>
    {
        private DbContext EC_DbContext;

        public PaymentMethodRepository(DbContext EC_DbContext) : base(EC_DbContext)
        {
            this.EC_DbContext = EC_DbContext;
        }
        #region CRUB

        public List<PaymentMethod> GetAllPaymentMethod()
        {
            return GetAll().ToList();
        }

        public bool InsertPaymentMethod(PaymentMethod paymentMethod)
        {
            return Insert(paymentMethod);
        }
        public void UpdatePaymentMethod(PaymentMethod paymentMethod)
        {
            Update(paymentMethod);
        }
        public void DeletePaymentMethod(int id)
        {
            Delete(id);
        }

        public bool CheckPaymentMethodExists(PaymentMethod paymentMethod)
        {
            return GetAny(l => l.Id == paymentMethod.Id);
        }
        public PaymentMethod GetPaymentMethodById(int id)
        {
            return GetFirstOrDefault(l => l.Id == id);
        }
        #endregion
    }
}
