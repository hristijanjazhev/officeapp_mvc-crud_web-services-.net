using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace DAL_EF.Models
{
    public class InvoiceDAL
    {
        readonly DMSEntities db = new DMSEntities();

        #region CREATE
        public void Insert(Invoice invoice)
        {
            db.Invoices.Add(invoice);
        }

        public int InsertReturnId(Invoice invoice)
        {
            int id = 0;
            db.Invoices.Add(invoice);
            TransactionScope ts = new TransactionScope();

            try
            {
                if (db.SaveChanges() > 0)
                {
                    id = invoice.AgreementId;
                    ts.Complete();
                }
            }
            catch (Exception e)
            {
                throw new ArgumentException(e.Message, e.InnerException);
            }
            finally
            {
                if (ts != null)
                {
                    ((IDisposable)ts).Dispose();
                }
            }

            return id;
        }
        #endregion

        #region RETRIEVE
        public IQueryable<Invoice> GetAll()
        {
            return db.Invoices;
        }

        public Invoice GetById(int id)
        {
            return db.Invoices.Where(a => a.InvoiceId == id).SingleOrDefault();
        }
        public IQueryable<Invoice> GetAllActive()
        {
            return db.Invoices.Where(a => a.IsActive == true);
        }

        public IQueryable<Invoice> GetAllNotActive()
        {
            return db.Invoices.Where(a => a.IsActive == false);
        }

        public IQueryable<Invoice> GetAllDeleted()
        {
            return db.Invoices.Where(a => a.IsDeleted == true);
        }
        #endregion

        #region UPDATE
        public void Update(Invoice invoice)
        {
            db.Entry(invoice).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }
        #endregion

        #region DELETE
        public void Delete(Invoice invoice)
        {
            db.Invoices.Remove(invoice);
        }

        public void DeletePermanently(Invoice invoice)
        {
            db.Invoices.Remove(invoice);
            db.SaveChanges();
        }
        #endregion
    }
}
