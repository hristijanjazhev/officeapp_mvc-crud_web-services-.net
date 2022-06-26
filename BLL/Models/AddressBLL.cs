using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_EF;
using DataAccessLayer;

namespace BusinessLogicLayer
{
    public class AddressBLL
    {
        AddressDAL addressDAL = new AddressDAL();

        public IEnumerable<Address> GetAll()
        {
            return addressDAL.GetAll();
        }

        public IEnumerable<Address> GetAllActive()
        {
            return addressDAL.GetAll().Where(p => p.IsActive == true && p.IsDeleted == false);
        }

        public IEnumerable<Address> GetAllNotActive()
        {
            return addressDAL.GetAll().Where(p => p.IsActive == false && p.IsDeleted == false);
        }

        public IEnumerable<Address> GetAllDeleted()
        {
            return addressDAL.GetAll().Where(p => p.IsActive == false && p.IsDeleted == true);
        }

        public Address GetById(Int32 id)
        {
            return addressDAL.GetById(id);
        }


        public void Insert(Address address)
        {
            addressDAL.Insert(address);
        }

        public Int32 InsertReturnId(Address address)
        {
            return addressDAL.InsertReturnId(address);
        }

        public void Update(Address address)
        {
            addressDAL.Update(address);
        }

        public void Delete(Address address)
        {
            address.IsActive = false;
            address.IsDeleted = true;
            addressDAL.Update(address);

        }

        public void DeletePermanently(Address address)
        {
            addressDAL.DeletePermanently(address);

        }
    }

}
