using BL.Bases;
using DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BL.Repositories
{
    public class UserRepository : BaseRepository<ApplicationUserIDentity>
    {
        private DbContext EC_DbContext;

        public UserRepository(DbContext EC_DbContext) : base(EC_DbContext)
        {
            this.EC_DbContext = EC_DbContext;
        }
        #region CRUB

        public List<ApplicationUserIDentity> GetAllApplicationUserIDentity()
        {
            return GetAll().ToList();
        }

        public bool InsertApplicationUserIDentity(ApplicationUserIDentity ApplicationUserIDentity)
        {
            return Insert(ApplicationUserIDentity);
        }
        public void UpdateApplicationUserIDentity(ApplicationUserIDentity ApplicationUserIDentity)
        {
            Update(ApplicationUserIDentity);
        }
        public void DeleteApplicationUserIDentity(int id)
        {
            Delete(id);
        }

        public bool CheckApplicationUserIDentityExists(ApplicationUserIDentity ApplicationUserIDentity)
        {
            return GetAny(l => l.Id == ApplicationUserIDentity.Id);
        }
        public ApplicationUserIDentity GetApplicationUserIDentityById(string id)
        {
            return GetFirstOrDefault(l => l.Id == id);
        }
        public List<ApplicationUserIDentity> GetUserWhere(Expression<Func<ApplicationUserIDentity, bool>> filter = null, string includeProperties = "")
        {
            return GetWhere(filter, includeProperties).ToList();
        }
        #endregion
    }
}
