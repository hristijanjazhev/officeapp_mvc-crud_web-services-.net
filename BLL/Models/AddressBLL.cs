using DAL_EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class AddressBLL
    {
        readonly AddressDAL addressDAL = new AddressDAL();

        #region CREATE
        public void Insert(Address address)
        {
            addressDAL.Insert(address);
        }

        public int InsertReturnId(Address address)
        {
            return addressDAL.InsertReturnId(address);
        }
        #endregion

        #region RETRIEVE
        public List<Address> GetAll()
        {
            return addressDAL.GetAll().ToList();
        }

        public Address GetById(int id)
        {
            return addressDAL.GetById(id);
        }

        public List<Address> GettAllActive()
        {
            return addressDAL.GetAllActive().ToList();
        }

        public List<Address> GellAllNotActive()
        {
            return addressDAL.GetAllNotActive().ToList();
        }

        public List<Address> GetAllDeleted()
        {
            return addressDAL.GetAllDeleted().ToList();
        }
        #endregion

        #region UPDATE
        public void Update(Address address)
        {
            addressDAL.Update(address);
        }
        #endregion

        #region DELETE
        public void Delete(Address address)
        {
            addressDAL.Delete(address);
        }

        public void DeletePermanently(Address address)
        {
            addressDAL.DeletePermanently(address);
        }
        #endregion
    }
}
