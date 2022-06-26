using BLL.Models;
using BusinessLogicLayer;
using DAL_EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Models;
using BLL;

namespace WebApp.Controllers
{
    public class NoticeController : Controller
    {
        NoticeBLL noticeBLL = new NoticeBLL();
        InvoiceBLL invoiceBLL = new InvoiceBLL();
        OrganizationBLL organizationBLL = new OrganizationBLL();
        PersonBLL personBLL = new PersonBLL();
        DMSEntities db = new DMSEntities();

        public ActionResult Index()
        {
            List<Notice> invoices = noticeBLL.GetAll();
            return View(invoices);
        }
        //CREATE
        public ActionResult Create()
        {
            ViewBag.InvoiceId = new SelectList(invoiceBLL.GetAll(), "InvoiceId", "InvoiceNumber");
            ViewBag.OrganizationId = new SelectList(organizationBLL.GetAllActive(), "OrganizationId", "OrganizationName");
            ViewBag.PersonId = new SelectList(personBLL.GetAll(), "PersonId", "PersonName");
            return View(new NoticeAddEditModel());
        }

        //POST:Create
        [HttpPost, ActionName("Create")]
        public ActionResult Create(Models.NoticeAddEditModel noticeAddEditModel)
        {
            Notice notice = new Notice();

            notice.NoticeText = noticeAddEditModel.NoticeText;
            notice.NoticeNumber = noticeAddEditModel.NoticeNumber;
            notice.NoticeDate = noticeAddEditModel.NoticeDate;
            notice.InvoiceId = noticeAddEditModel.InvoiceId;
            notice.OrganizationId = noticeAddEditModel.OrganizationId;
            notice.PersonId = noticeAddEditModel.PersonId;
            notice.IsActive = noticeAddEditModel.IsActive;
            notice.IsDeleted = noticeAddEditModel.IsDeleted;

            noticeBLL.Insert(notice);

            return RedirectToAction("Index");
        }
    }
}