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

        #region CREATE
        public void Insert(Offer offer)
        {
            db.Offers.Add(offer);
        }

        public int InsertReturnId(Offer offer)
        {
            int id = 0;
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
        public IQueryable<Offer> GetAll()
        {
            return db.Offers;
        }

        public Offer GetById(int id)
        {
            return db.Offers.Where(a => a.OfferId == id).SingleOrDefault();
        }
        public IQueryable<Offer> GetAllActive()
        {
            return db.Offers.Where(a => a.IsAccepted == true);
        }

        public IQueryable<Offer> GetAllNotActive()
        {
            return db.Offers.Where(a => a.IsAccepted == false);
        }

        public IQueryable<Offer> GetAllDeleted()
        {
            return db.Offers.Where(a => a.IsDeleted == true);
        }
        #endregion

        #region UPDATE
        public void Update(Offer offer)
        {
            db.Entry(offer).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }
        #endregion

        #region DELETE
        public void Delete(Offer offer)
        {
            db.Offers.Remove(offer);
        }

        public void DeletePermanently(Offer offer)
        {
            db.Offers.Remove(offer);
            db.SaveChanges();
        }
        #endregion
    }
}
