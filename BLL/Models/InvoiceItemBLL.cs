using DAL_EF;
using DAL_EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class InvoiceItemBLL
    {
        InvoiceItemDAL invoiceItemDAL = new InvoiceItemDAL();

        public List<InvoiceItem> GetAll()
        {
            return invoiceItemDAL.GetAll();
        }

        public InvoiceItem GetById(Int32 id)
        {
            return invoiceItemDAL.GetById(id);
        }

        public void Insert(InvoiceItem invoiceItem)
        {
            invoiceItemDAL.Insert(invoiceItem);
        }

        public Int32 InsertReturnId(InvoiceItem invoiceItem)
        {
            return invoiceItemDAL.InsertReturnId(invoiceItem);
        }

        public void Update(InvoiceItem invoiceItem)
        {
            invoiceItemDAL.Update(invoiceItem);
        }

        public void Delete(InvoiceItem invoiceItem)
        {
            invoiceItem.IsActive = false;
            invoiceItem.IsDeleted = true;
            invoiceItemDAL.Update(invoiceItem);
        }

        public void DeletePermanently(InvoiceItem invoiceItem)
        {
            invoiceItemDAL.DeletePermanently(invoiceItem);

        }

        public IEnumerable<InvoiceItem> GetAllActive()
        {
            return invoiceItemDAL.GetAll().Where(p => p.IsActive == true && p.IsDeleted == false);
        }

        public IEnumerable<InvoiceItem> GetAllNotActive()
        {
            return invoiceItemDAL.GetAll().Where(p => p.IsActive == false && p.IsDeleted == false);
        }

        public IEnumerable<InvoiceItem> GetAllDeleted()
        {
            return invoiceItemDAL.GetAll().Where(p => p.IsActive == false && p.IsDeleted == true);
        }

        public InvoiceItem GetByInvoiceNumber(string ItemName)
        {
            return invoiceItemDAL.GetAll().Where(p => p.ItemName == ItemName).FirstOrDefault();
        }

        public List<InvoiceItem> GetAllInvoiceItemByInvoiceId(int id)
        {
            return invoiceItemDAL.GetAll().Where(item => item.InvoiceId == id).ToList();
        }


    }
}
