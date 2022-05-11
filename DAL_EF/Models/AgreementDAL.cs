using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace DAL_EF.Models
{
    public class AgreementDAL
    {
        readonly DMSEntities db = new DMSEntities();

        #region CREATE
        public void Insert(Agreement agreement)
        {
            db.Agreements.Add(agreement);
        }

        public int InsertReturnId(Agreement agreement)
        {
            int id = 0;
            db.Agreements.Add(agreement);
            TransactionScope ts = new TransactionScope();

            try
            {
                if (db.SaveChanges() > 0)
                {
                    id = agreement.AgreementId;
                    ts.Complete();
                }
            }
            catch (Exception e)
            {
                throw new ArgumentException(e.Message, e.InnerException);
            }
            finally
            {
                if (ts != null)
                {
                    ((IDisposable)ts).Dispose();
                }
            }

            return id;
        }
        #endregion

        #region RETRIEVE
        public IQueryable<Agreement> GetAll()
        {
            return db.Agreements;
        }

        public Agreement GetById(int id)
        {
            return db.Agreements.Where(a => a.AgreementId == id).SingleOrDefault();
        }
        public IQueryable<Agreement> GetAllActive()
        {
            return db.Agreements.Where(a => a.IsActive == true);
        }

        public IQueryable<Agreement> GetAllNotActive()
        {
            return db.Agreements.Where(a => a.IsActive == false);
        }

        public IQueryable<Agreement> GetAllDeleted()
        {
            return db.Agreements.Where(a => a.IsDeleted == true);
        }
        #endregion

        #region UPDATE
        public void Update(Agreement agreement)
        {
            db.Entry(agreement).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }
        #endregion

        #region DELETE
        public void Delete(Agreement agreement)
        {
            db.Agreements.Remove(agreement);
        }

        public void DeletePermanently(Agreement agreement)
        {
            db.Agreements.Remove(agreement);
            db.SaveChanges();
        }
        #endregion
    }
}
