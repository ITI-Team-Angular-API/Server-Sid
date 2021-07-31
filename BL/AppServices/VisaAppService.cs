using BL.Bases;
using BL.ViewModel;
using DAL;
using System.Collections.Generic;

namespace BL.AppServices
{
    public class VisaAppService : AppServiceBase
    {
        #region CURD

        public List<VisaViewModel> GetAllVisas()
        {

            return Mapper.Map<List<VisaViewModel>>(TheUnitOfWork.Visa.GetAllVisa());
        }
        public VisaViewModel GetVisa(int id)
        {
            return Mapper.Map<VisaViewModel>(TheUnitOfWork.Visa.GetVisaById(id));
        }



        public bool SaveNewVisa(VisaViewModel VisaViewModel)
        {
            bool result = false;
            var Visa = Mapper.Map<Visa>(VisaViewModel);
            if (TheUnitOfWork.Visa.Insert(Visa))
            {
                result = TheUnitOfWork.Commit() > new int();
            }
            return result;
        }


        public bool UpdateVisa(VisaViewModel VisaViewModel)
        {
            var Visa = Mapper.Map<Visa>(VisaViewModel);
            TheUnitOfWork.Visa.Update(Visa);
            TheUnitOfWork.Commit();

            return true;
        }


        public bool DeleteVisa(int id)
        {
            bool result = false;

            TheUnitOfWork.Visa.Delete(id);
            result = TheUnitOfWork.Commit() > new int();

            return result;
        }

        public bool CheckOrderExists(VisaViewModel VisaViewModel)
        {
            Visa Visa = Mapper.Map<Visa>(VisaViewModel);
            return TheUnitOfWork.Visa.CheckVisaExists(Visa);
        }
        #endregion

    }
}
