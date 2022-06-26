using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace DAL_EF.Models
{
    public class OfferDAL
    {
        readonly DMSEntities db = new DMSEntities();
        public List<Offer> GetAll()
        {
            return db.Offers.ToList();
        }

        public Offer GetById(int id)
        {
            return db.Offers.Where(p => p.OfferId == id).SingleOrDefault();
        }
        public void Insert(Offer offer)
        {
            db.Offers.Add(offer);
            db.SaveChanges();
        }
        public void Update(Offer offer)
        {
            _ = db.Entry(offer).State == System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }

        public Int32 InsertReturnId(Offer offer)
        {
            int id = Int32.MinValue;
            db.Offers.Add(offer);
            TransactionScope ts = new TransactionScope();
            try
            {
                if (db.SaveChanges() > 0)
                {
                    id = offer.OfferId;
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
        public void DeletePermanently(Offer offer)
        {
            db.Offers.Remove(offer);
            db.SaveChanges();
        }
    }
}
