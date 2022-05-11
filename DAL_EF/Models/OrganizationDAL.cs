using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace DAL_EF.Models
{
    public class OrganizationDAL
    {
        readonly DMSEntities db = new DMSEntities();

        #region CREATE
        public void Insert(Organization organization)
        {
            db.Organizations.Add(organization);
        }

        public int InsertReturnId(Organization organization)
        {
            int id = 0;
            db.Organizations.Add(organization);
            TransactionScope ts = new TransactionScope();

            try
            {
                if (db.SaveChanges() > 0)
                {
                    id = organization.OrganizationId;
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
        public IQueryable<Organization> GetAll()
        {
            return db.Organizations;
        }

        public Organization GetById(int id)
        {
            return db.Organizations.Where(a => a.OrganizationId == id).SingleOrDefault();
        }
        public IQueryable<Organization> GetAllActive()
        {
            return db.Organizations.Where(a => a.IsActive == true);
        }

        public IQueryable<Organization> GetAllNotActive()
        {
            return db.Organizations.Where(a => a.IsActive == false);
        }

        public IQueryable<Organization> GetAllDeleted()
        {
            return db.Organizations.Where(a => a.IsDeleted == true);
        }
        #endregion

        #region UPDATE
        public void Update(Organization organization)
        {
            db.Entry(organization).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }
        #endregion

        #region DELETE
        public void Delete(Organization organization)
        {
            db.Organizations.Remove(organization);
        }

        public void DeletePermanently(Organization organization)
        {
            db.Organizations.Remove(organization);
            db.SaveChanges();
        }
        #endregion
    }
}
