using DAL_EF;
using DAL_EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class InvoiceBLL
    {
        readonly InvoiceDAL invoiceDAL = new InvoiceDAL();

        #region CREATE
        public void Insert(Invoice invoice)
        {
            invoiceDAL.Insert(invoice);
        }

        public int InsertReturnId(Invoice invoice)
        {
            return invoiceDAL.InsertReturnId(invoice);
        }
        #endregion

        #region RETRIEVE
        public List<Invoice> GetAll()
        {
            return invoiceDAL.GetAll().ToList();
        }

        public Invoice GetById(int id)
        {
            return invoiceDAL.GetById(id);
        }

        public List<Invoice> GetAllActive()
        {
            return invoiceDAL.GetAllActive().ToList();
        }
        #endregion

        #region UPDATE
        public void Update(Invoice invoice)
        {
            invoiceDAL.Update(invoice);
        }
        #endregion

        #region DELETE
        public void Delete(Invoice invoice)
        {
            invoiceDAL.Delete(invoice);
        }

        public void DeletePermanently(Invoice invoice)
        {
            invoiceDAL.DeletePermanently(invoice);
        }
        #endregion
    }
}
