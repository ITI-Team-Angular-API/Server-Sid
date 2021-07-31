using BL.Bases;
using BL.ViewModel;
using DAL;
using System.Collections.Generic;

namespace BL.AppServices
{
    public class PaypalAppService : AppServiceBase
    {
        #region CURD

        public List<PaypalViewModel> GetAllPaypals()
        {

            return Mapper.Map<List<PaypalViewModel>>(TheUnitOfWork.Paypal.GetAllPaypal());
        }
        public PaypalViewModel GetPaypal(int id)
        {
            return Mapper.Map<PaypalViewModel>(TheUnitOfWork.Paypal.GetPaypalById(id));
        }



        public bool SaveNewPaypal(PaypalViewModel paypalViewModel)
        {
            bool result = false;
            var paypal = Mapper.Map<Paypal>(paypalViewModel);
            if (TheUnitOfWork.Paypal.Insert(paypal))
            {
                result = TheUnitOfWork.Commit() > new int();
            }
            return result;
        }


        public bool UpdatePaypal(PaypalViewModel paypalViewModel)
        {
            var paypal = Mapper.Map<Paypal>(paypalViewModel);
            TheUnitOfWork.Paypal.Update(paypal);
            TheUnitOfWork.Commit();

            return true;
        }


        public bool DeletePaypal(int id)
        {
            bool result = false;

            TheUnitOfWork.Paypal.Delete(id);
            result = TheUnitOfWork.Commit() > new int();

            return result;
        }

        public bool CheckPaypalExists(PaypalViewModel paypalViewModel)
        {
            var paypal = Mapper.Map<Paypal>(paypalViewModel);
            return TheUnitOfWork.Paypal.CheckPaypalExists(paypal);
        }
        #endregion

    }
}
