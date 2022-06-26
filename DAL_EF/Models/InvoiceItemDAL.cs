using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace DAL_EF.Models
{
    public class InvoiceItemDAL
    {
        readonly DMSEntities db = new DMSEntities();

        public List<InvoiceItem> GetAll()
        {
            return db.InvoiceItems.ToList();
        }

        public InvoiceItem GetById(int id)
        {
            return db.InvoiceItems.Where(p => p.InvoiceItemId == id).SingleOrDefault();
        }

        public void Insert(InvoiceItem invoiceItem)
        {
            db.InvoiceItems.Add(invoiceItem);
            db.SaveChanges();
        }

        public void Update(InvoiceItem invoiceItem)
        {
            db.Entry(invoiceItem).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }

        public Int32 InsertReturnId(InvoiceItem invoiceItem)
        {
            int id = Int32.MinValue;
            db.InvoiceItems.Add(invoiceItem);
            TransactionScope ts = new TransactionScope();
            try
            {
                if (db.SaveChanges() > 0)
                {
                    id = invoiceItem.InvoiceItemId;
                    ts.Complete();
                }

            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message, ex.InnerException);
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

        public void DeletePermanently(InvoiceItem invoiceItem)
        {
            db.InvoiceItems.Remove(invoiceItem);
            db.SaveChanges();
        }

    }
}
