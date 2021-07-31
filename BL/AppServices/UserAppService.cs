using BL.Bases;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace BL.AppServices
{
    public class UserAppService : AppServiceBase
    {
        #region CURD

        public List<ApplicationUserIDentity> GetAllApplicationUserIDentity()
        {
            return TheUnitOfWork.ApplicationUserIDentity.GetAllApplicationUserIDentity();
        }
        public ApplicationUserIDentity GetApplicationUserIDentity(string id)
        {
            return TheUnitOfWork.ApplicationUserIDentity.GetApplicationUserIDentityById(id);
        }



        public bool SaveNewApplicationUserIDentity(ApplicationUserIDentity ApplicationUserIDentity)
        {
            bool result = false;
            if (TheUnitOfWork.ApplicationUserIDentity.Insert(ApplicationUserIDentity))
            {
                result = TheUnitOfWork.Commit() > new int();
            }
            return result;
        }


        public bool UpdateApplicationUserIDentity(ApplicationUserIDentity ApplicationUserIDentity)
        {
            TheUnitOfWork.ApplicationUserIDentity.Update(ApplicationUserIDentity);
            TheUnitOfWork.Commit();

            return true;
        }


        public bool DeleteApplicationUserIDentity(int id)
        {
            bool result = false;

            TheUnitOfWork.ApplicationUserIDentity.Delete(id);
            result = TheUnitOfWork.Commit() > new int();

            return result;
        }

        public bool CheckApplicationUserIDentityExists(ApplicationUserIDentity ApplicationUserIDentity)
        {
            return TheUnitOfWork.ApplicationUserIDentity.CheckApplicationUserIDentityExists(ApplicationUserIDentity);
        }
        public List<ApplicationUserIDentity> GetUserWhere(Expression<Func<ApplicationUserIDentity, bool>> filter = null, string includeProperties = "")
        {
            return TheUnitOfWork.ApplicationUserIDentity.GetUserWhere(filter, includeProperties);
        }
        #endregion

    }
}
