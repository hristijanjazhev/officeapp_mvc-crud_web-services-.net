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

        #region CREATE
        public void Insert(Notice notice)
        {
            noticeDAL.Insert(notice);
        }

        public int InsertReturnId(Notice notice)
        {
            return noticeDAL.InsertReturnId(notice);
        }
        #endregion

        #region RETRIEVE
        public List<Notice> GetAll()
        {
            return noticeDAL.GetAll().ToList();
        }

        public Notice GetById(int id)
        {
            return noticeDAL.GetById(id);
        }

        public List<Notice> GetAllActive()
        {
            return noticeDAL.GetAllActive().ToList();
        }
        #endregion

        #region UPDATE
        public void Update(Notice notice)
        {
            noticeDAL.Update(notice);
        }
        #endregion

        #region DELETE
        public void Delete(Notice notice)
        {
            noticeDAL.Delete(notice);
        }

        public void DeletePermanently(Notice notice)
        {
            noticeDAL.DeletePermanently(notice);
        }
        #endregion
    }
}
