using DAL_EF;
using DAL_EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class PersonBLL
    {
        readonly PersonDAL personDAL = new PersonDAL();

        #region CREATE
        public void Insert(Person person)
        {
            personDAL.Insert(person);
        }

        public int InsertReturnId(Person person)
        {
            return personDAL.InsertReturnId(person);
        }
        #endregion

        #region RETRIEVE
        public List<Person> GetAll()
        {
            return personDAL.GetAll().ToList();
        }

        public Person GetById(int id)
        {
            return personDAL.GetById(id);
        }

        public List<Person> GetAllActive()
        {
            return personDAL.GetAllActive().ToList();
        }
        #endregion

        #region UPDATE
        public void Update(Person person)
        {
            personDAL.Update(person);
        }
        #endregion

        #region DELETE
        public void Delete(Person person)
        {
            personDAL.Delete(person);
        }

        public void DeletePermanently(Person person)
        {
            personDAL.DeletePermanently(person);
        }
        #endregion
    }
}
