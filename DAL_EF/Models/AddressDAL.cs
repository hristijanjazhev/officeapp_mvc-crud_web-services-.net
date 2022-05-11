using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace DAL_EF
{
    public class AddressDAL
    {
        readonly DMSEntities db = new DMSEntities();

        #region CREATE
        public void Insert(Address address)
        {
            db.Addresses.Add(address);
            db.SaveChanges();
        }

        public int InsertReturnId(Address address)
        {
            int id = 0;
            db.Addresses.Add(address);
            TransactionScope ts = new TransactionScope();

            try
            {
                if (db.SaveChanges() > 0)
                {
                    id = address.AddressId;
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
        public IQueryable<Address> GetAll()
        {
            return db.Addresses;
        }

        public Address GetById(int id)
        {
            return db.Addresses.Where(a => a.AddressId == id).SingleOrDefault();
        }
        public IQueryable<Address> GetAllActive()
        {
            return db.Addresses.Where(a => a.IsActive == true);
        }

        public IQueryable<Address> GetAllNotActive()
        {
            return db.Addresses.Where(a => a.IsActive == false);
        }

        public IQueryable<Address> GetAllDeleted()
        {
            return db.Addresses.Where(a => a.IsDeleted == true);
        }
        #endregion

        #region UPDATE
        public void Update(Address address)
        {
            db.Entry(address).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }
        #endregion

        #region DELETE
        public void Delete(Address address)
        {
            db.Addresses.Remove(address);
        }

        public void DeletePermanently(Address address)
        {
            db.Addresses.Remove(address);
            db.SaveChanges();
        }
        #endregion

    }
}
