using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace DAL_EF.Models
{
    public class NoticeDAL
    {

        DMSEntities db = new DMSEntities();

        public List<Notice> GetAll()
        {
            return db.Notices.ToList();
        }

        public Notice GetById(int id)
        {
            return db.Notices.Where(p => p.NoticeId == id).SingleOrDefault();
        }

        public void Insert(Notice notice)
        {
            db.Notices.Add(notice);
            db.SaveChanges();
        }

        public void Update(Notice notice)
        {
            db.Entry(notice).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }

        public Int32 InsertReturnId(Notice notice)
        {
            int id = Int32.MinValue;
            db.Notices.Add(notice);
            TransactionScope ts = new TransactionScope();
            try
            {
                if (db.SaveChanges() > 0)
                {
                    id = notice.NoticeId;
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

        public void DeletePermanently(Notice notice)
        {
            db.Notices.Remove(notice);
            db.SaveChanges();
        }

    }
}
