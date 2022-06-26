using DAL_EF;
using DAL_EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class NoticeBLL
    {
        readonly NoticeDAL noticeDAL = new NoticeDAL();

        public List<Notice> GetAll()
        {
            return noticeDAL.GetAll();
        }

        public Notice GetById(Int32 id)
        {
            return noticeDAL.GetById(id);
        }

        public void Insert(Notice notice)
        {
            noticeDAL.Insert(notice);
        }

        public Int32 InsertReturnId(Notice notice)
        {
            return noticeDAL.InsertReturnId(notice);
        }

        public void Update(Notice notice)
        {
            noticeDAL.Update(notice);
        }

        public void Delete(Notice notice)
        {
            notice.IsActive = false;
            notice.IsDeleted = true;
            noticeDAL.Update(notice);
        }

        public void DeletePermanently(Notice notice)
        {
            noticeDAL.DeletePermanently(notice);

        }

        public IEnumerable<Notice> GetAllActive()
        {
            return noticeDAL.GetAll().Where(p => p.IsActive == true && p.IsDeleted == false);
        }

        public IEnumerable<Notice> GetAllNotActive()
        {
            return noticeDAL.GetAll().Where(p => p.IsActive == false && p.IsDeleted == false);
        }

        public IEnumerable<Notice> GetAllDeleted()
        {
            return noticeDAL.GetAll().Where(p => p.IsActive == false && p.IsDeleted == true);
        }

        public Notice GetByInvoiceNumber(Int32 NoticeNumber)
        {
            return noticeDAL.GetAll().Where(p => p.NoticeNumber == NoticeNumber).FirstOrDefault();
        }

    }
}
