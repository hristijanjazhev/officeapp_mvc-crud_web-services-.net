using DAL_EF;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace WebApp.Controllers
{
    public class AddressController : Controller
    {
        readonly DMSEntities db = new DMSEntities();
        readonly AddressDAL addrDAL = new AddressDAL();
        //Create
        #region CreateNew
        [HttpGet]
        public ActionResult Create()
        {
            return View(new Address());
        }
        [HttpPost]
        public ActionResult Create(Address addr)
        {
            if (ModelState.IsValid)
            {
                db.Addresses.Add(addr);
                db.SaveChanges();
                TempData["SuccessMessage"] = "Address with id " + addr.AddressId + " was created successfully!";
                return RedirectToAction("Index", "Address");
            }
            else
            {
                return HttpNotFound();
            }
        }
        #endregion
        //Index
        #region List
        public ActionResult Index()
        {
            List<Address> alladr = addrDAL.GetAll().ToList();
            return View(alladr);
        }
        #endregion
        //Details
        #region Details
        public ActionResult Details(int id)
        {
            Address addr = addrDAL.GetById(id);
            return View(addr);
        }
        #endregion
        //Edit
        #region Edit
        //get
        public ActionResult Edit(int id)
        {
            //var addr = db.Addresses.Single(x => x.AddressId == id);
            var addr = db.Addresses.FirstOrDefault(x => x.AddressId == id);
            return View(addr);
        }
        //set
        [HttpPost]
        public ActionResult Edit(Address addr)
        {
            db.Entry(addr).State = System.Data.Entity.EntityState.Modified;
            addrDAL.Update(addr);
            db.SaveChanges();
            TempData["SuccessMessage"] = "Address with id " + addr.AddressId + " was updated successfully!";
            return View(addr);
        }
        //[HttpPost]
        //public ActionResult Edit(Address addr)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Addresses.Add(addr);
        //        db.SaveChanges();
        //        return RedirectToAction("Index","Address");
        //    }
        //    return View("Index");
        //}
        #endregion
        //Delete
        #region Delete
        public ActionResult Delete(int id)
        {
            if (ModelState.IsValid)
            {
                var addr = db.Addresses.FirstOrDefault(x => x.AddressId == id);
                db.Addresses.Remove(addr);
                db.SaveChanges();
                TempData["SuccessMessage"] = "Address with id " + addr.AddressId + " was deleted successfully!";
                return RedirectToAction("Index", "Address");
            }
            return View("Index");
        }
        #endregion
        public ActionResult Welcome()
        {
            return Content("<center><h1>Welcome!</h1></center><hr>");
        }
    }
}