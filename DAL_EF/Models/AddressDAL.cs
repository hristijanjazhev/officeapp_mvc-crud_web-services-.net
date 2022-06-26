using DAL_EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace DataAccessLayer
{
    public class AddressDAL
    {
        DMSEntities db = new DMSEntities();

        // CRUD 

        public List<Address> GetAll()
        {
            return db.Addresses.ToList();
        }

        public List<Address> GetActive()
        {
            return db.Addresses.Where(p => p.IsActive == true).ToList();
        }

        public Address GetById(int id)
        {
            return db.Addresses.Where(p => p.AddressId == id).SingleOrDefault();
        }

        public void Insert(Address address)
        {
            db.Addresses.Add(address);
            db.SaveChanges();
        }

        public void Delete(Address address)
        {
            db.Addresses.Remove(address);
        }

        public void DeletePermanently(Address address)
        {
            db.Addresses.Remove(address);
            db.SaveChanges();
        }

        public void Update(Address address)
        {
            db.Entry(address).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }

        public Int32 InsertReturnId(Address address)
        {
            int id = Int32.MinValue;
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
    }
}
