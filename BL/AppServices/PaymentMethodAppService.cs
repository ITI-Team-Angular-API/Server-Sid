using BL.Bases;
using DAL;
using System.Collections.Generic;

namespace BL.AppServices
{
    public class PaymentMethodAppService : AppServiceBase
    {
        #region CURD

        public List<PaymentMethod> GetAllPaymentMethods()
        {

            return TheUnitOfWork.PaymentMethod.GetAllPaymentMethod();
        }
        public PaymentMethod GetPaymentMethod(int id)
        {
            return TheUnitOfWork.PaymentMethod.GetPaymentMethodById(id);
        }



        public bool SaveNewPaymentMethod(PaymentMethod paymentMethod)
        {
            bool result = false;
            if (TheUnitOfWork.PaymentMethod.Insert(paymentMethod))
            {
                result = TheUnitOfWork.Commit() > new int();
            }
            return result;
        }


        public bool UpdatePaymentMethod(PaymentMethod paymentMethod)
        {
            TheUnitOfWork.PaymentMethod.Update(paymentMethod);
            TheUnitOfWork.Commit();

            return true;
        }


        public bool DeletePaymentMethod(int id)
        {
            bool result = false;

            TheUnitOfWork.PaymentMethod.Delete(id);
            result = TheUnitOfWork.Commit() > new int();

            return result;
        }

        public bool CheckPaymentMethodExists(PaymentMethod paymentMethod)
        {
            return TheUnitOfWork.PaymentMethod.CheckPaymentMethodExists(paymentMethod);
        }
        #endregion

    }
}
