using BLL.Models;
using DAL_EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Controllers
{
    public class InvoiceItemController : Controller
    {
        // GET: InvoiceItem
        InvoiceItemBLL invoiceItemBLL = new InvoiceItemBLL();
        InvoiceBLL invoiceBLL = new InvoiceBLL();

        // GET List: InvoiceItem
        public ActionResult Index()
        {
            List<InvoiceItem> listOfInvoiceItem = invoiceItemBLL.GetAll();
            return View(listOfInvoiceItem);

        }
    }
}