using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_EF;
using DataAccessLayer;

namespace BusinessLogicLayer
{
    public class PersonBLL
    {
        PersonDAL personDAL = new PersonDAL();

        public List<Person> GetAll()
        {
            return personDAL.GetAll();
        }

        public Person GetById(Int32 id)
        {
            return personDAL.GetById(id);
        }

        public void Insert(Person person)
        {
            personDAL.Insert(person);
        }

        public Int32 InsertReturnId(Person person)
        {
            return personDAL.InsertReturnId(person);
        }

        public void Update(Person person)
        {
            personDAL.Update(person);
        }

        public void Delete(Person person)
        {
            person.IsActive = false;
            person.IsDeleted = true;
            personDAL.Update(person);

        }
        public void DeletePermanently(Person person)
        {
            personDAL.DeletePermanently(person);

        }

        public IEnumerable<Person> GetAllActive()
        {
            return personDAL.GetAll().Where(p => p.IsActive == true && p.IsDeleted == false);
        }

        public IEnumerable<Person> GetAllNotActive()
        {
            return personDAL.GetAll().Where(p => p.IsActive == false && p.IsDeleted == false);
        }

        public IEnumerable<Person> GetAllDeleted()
        {
            return personDAL.GetAll().Where(p => p.IsActive == false && p.IsDeleted == true);
        }

        public Person GetByIdNumber(string IdNumber)
        {
            return personDAL.GetAll().Where(p => p.IdNumber == IdNumber).SingleOrDefault();
        }
    }
}
