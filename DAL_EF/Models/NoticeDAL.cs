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
        readonly DMSEntities db = new DMSEntities();

        #region CREATE
        public void Insert(Notice notice)
        {
            db.Notices.Add(notice);
        }

        public int InsertReturnId(Notice notice)
        {
            int id = 0;
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
            catch (Exception e)
            {
                throw new ArgumentException(e.Message, e.InnerException);
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
        public IQueryable<Notice> GetAll()
        {
            return db.Notices;
        }

        public Notice GetById(int id)
        {
            return db.Notices.Where(a => a.NoticeId == id).SingleOrDefault();
        }
        public IQueryable<Notice> GetAllActive()
        {
            return db.Notices.Where(a => a.IsActive == true);
        }

        public IQueryable<Notice> GetAllNotActive()
        {
            return db.Notices.Where(a => a.IsActive == false);
        }

        public IQueryable<Notice> GetAllDeleted()
        {
            return db.Notices.Where(a => a.IsDeleted == true);
        }
        #endregion

        #region UPDATE
        public void Update(Notice notice)
        {
            db.Entry(notice).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }
        #endregion

        #region DELETE
        public void Delete(Notice notice)
        {
            db.Notices.Remove(notice);
        }

        public void DeletePermanently(Notice notice)
        {
            db.Notices.Remove(notice);
            db.SaveChanges();
        }
        #endregion
    }
}
