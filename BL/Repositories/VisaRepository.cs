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
    public class VisaRepository : BaseRepository<Visa>
    {
        private DbContext EC_DbContext;

        public VisaRepository(DbContext EC_DbContext) : base(EC_DbContext)
        {
            this.EC_DbContext = EC_DbContext;
        }
        #region CRUB

        public List<Visa> GetAllVisa()
        {
            return GetAll().ToList();
        }

        public bool InsertVisa(Visa visa)
        {
            return Insert(visa);
        }
        public void UpdateVisa(Visa visa)
        {
            Update(visa);
        }
        public void DeleteVisa(int id)
        {
            Delete(id);
        }

        public bool CheckVisaExists(Visa visa)
        {
            return GetAny(l => l.Id == visa.Id);
        }
        public Visa GetVisaById(int id)
        {
            return GetFirstOrDefault(l => l.Id == id);
        }
        #endregion
    }
}
