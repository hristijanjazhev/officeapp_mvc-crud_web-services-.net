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
        DMSEntities db = new DMSEntities();

        public List<Invoice> GetAll()
        {
            return db.Invoices.ToList();
        }

        public Invoice GetById(int id)
        {
            return db.Invoices.Where(p => p.InvoiceId == id).SingleOrDefault();
        }

        public void Insert(Invoice invoice)
        {
            db.Invoices.Add(invoice);
            db.SaveChanges();
        }

        public void Update(Invoice invoice)
        {
            db.Entry(invoice).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }

        public Int32 InsertReturnId(Invoice invoice)
        {
            int id = Int32.MinValue;
            db.Invoices.Add(invoice);
            TransactionScope ts = new TransactionScope();
            try
            {
                if (db.SaveChanges() > 0)
                {
                    id = invoice.InvoiceId;
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

        public void DeletePermanently(Invoice invoice)
        {
            db.Invoices.Remove(invoice);
            db.SaveChanges();
        }



    }
}
