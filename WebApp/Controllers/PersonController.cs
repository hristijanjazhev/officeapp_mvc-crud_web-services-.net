using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccessLayer;
using BusinessLogicLayer;
using DAL_EF;
using DMS.Models;

namespace DMS.Controllers
{
    public class PersonController : Controller
    {

        PersonBLL personBLL = new PersonBLL();
        AddressBLL addressBLL = new AddressBLL();


        // GET: Person
        #region ListOfPersons
        public ActionResult Index()
        {
            List<Person> listOfPerson = personBLL.GetAll();
            return View(listOfPerson);
        }
        #endregion

        //Create
        #region Create 
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost, ActionName("Create")]
        public ActionResult Create(Models.PersonAddEditModel personAddEditModel)
        {

            Person personToCheck = personBLL.GetByIdNumber(personAddEditModel.IdNumber);
            if (ModelState.IsValid)
            {

                if (personToCheck != null)
                {
                    TempData["Message"] = "Лицето веќе постои";
                    TempData.Keep();
                }
                else
                {
                    Address address = new Address();
                    Int32 addressIdFromDatabase = 0;

                    address.City = personAddEditModel.City;
                    address.Country = personAddEditModel.Country;
                    address.PostCode = personAddEditModel.PostCode;
                    address.Street = personAddEditModel.Street;
                    address.Province = personAddEditModel.Province;
                    address.State = personAddEditModel.State;
                    address.Number = personAddEditModel.Number;
                    address.IsActive = personAddEditModel.IsActive;
                    address.IsDeleted = personAddEditModel.IsDeleted;

                    addressIdFromDatabase = addressBLL.InsertReturnId(address);

                    Person person = new Person();

                    person.PersonName = personAddEditModel.PersonName;
                    person.PersonLastName = personAddEditModel.PersonLastName;
                    person.IdNumber = personAddEditModel.IdNumber;
                    person.MiddleName = personAddEditModel.MiddleName;
                    person.Email = personAddEditModel.Email;
                    person.PhoneNumber = personAddEditModel.PhoneNumber;
                    person.AddressId = addressIdFromDatabase;
                    person.IsActive = personAddEditModel.IsActive;
                    person.IsDeleted = personAddEditModel.IsDeleted;
                    person.Gender = personAddEditModel.Gender;

                    personBLL.Insert(person);

                    //TempData["Message"] = "Успешно креиран запис " + person.PersonName;

                    //return RedirectToAction("Details", new { id = person.PersonId});
                    return RedirectToAction("Index");
                }


            }
            return View();
        }

        #endregion

        //GET Edit
        #region Edit
        public ActionResult Edit(int id)
        {
            Person person = personBLL.GetById(id);
            Address address = addressBLL.GetById(person.AddressId);

            Models.PersonAddEditModel personAddEditModel = new Models.PersonAddEditModel();

            personAddEditModel.PersonId = person.PersonId;
            personAddEditModel.PersonName = person.PersonName;
            personAddEditModel.PersonLastName = person.PersonLastName;
            personAddEditModel.IdNumber = person.IdNumber;
            personAddEditModel.MiddleName = person.MiddleName;
            personAddEditModel.Email = person.Email;
            personAddEditModel.PhoneNumber = person.PhoneNumber;
            personAddEditModel.IsActive = person.IsActive;
            personAddEditModel.IsDeleted = person.IsDeleted;
            personAddEditModel.Gender = person.Gender;
            //todo
            //personAddEditModel.AddressId = address.AddressId;
            //personAddEditModel.Street = address.Street;
            //personAddEditModel.Number = address.Number;
            //personAddEditModel.PostCode = address.PostCode;
            //personAddEditModel.City = address.City;
            //personAddEditModel.State = address.State;
            //personAddEditModel.Province = address.Province;
            //personAddEditModel.Country = address.Country;

            return View(personAddEditModel);
        }
        //POST Edit
        [HttpPost, ActionName("Edit")]
        public ActionResult Edit(Models.PersonAddEditModel personAddEditModel)
        {
            Person personForUpdate = new Person();

            if (ModelState.IsValid)
            {
                personForUpdate.PersonId = personAddEditModel.PersonId;
                personForUpdate.PersonName = personAddEditModel.PersonName;
                personForUpdate.PersonLastName = personAddEditModel.PersonLastName;
                personForUpdate.IdNumber = personAddEditModel.IdNumber;
                personForUpdate.MiddleName = personAddEditModel.MiddleName;
                personForUpdate.Email = personAddEditModel.Email;
                personForUpdate.PhoneNumber = personAddEditModel.PhoneNumber;
                personForUpdate.AddressId = personAddEditModel.AddressId;
                personForUpdate.IsActive = personAddEditModel.IsActive;
                personForUpdate.IsDeleted = personAddEditModel.IsDeleted;
                personForUpdate.Gender = personAddEditModel.Gender;
                //todo
                //Address addressForUpdate = addressBLL.GetById(personAddEditModel.AddressId);

                //addressForUpdate.Street = personAddEditModel.Street;
                //addressForUpdate.Number = personAddEditModel.Number;
                //addressForUpdate.PostCode = personAddEditModel.PostCode;
                //addressForUpdate.City = personAddEditModel.City;
                //addressForUpdate.State = personAddEditModel.State;
                //addressForUpdate.Province = personAddEditModel.Province;
                //addressForUpdate.Country = personAddEditModel.Country;

                personBLL.Update(personForUpdate);
                //addressBLL.Update(addressForUpdate);

                return RedirectToAction("Index");
            }

            {
                return View(personForUpdate);
            }

        }
        #endregion

        //Details
        #region Details
        public ActionResult Details(int id)
        {
            Person person = personBLL.GetById(id);
            Models.PersonAddEditModel personDetailsViewModel = GetAllElementsFromCustomModel(person);
            return View(person);
        }

        [NonAction]
        public virtual Models.PersonAddEditModel GetAllElementsFromCustomModel(Person personAddEditModel)
        {
            Models.PersonAddEditModel personViewModel = new Models.PersonAddEditModel();

            personViewModel.PersonId = personAddEditModel.PersonId;
            personViewModel.PersonName = personAddEditModel.PersonName;
            personViewModel.PersonLastName = personAddEditModel.PersonLastName;
            personViewModel.IdNumber = personAddEditModel.IdNumber;
            personViewModel.MiddleName = personAddEditModel.MiddleName;
            personViewModel.Email = personAddEditModel.Email;
            personViewModel.PhoneNumber = personAddEditModel.PhoneNumber;
            personViewModel.IsActive = personAddEditModel.IsActive;
            personViewModel.IsDeleted = personAddEditModel.IsDeleted;
            personViewModel.Gender = personAddEditModel.Gender;

            personViewModel.AddressId = personAddEditModel.AddressId;
            //personViewModel.Street = personAddEditModel.;
            //personViewModel.Number = personAddEditModel.Address.Number;
            //personViewModel.PostCode = personAddEditModel.Address.PostCode;
            //personViewModel.City = personAddEditModel.Address.City;
            //personViewModel.State = personAddEditModel.Address.State;
            //personViewModel.Province = personAddEditModel.Address.Province;
            //personViewModel.Country = personAddEditModel.Address.Country;

            return personViewModel;
        }
        #endregion

        //Delete
        #region Delete
        public ActionResult Delete(int id)
        {
            Person person = personBLL.GetById(id);
            Address addressForDelete = addressBLL.GetById(person.AddressId);
            personBLL.DeletePermanently(person);
            addressBLL.DeletePermanently(addressForDelete);
            return RedirectToAction("Index");
        }
        #endregion
    }
}