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
    public class PersonController : Controller
    {
        readonly PersonBLL personBLL = new PersonBLL();
        readonly Person person = new Person();
        readonly DMSEntities db = new DMSEntities();
        //CreateNew
        #region CreateNew
        [HttpGet]
        public ActionResult Create()
        {
            return View(new Person());
        }
        [HttpPost]
        public ActionResult Create(Person person)
        {
            if (ModelState.IsValid)
            {
                db.People.Add(person);
                db.SaveChanges();
                return RedirectToAction("Index", "Person");
            }
            return View("Index");
        }







        #endregion
        // GET: Persons
        #region ListOfPersons
        public ActionResult Index()
        {
            List<Person> people = personBLL.GetAll().ToList();
            return View(people);
        }
        #endregion
        //Details
        #region Details
        public ActionResult Details(int id)
        {
            Person person = personBLL.GetById(id);
            return View(person);
        }
        #endregion
        //Edit
        #region Edit
        public ActionResult Edit(int id)
        {
            var person = db.People.FirstOrDefault(x => x.PersonId == id);
            return View(person);
        }
        [HttpPost]
        public ActionResult Edit(Person person)
        {
            db.Entry(person).State = System.Data.Entity.EntityState.Modified;
            personBLL.Update(person);
            db.SaveChanges();
            return View(person);
        }
        #endregion
        //Delete
        #region Delete
        public ActionResult Delete(int id)
        {
            if (ModelState.IsValid)
            {
                var person = db.People.FirstOrDefault(x => x.PersonId == id);
                db.People.Remove(person);
                db.SaveChanges();
                return RedirectToAction("Index", "Person");
            }
            return View("Index");
        }
        #endregion

    }
}