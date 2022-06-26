using BLL;
using BLL.Models;
using DAL_EF;
using DMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class InvoiceController : Controller
    {
        InvoiceBLL invoiceBLL = new InvoiceBLL();
        BLL.Models.AgreementBLL agreementBLL = new BLL.Models.AgreementBLL();
        OrganizationBLL organizationBLL = new OrganizationBLL();
        BusinessLogicLayer.PersonBLL personBLL = new BusinessLogicLayer.PersonBLL();
       
        
        // GET: Invoice
        public ActionResult Index()
        {
            List<Invoice> listOfInvoice = invoiceBLL.GetAll();
            return View(listOfInvoice);
        }
        public ActionResult Create()
        {
            ViewBag.AgreementId = new SelectList(agreementBLL.GetAll(), "AgreementId", "AgreementNumber");
            ViewBag.OrganizationId = new SelectList(organizationBLL.GetALL(), "OrganizationId", "OrganizationName");
            ViewBag.PersonId = new SelectList(personBLL.GetAll(), "PersonId", "PersonName");
            return View(new InvoiceAddEditModel());
        }

        //POST: Create
        [HttpPost, ActionName("Create")]
        public ActionResult Create(Models.InvoiceAddEditModel invoiceAddEditModel)
        {
            Invoice invoice = new Invoice();

            invoice.InvoiceNumber = invoiceAddEditModel.InvoiceNumber;

            invoice.AgreementId = invoiceAddEditModel.AgreementId;
            //invoice.OrganizationId = invoiceAddEditModel.OrganizationId;
            //invoice.PersonId = invoiceAddEditModel.PersonId;

            invoice.CreateDate = Convert.ToDateTime(invoiceAddEditModel.CreateDate);
            invoice.InvoiceDate = Convert.ToDateTime(invoiceAddEditModel.InvoiceDate);
            invoice.DueDays = invoiceAddEditModel.DueDays;
            invoice.DueDate = Convert.ToDateTime(invoiceAddEditModel.DueDate);
            invoice.Amount = invoiceAddEditModel.Amount;
            invoice.DiscountAmount = invoiceAddEditModel.DiscountAmount;
            invoice.DiscountPercent = invoiceAddEditModel.DiscountPercent;
            invoice.Vat = invoiceAddEditModel.Vat;
            invoice.VatAmount = invoiceAddEditModel.VatAmount;
            invoice.TotalAmount = invoiceAddEditModel.TotalAmount;
            invoice.Currency = invoiceAddEditModel.Currency;
            invoice.CurrencyRate = invoiceAddEditModel.CurrencyRate;
            invoice.Disclaimer = invoiceAddEditModel.Disclaimer;
            invoice.IsPaid = invoiceAddEditModel.IsPaid;
            invoice.PaidDate = Convert.ToDateTime(invoiceAddEditModel.PaidDate);
            invoice.IsActive = invoiceAddEditModel.IsActive;
            invoice.IsDeleted = invoiceAddEditModel.IsDeleted;

            invoiceBLL.Insert(invoice);

            return RedirectToAction("Index");
        }

    }
}