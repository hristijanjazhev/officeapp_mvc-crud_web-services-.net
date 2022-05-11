using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace DAL_EF.Models
{
    public class PersonDAL
    {
        readonly DMSEntities db = new DMSEntities();

        #region CREATE
        public void Insert(Person person)
        {
            db.People.Add(person);
            db.SaveChanges();
        }

        public int InsertReturnId(Person person)
        {
            int id = 0;
            db.People.Add(person);
            TransactionScope ts = new TransactionScope();

            try
            {
                if (db.SaveChanges() > 0)
                {
                    id = person.PersonId;
                    ts.Complete();
                }

            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message, ex.InnerException);
            }
            finally
            {
                if (ts != null)
                {
                    ((IDisposable)ts).Dispose();
                }
            }

            return id;
        }
        #endregion

        #region RETRIEVE
        public IQueryable<Person> GetAll()
        {
            return db.People;
        }

        public Person GetById(int id)
        {
            return db.People.Where(p => p.PersonId == id).SingleOrDefault();
        }

        public IQueryable<Person> GetAllActive()
        {
            return db.People.Where(p => p.IsActive == true && p.IsDeleted == false);
        }
        #endregion

        #region UPDATE

        public void Update(Person person)
        {
            db.Entry(person).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }
        #endregion

        #region DELETE
        public void Delete(Person person)
        {
            db.People.Remove(person);
        }

        public void DeletePermanently(Person person)
        {
            db.People.Remove(person);
            db.SaveChanges();
        }
        #endregion
    }
}
