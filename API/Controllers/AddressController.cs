using DAL_EF;
using DataAccessLayer;
using BusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
    public class AddressController : ApiController
    {
        int addresIdFromDb;
        AddressBLL addressBLL = new AddressBLL();
        AddressDAL addressDAL = new AddressDAL();

        //GET Method
        #region GET 
        [HttpGet]
        public IHttpActionResult GetAllAddresses()
        {
            IEnumerable<Address> addresses = addressBLL.GetAll();
            List<Models.AddressViewModel> addressToReturn = new List<Models.AddressViewModel>();

            foreach (Address a in addresses)
            {
                Models.AddressViewModel tempAddress = new Models.AddressViewModel();
                tempAddress.AddressId = a.AddressId;
                tempAddress.Street = a.Street;
                tempAddress.Number = a.Number;
                tempAddress.PostCode = a.PostCode;
                tempAddress.City = a.City;
                tempAddress.State = a.State;
                tempAddress.Province = a.Province;
                tempAddress.Country = a.Country;
                tempAddress.IsActive = a.IsActive;
                //tempAddress.IsDeleted = a.IsDeleted;
                addressToReturn.Add(tempAddress);
            }
            if (addressToReturn.Count == 0)
            {
                return NotFound();
            }
            else
            {
                return Ok(addressToReturn);
            }
        }
        #endregion

        //POST Method
        #region POST
        [HttpPost]
        public IHttpActionResult Create(Models.AddressViewModel newAddress)
        {
            Address newAddressToInsert = new Address();

            newAddressToInsert.Street = newAddress.Street;
            newAddressToInsert.Number = newAddress.Number;
            newAddressToInsert.PostCode = newAddress.PostCode;
            newAddressToInsert.City = newAddress.City;
            newAddressToInsert.State = newAddress.State;
            newAddressToInsert.Province = newAddress.Province;
            newAddressToInsert.Country = newAddress.Country;
            newAddressToInsert.IsActive = newAddress.IsActive;
            newAddressToInsert.IsDeleted = newAddress.IsDeleted;

            var addressIdFromDb = addressBLL.InsertReturnId(newAddressToInsert);

            return Ok();
        }
        #endregion

        //PUT Method
        #region PUT
        [HttpGet]
        
        public IHttpActionResult Edit(int id)
        {
            var address = addressDAL.GetById(id);
            return Ok();
        }

        [HttpPut]
        public IHttpActionResult Edit(int id, Models.AddressViewModel address)
        {
            Address newAddressToInsert = new Address();

            newAddressToInsert.AddressId = id;
            newAddressToInsert.Street = address.Street;
            newAddressToInsert.Number = address.Number;
            newAddressToInsert.PostCode = address.PostCode;
            newAddressToInsert.City = address.City;
            newAddressToInsert.State = address.State;
            newAddressToInsert.Province = address.Province;
            newAddressToInsert.Country = address.Country;
            newAddressToInsert.IsActive = address.IsActive;
            newAddressToInsert.IsDeleted = address.IsDeleted;


            addressBLL.Update(newAddressToInsert);

            return Ok();
        }
        #endregion

        //DELETE Method
        #region DELETE
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            Address address = addressDAL.GetById(id);
            addressDAL.DeletePermanently(address);

            return Ok();
        }
        #endregion
    }
}
