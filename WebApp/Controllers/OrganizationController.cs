using BLL.Models;
using DAL_EF;
using DAL_EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Controllers
{
    public class OrganizationController : Controller
    {
        readonly DMSEntities db = new DMSEntities();
        readonly Organization org = new Organization();
        readonly OrganizationBLL organizationBLL = new OrganizationBLL();
        // GET: Organization
        //list
        #region ListOfOrganizations
        public ActionResult Index()
        {
            List<Organization> org = organizationBLL.GetAll().ToList();
            return View(org);
        }
        #endregion
        //CreateNew
        #region Create
        [HttpGet]
        public ActionResult Create()
        {
            return View(new Organization());
        }
        [HttpPost]
        public ActionResult Create(Organization org)
        {
            if (ModelState.IsValid)
            {
                db.Organizations.Add(org);
                db.SaveChanges();
                return RedirectToAction("Index", "Organization");
            }
            return View("Index");
        }
        #endregion
        //Edit
        #region Edit
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var organization = db.Organizations.FirstOrDefault(x => x.OrganizationId == id);
            return View(organization);
        }
        [HttpPost]
        public ActionResult Edit(Organization org)
        {

            db.Entry(org).State = System.Data.Entity.EntityState.Modified;
            organizationBLL.Update(org);
            db.SaveChanges();
            return View(org);

        }
        #endregion
        //Delete
        #region Delete
        public ActionResult Delete(int id)
        {
            if (ModelState.IsValid)
            {
                var org = db.Organizations.FirstOrDefault(x => x.OrganizationId == id);
                db.Organizations.Remove(org);
                db.SaveChanges();
                return RedirectToAction("Index", "Organization");
            }
            return View("Index");
        }
        #endregion
        //Details
        #region Details
        public ActionResult Details(int id)
        {
            var org = organizationBLL.GetById(id);
            return View(org);
        }
        #endregion
    }

}