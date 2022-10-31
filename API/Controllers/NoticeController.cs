using BLL.Models;
using DAL_EF;
using DAL_EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
    public class NoticeController : ApiController
    {
        NoticeBLL noticeBLL = new NoticeBLL();
        NoticeDAL noticeDAL = new NoticeDAL();
        int noticeId;



        //GET : api/Notice
        #region GET
        [HttpGet]
        public IHttpActionResult GetAllNotices()
        {
            IEnumerable<Notice> notices = noticeBLL.GetAll();
            List<Models.NoticeViewModel> noticeViewModelsToAdd = new List<Models.NoticeViewModel>();
            
            foreach(Notice n in notices)
            {
                Models.NoticeViewModel noticeViewModel = new Models.NoticeViewModel();
                noticeViewModel.NoticeId = n.NoticeId;
                noticeViewModel.NoticeText = n.NoticeText;
                noticeViewModel.NoticeNumber = n.NoticeNumber;
                noticeViewModel.NoticeDate = n.NoticeDate;
                noticeViewModel.InvoiceId = n.InvoiceId;
                noticeViewModel.PersonId = n.PersonId;
                noticeViewModel.OrganizationId = n.OrganizationId;
                noticeViewModel.IsActive = n.IsActive;
                noticeViewModel.IsDeleted = n.IsDeleted;

                noticeViewModelsToAdd.Add(noticeViewModel);

            }
            return Ok(noticeViewModelsToAdd);
        }
        #endregion

        //GET{id} : api/Notice/{id}
        #region GET{id}
        [HttpGet]
        public IHttpActionResult GetNoticeById(int id)
        {
            var notices = noticeBLL.GetById(id);
            return Ok(notices);
        }
        #endregion

        //POST : api/Notice
        #region POST
        [HttpPost]
        public IHttpActionResult InsertNotice(Models.NoticeViewModel noticeViewModel)
        {
            Notice noticeToAdd = new Notice();
            noticeToAdd.NoticeId = noticeViewModel.NoticeId;
            noticeToAdd.NoticeText = noticeViewModel.NoticeText;
            noticeToAdd.NoticeNumber = noticeViewModel.NoticeNumber;
            noticeToAdd.NoticeDate = noticeViewModel.NoticeDate;
            noticeToAdd.InvoiceId = noticeViewModel.InvoiceId;
            noticeToAdd.PersonId = noticeViewModel.PersonId;
            noticeToAdd.OrganizationId = noticeViewModel.OrganizationId;
            noticeToAdd.IsActive = noticeViewModel.IsActive;
            noticeToAdd.IsDeleted = noticeViewModel.IsDeleted;

            var noticeId = noticeBLL.InsertReturnId(noticeToAdd);

            if (!ModelState.IsValid)
            {
                return NotFound();
            }
            else
            {
                return Ok(noticeId);
            }
        }
        #endregion

        //PUT : api/Notice
        #region PUT
        [HttpGet]
        public IHttpActionResult EditNotices(int id)
        {
            var notices = noticeBLL.GetById(id);
            return Ok(notices);
        }
        [HttpPut]
        public IHttpActionResult EditNotices(int id,Models.NoticeViewModel noticeViewModel)
        {
            Notice noticeToEdit = new Notice();
            noticeToEdit.NoticeId = noticeViewModel.NoticeId;
            noticeToEdit.NoticeText = noticeViewModel.NoticeText;
            noticeToEdit.NoticeNumber = noticeViewModel.NoticeNumber;
            noticeToEdit.NoticeDate = noticeViewModel.NoticeDate;
            noticeToEdit.InvoiceId = noticeViewModel.InvoiceId;
            noticeToEdit.PersonId = noticeViewModel.PersonId;
            noticeToEdit.OrganizationId = noticeViewModel.OrganizationId;
            noticeToEdit.IsActive = noticeViewModel.IsActive;
            noticeToEdit.IsDeleted = noticeViewModel.IsDeleted;

            var noticeId = noticeBLL.InsertReturnId(noticeToEdit);

            return Ok(noticeId);
        }
        #endregion

        //DELETE : api/Notice
        #region DELETE
        [HttpDelete]
        public IHttpActionResult DeleteNotices(int id)
        {
            Notice notice = noticeBLL.GetById(id);
            noticeDAL.DeletePermanently(notice);

            return Ok();
        }
        #endregion
    }
}
