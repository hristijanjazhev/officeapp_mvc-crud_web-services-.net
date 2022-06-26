using DAL_EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace DataAccessLayer
{
    public class PersonDAL
    {
        DMSEntities db = new DMSEntities();

        public List<Person> GetAll()
        {
            return db.People.ToList();
        }

        public Person GetById(int id)
        {
            return db.People.Where(p => p.PersonId == id).SingleOrDefault();
        }

        public void Insert(Person person)
        {
            db.People.Add(person);
            db.SaveChanges();
        }
        public void Update(Person person)
        {
            db.Entry(person).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }

        public Int32 InsertReturnId(Person person)
        {
            int id = Int32.MinValue;
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

        public void DeletePermanently(Person person)
        {
            db.People.Remove(person);
            db.SaveChanges();
        }
    }
}
