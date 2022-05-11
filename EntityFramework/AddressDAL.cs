using EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF
{
    public class AddressDAL
    {
        readonly DMSEntities db = new DMSEntities();

        #region RETRIEVE
        public Address GetById(int id)
        {
            return db.Addresses.Where(a => a.AddressId == id).SingleOrDefault();
        }

        public List<Address> GetAll()
        {
            return db.Addresses.ToList();
        }

        public List<Address> GetAllUnDeleted()
        {
            return db.Addresses.Where(a => a.IsDeleted == 1).ToList();
        }

        public List<Address> GetAllActive()
        {
            return db.Addresses.Where(a => a.IsActive == 1).ToList();
        }
        #endregion  

        public void Insert(Address adr)
        {
            db.Addresses.Add(adr);
            db.SaveChanges();
        }

        public void Update(Address adr)
        {
            db.Addresses.Attach(adr);
            db.SaveChanges();
        }
    }
}
