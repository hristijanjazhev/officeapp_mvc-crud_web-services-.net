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
    public class InvoiceItemController : ApiController
    {
        InvoiceItemBLL invoiceItemBLL = new InvoiceItemBLL();
        InvoiceItemDAL invoiceItemDAL = new InvoiceItemDAL();
        int invoiceItemId;

        //GET : api/InvoiceItem
        #region GET
        [HttpGet]
        public IHttpActionResult GetAllInvoiceItems()
        {
            IEnumerable<InvoiceItem> invoiceItems = invoiceItemBLL.GetAll();
            List<Models.InvoiceItemViewModel> invoiceItemViewModels = new List<Models.InvoiceItemViewModel>();

            foreach(InvoiceItem i in invoiceItems)
            {
                Models.InvoiceItemViewModel invoiceItemToAdd = new Models.InvoiceItemViewModel();
                invoiceItemToAdd.InvoiceItemId = i.InvoiceItemId;
                invoiceItemToAdd.ItemName = i.ItemName;
                invoiceItemToAdd.InvoiceId = i.InvoiceId;
                invoiceItemToAdd.UnitPrice = i.UnitPrice;
                invoiceItemToAdd.Vat = i.Vat;
                invoiceItemToAdd.VatUnitPrice = i.VatUnitPrice;
                invoiceItemToAdd.Quantity = i.Quantity;
                invoiceItemToAdd.PriceIncludingVat = i.PriceIncludingVat;
                invoiceItemToAdd.PriceExcludingVat = i.PriceExcludingVat;
                invoiceItemToAdd.VatAmount = i.VatAmount;
                invoiceItemToAdd.DiscountAmount = i.DiscountAmount;
                invoiceItemToAdd.DiscountPersentage = i.DiscountPersentage;
                invoiceItemToAdd.IsActive = i.IsActive;
                //invoiceItemToAdd.IsDeleted = i.IsDeleted;

                invoiceItemViewModels.Add(invoiceItemToAdd);
            }
            return Ok();
        }
        #endregion

        //GET{id} : api/InvoiceItem/{id}
        #region GET{id}
        [HttpGet]
        public IHttpActionResult GetInvoiceItemsById(int id)
        {
            InvoiceItem invoiceItem = invoiceItemBLL.GetById(id);
            return Ok();
        }
        #endregion

        //POST : api/InvoiceItem
        #region POST
        [HttpPost]
        public IHttpActionResult InsertInvoiceItems(Models.InvoiceItemViewModel invoiceItemViewModel)
        {
            InvoiceItem invoiceItemToAdd = new InvoiceItem();
            invoiceItemToAdd.InvoiceItemId = invoiceItemViewModel.InvoiceItemId;
            invoiceItemToAdd.ItemName = invoiceItemViewModel.ItemName;
            invoiceItemToAdd.InvoiceId = invoiceItemViewModel.InvoiceId;
            invoiceItemToAdd.UnitPrice = invoiceItemViewModel.UnitPrice;
            invoiceItemToAdd.Vat = invoiceItemViewModel.Vat;
            invoiceItemToAdd.VatUnitPrice = invoiceItemViewModel.VatUnitPrice;
            invoiceItemToAdd.Quantity = invoiceItemViewModel.Quantity;
            invoiceItemToAdd.PriceIncludingVat = invoiceItemViewModel.PriceIncludingVat;
            invoiceItemToAdd.PriceExcludingVat = invoiceItemViewModel.PriceExcludingVat;
            invoiceItemToAdd.VatAmount = invoiceItemViewModel.VatAmount;
            invoiceItemToAdd.DiscountAmount = invoiceItemViewModel.DiscountAmount;
            invoiceItemToAdd.DiscountPersentage = invoiceItemViewModel.DiscountPersentage;
            invoiceItemToAdd.IsActive = invoiceItemViewModel.IsActive;
            invoiceItemToAdd.IsDeleted = invoiceItemViewModel.IsDeleted;

            var invoiceItemId = invoiceItemBLL.InsertReturnId(invoiceItemToAdd);


            if (!ModelState.IsValid)
            {
                return NotFound();
            }
            else
            {
                return Ok(invoiceItemId);
            }
        }
        #endregion

        //PUT : api/InvoiceItem
        #region PUT
        [HttpGet]
        public IHttpActionResult EditInvoiceItems(int id)
        {
            var invoices = invoiceItemDAL.GetById(id);
            return Ok();
        }
        [HttpPut]
        public IHttpActionResult EditInvoiceItems(int id,Models.InvoiceItemViewModel invoiceItemViewModel)
        {
            InvoiceItem invoiceItemToAdd = new InvoiceItem();
            invoiceItemToAdd.InvoiceItemId = invoiceItemViewModel.InvoiceItemId;
            invoiceItemToAdd.ItemName = invoiceItemViewModel.ItemName;
            invoiceItemToAdd.InvoiceId = invoiceItemViewModel.InvoiceId;
            invoiceItemToAdd.UnitPrice = invoiceItemViewModel.UnitPrice;
            invoiceItemToAdd.Vat = invoiceItemViewModel.Vat;
            invoiceItemToAdd.VatUnitPrice = invoiceItemViewModel.VatUnitPrice;
            invoiceItemToAdd.Quantity = invoiceItemViewModel.Quantity;
            invoiceItemToAdd.PriceIncludingVat = invoiceItemViewModel.PriceIncludingVat;
            invoiceItemToAdd.PriceExcludingVat = invoiceItemViewModel.PriceExcludingVat;
            invoiceItemToAdd.VatAmount = invoiceItemViewModel.VatAmount;
            invoiceItemToAdd.DiscountAmount = invoiceItemViewModel.DiscountAmount;
            invoiceItemToAdd.DiscountPersentage = invoiceItemViewModel.DiscountPersentage;
            invoiceItemToAdd.IsActive = invoiceItemViewModel.IsActive;
            invoiceItemToAdd.IsDeleted = invoiceItemViewModel.IsDeleted;

              invoiceItemBLL.Update(invoiceItemToAdd);

            if (!ModelState.IsValid)
            {
                return NotFound();
            }
            else
            {
                return Ok(invoiceItemToAdd);
            }
        }
        #endregion

        //DELETE : api/InvoiceItem
        #region DELETE
        [HttpDelete]
        public IHttpActionResult DeleteInvoiceItems(int id)
        {
            InvoiceItem invoiceItem = invoiceItemBLL.GetById(id);
            invoiceItemDAL.DeletePermanently(invoiceItem);
            return Ok();
        }
        #endregion
    }
}
