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
using DataAccessLayer;

namespace API.Controllers
{
    public class PersonController : ApiController
    {
        private DMSEntities db = new DMSEntities();
        PersonBLL personBLL = new PersonBLL();
        PersonDAL personDAL = new PersonDAL();
        int personId;


        // GET: api/Person
        #region GET
        [HttpGet]
        public IHttpActionResult GetAllPersons()
        {
            IEnumerable<Person> people = personBLL.GetAll();
            List<Models.PersonAddViewModel> personToReturn = new List<Models.PersonAddViewModel>();
            foreach (Person p in people)
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
                personToReturn.Add(personAddViewModel);

            }

            return Ok(personToReturn);
        }
        #endregion



        // GET: api/Person/5
        #region GET{id}
        [HttpGet]
        public IHttpActionResult GetPersonById(int id)
        {
            var persons = personDAL.GetById(id);
            return Ok();
        }
        #endregion



        // PUT: api/Person/5
        #region PUT
        [HttpGet]
        public IHttpActionResult UpdatePersons(int id)
        {
            var persons = personBLL.GetById(id);
            return Ok(persons);
        }
        [HttpPut]
        public IHttpActionResult UpdatePerson(int id, Models.PersonAddViewModel personAdd)
        {
            Person newPersonToAdd = new Person();
            newPersonToAdd.PersonId = personAdd.PersonId;
            newPersonToAdd.PersonName = personAdd.PersonName;
            newPersonToAdd.PersonLastName = personAdd.PersonLastName;
            newPersonToAdd.IdNumber = personAdd.IdNumber;
            newPersonToAdd.MiddleName = personAdd.MiddleName;
            newPersonToAdd.Email = personAdd.Email;
            newPersonToAdd.PhoneNumber = personAdd.PhoneNumber;
            newPersonToAdd.AddressId = personAdd.AddressId;
            newPersonToAdd.IsActive = personAdd.IsActive;
            newPersonToAdd.IsDeleted = personAdd.IsDeleted;
            newPersonToAdd.Gender = personAdd.Gender;
            newPersonToAdd.EMBG = personAdd.EMBG;

            personBLL.Update(newPersonToAdd);
            return Ok(newPersonToAdd);

        }
        #endregion



        // POST: api/Person
        #region POST
        [HttpPost]
        [ResponseType(typeof(Person))]
        public IHttpActionResult PostPerson(Models.PersonAddViewModel personAddViewModel)
        {
            Person newPersonToAdd = new Person();
            newPersonToAdd.PersonId = personAddViewModel.PersonId;
            newPersonToAdd.PersonName = personAddViewModel.PersonName;
            newPersonToAdd.PersonLastName = personAddViewModel.PersonLastName;
            newPersonToAdd.IdNumber = personAddViewModel.IdNumber;
            newPersonToAdd.MiddleName = personAddViewModel.MiddleName;
            newPersonToAdd.Email = personAddViewModel.Email;
            newPersonToAdd.PhoneNumber = personAddViewModel.PhoneNumber;
            newPersonToAdd.AddressId = personAddViewModel.AddressId;
            newPersonToAdd.IsActive = personAddViewModel.IsActive;
            newPersonToAdd.IsDeleted = personAddViewModel.IsDeleted;
            newPersonToAdd.Gender = personAddViewModel.Gender;
            newPersonToAdd.EMBG = personAddViewModel.EMBG;

            var personId = personBLL.InsertReturnId(newPersonToAdd);

            if (!ModelState.IsValid)
            {
                return NotFound();
            }

            return Ok(personId);

        }
        #endregion


        // DELETE: api/Person/5
        #region DELETE
        [HttpDelete]
        public IHttpActionResult DeletePerson(int id)
        {
            Person person = personDAL.GetById(id);
            personDAL.DeletePermanently(person);

            return Ok();
        }
        #endregion
    }
}