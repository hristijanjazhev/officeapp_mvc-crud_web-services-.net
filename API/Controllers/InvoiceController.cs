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
    public class InvoiceController : ApiController
    {
        InvoiceBLL invoiceBLL = new InvoiceBLL();
        InvoiceDAL invoiceDAL = new InvoiceDAL();
        int invoiceId;


        // GET: api/Invoice
        #region GET
        [HttpGet]
        public IHttpActionResult GetAllInvoices()
        {
            IEnumerable<Invoice> invoices = invoiceBLL.GetAll();
            List<Models.InvoiceViewModel> invoiceViewModels = new List<Models.InvoiceViewModel>();


            foreach (Invoice i in invoices)
            {
                Models.InvoiceViewModel newInvoiceToAdd = new Models.InvoiceViewModel();
                newInvoiceToAdd.InvoiceId = i.InvoiceId;
                newInvoiceToAdd.AgreementId = i.AgreementId;
                newInvoiceToAdd.InvoiceNumber = i.InvoiceNumber;
                newInvoiceToAdd.PersonId = i.PersonId;
                newInvoiceToAdd.OrganizationId = i.OrganizationId;
                newInvoiceToAdd.CreateDate = i.CreateDate;
                newInvoiceToAdd.InvoiceDate = i.InvoiceDate;
                newInvoiceToAdd.DueDays = i.DueDays;
                newInvoiceToAdd.DueDate = i.DueDate;
                newInvoiceToAdd.Amount = i.Amount;
                newInvoiceToAdd.DiscountAmount = i.DiscountAmount;
                newInvoiceToAdd.DiscountPercent = i.DiscountPercent;
                newInvoiceToAdd.Vat = i.Vat;
                newInvoiceToAdd.VatAmount = i.VatAmount;
                newInvoiceToAdd.TotalAmount = i.TotalAmount;
                newInvoiceToAdd.Currency = i.Currency;
                newInvoiceToAdd.CurrencyRate = i.CurrencyRate;
                newInvoiceToAdd.Disclaimer = i.Disclaimer;
                newInvoiceToAdd.IsPaid = i.IsPaid;
                newInvoiceToAdd.PaidDate = i.PaidDate;
                newInvoiceToAdd.IsActive = i.IsActive;
                newInvoiceToAdd.IsDeleted = i.IsDeleted;

                invoiceViewModels.Add(newInvoiceToAdd);


            }
            return Ok(invoiceViewModels);
        }
        #endregion


        // GET{id}: api/Invoice{id}
        #region GET{id}
        [HttpGet]
        public IHttpActionResult GetInvoiceById(int id)
        {
            var invoice = invoiceBLL.GetById(id);
            return Ok(invoice);
        }
        #endregion


        // POST : api/Invoice
        #region POST
        [HttpPost]
        public IHttpActionResult InsertInvoices(Models.InvoiceViewModel invoiceViewModel)
        {
            Invoice invoicesToAdd = new Invoice();
            invoicesToAdd.InvoiceId = invoiceViewModel.InvoiceId;
            invoicesToAdd.AgreementId = invoiceViewModel.AgreementId;
            invoicesToAdd.InvoiceNumber = invoiceViewModel.InvoiceNumber;
            invoicesToAdd.PersonId = invoiceViewModel.PersonId;
            invoicesToAdd.OrganizationId = invoiceViewModel.OrganizationId;
            invoicesToAdd.CreateDate = invoiceViewModel.CreateDate;
            invoicesToAdd.InvoiceDate = invoiceViewModel.InvoiceDate;
            invoicesToAdd.DueDays = invoiceViewModel.DueDays;
            invoicesToAdd.DueDate = invoiceViewModel.DueDate;
            invoicesToAdd.Amount = invoiceViewModel.Amount;
            invoicesToAdd.DiscountAmount = invoiceViewModel.DiscountAmount;
            invoicesToAdd.DiscountPercent = invoiceViewModel.DiscountPercent;
            invoicesToAdd.Vat = invoiceViewModel.Vat;
            invoicesToAdd.VatAmount = invoiceViewModel.VatAmount;
            invoicesToAdd.TotalAmount = invoiceViewModel.TotalAmount;
            invoicesToAdd.Currency = invoiceViewModel.Currency;
            invoicesToAdd.CurrencyRate = invoiceViewModel.CurrencyRate;
            invoicesToAdd.Disclaimer = invoiceViewModel.Disclaimer;
            invoicesToAdd.IsPaid = invoiceViewModel.IsPaid;
            invoicesToAdd.PaidDate = invoiceViewModel.PaidDate;
            invoicesToAdd.IsActive = invoiceViewModel.IsActive;
            invoicesToAdd.IsDeleted = invoiceViewModel.IsDeleted;

            var invoiceId = invoiceBLL.InsertReturnId(invoicesToAdd);

            if (!ModelState.IsValid)
            {
                return NotFound();
            }
            else
            {
                return Ok(invoiceId);
            }
        }
        #endregion


        // DELETE: api/Invoice/{id}
        #region DELETE
        [HttpDelete]
        public IHttpActionResult DeleteInvoices(int id)
        {
            Invoice invoice = invoiceBLL.GetById(id);
            invoiceDAL.DeletePermanently(invoice);

            return Ok(invoice);
        }
        #endregion
    }

}
