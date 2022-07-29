using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using BusinessLogicLayer;
using DAL_EF;

namespace API.Controllers
{
    public class PersonController : ApiController
    {
        private DMSEntities db = new DMSEntities();
        PersonBLL personBLL = new PersonBLL();
        // GET: api/Person
        #region GET
        [HttpGet]
       public IHttpActionResult GetAllPersons()
        {
            IEnumerable<Person> people = personBLL.GetAll();
            List<Models.PersonAddViewModel> personToReturn = new List<Models.PersonAddViewModel>();
            foreach(Person p in people)
            {
                Models.PersonAddViewModel personAddViewModel = new Models.PersonAddViewModel();
                personAddViewModel.PersonId = p.PersonId;
                personAddViewModel.PersonName = p.PersonName;
                personAddViewModel.PersonLastName = p.PersonLastName;
                personAddViewModel.IdNumber = p.IdNumber;
                personAddViewModel.MiddleName = p.MiddleName;
                personAddViewModel.Email = p.Email;
                personAddViewModel.PhoneNumber = p.PhoneNumber;
                personAddViewModel.AddressId = p.AddressId;
                personAddViewModel.IsActive = p.IsActive;
                personAddViewModel.IsDeleted = p.IsDeleted;
                personAddViewModel.Gender = p.Gender;
                personAddViewModel.EMBG = p.EMBG;
            }

            return Ok();
        }
        #endregion

        // GET: api/Person/5
        [ResponseType(typeof(Person))]
        public IHttpActionResult GetPerson(int id)
        {
            Person person = db.People.Find(id);
            if (person == null)
            {
                return NotFound();
            }

            return Ok(person);
        }

        // PUT: api/Person/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPerson(int id, Person person)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != person.PersonId)
            {
                return BadRequest();
            }

            db.Entry(person).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Person
        [ResponseType(typeof(Person))]
        public IHttpActionResult PostPerson(Person person)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.People.Add(person);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = person.PersonId }, person);
        }

        // DELETE: api/Person/5
        [ResponseType(typeof(Person))]
        public IHttpActionResult DeletePerson(int id)
        {
            Person person = db.People.Find(id);
            if (person == null)
            {
                return NotFound();
            }

            db.People.Remove(person);
            db.SaveChanges();

            return Ok(person);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PersonExists(int id)
        {
            return db.People.Count(e => e.PersonId == id) > 0;
        }
    }
}