using DAL_EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace DataAccessLayer
{
    public class OrganizationDAL
    {
        DMSEntities db = new DMSEntities();

        public List<Organization> GetAll()
        {
            return db.Organizations.ToList();
        }

        public Organization GetById(int id)
        {
            return db.Organizations.Where(p => p.OrganizationId == id).SingleOrDefault();
        }

        public void Insert(Organization organization)
        {
            db.Organizations.Add(organization);
            db.SaveChanges();
        }

        public void Update(Organization organization)
        {
            db.Entry(organization).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }

        public Int32 InsertReturnId(Organization organization)
        {
            int id = Int32.MinValue;
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
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message, ex.InnerException);
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

        public void DeletePermanently(Organization organization)
        {
            db.Organizations.Remove(organization);
            db.SaveChanges();
        }
    }
}
