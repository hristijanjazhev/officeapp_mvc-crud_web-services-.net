using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL_EF;
using DataAccessLayer;

namespace DMS.Controllers
{
    public class AddressController : Controller
    {
        DataAccessLayer.AddressDAL addressDAL = new AddressDAL();
        DMSEntities db = new DMSEntities();

        // GET: Address
        #region ListOfAddress
        public ActionResult Index()
        {
            Address address = new Address();
            List<Address> listOfAddresses = addressDAL.GetActive();
            return View(listOfAddresses);
        }
        #endregion

        //Create
        #region Create
        public ActionResult Create()
        {
            return View(new Address());
        }

        [HttpPost, ActionName("Create")]

        public ActionResult Create(Address addressFromView)
        {
            Address address = new Address();

            address.City = addressFromView.City;
            address.Country = addressFromView.Country;
            address.PostCode = addressFromView.PostCode;
            address.Street = addressFromView.Street;
            address.Province = addressFromView.Province;
            address.State = addressFromView.State;
            address.Number = addressFromView.Number;
            address.IsActive = addressFromView.IsActive;
            address.IsDeleted = addressFromView.IsDeleted;

            addressDAL.Insert(address);

            return RedirectToAction("Index");
        }
        #endregion

        //Edit
        #region Edit
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var address = db.Addresses.FirstOrDefault(x => x.AddressId == id);
            return View(address);
        }
        [HttpPost]
        public ActionResult Edit(Address address)
        {
            if (ModelState.IsValid)
            {
                db.Entry(address).State = System.Data.Entity.EntityState.Modified;
                addressDAL.Update(address);
                db.SaveChanges();
                return RedirectToAction("Index", "Address");
            }
            else
            {
                return View();
            }
        }
        #endregion

        //Delete
        #region Delete
        public ActionResult Delete(int id)
        {
            Address address = addressDAL.GetById(id);
            addressDAL.DeletePermanently(address);
            return RedirectToAction("Index");
        }
        #endregion

        //Details
        #region Details
        public ActionResult Details(int id)
        {
            Address address = addressDAL.GetById(id);

            if (address == null)
            {
                //return RedirectToAction("Error");
                return RedirectToAction("Error", "Address", new { errorMessage = "Zapis so toa ID ne postoi..!" });
            }

            return View(address);
        }
        #endregion

        //ErrorMessage
        #region ErrorMessage
        public ActionResult Error(string errorMessage = "Contact your administrator")
        {
            TempData["Error Message"] = errorMessage;
            TempData.Keep();
            return View();
        }
        #endregion
    }
}