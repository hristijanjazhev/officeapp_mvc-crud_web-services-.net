using DAL_EF;
using DAL_EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class OfferBLL
    {
        readonly OfferDAL offerDAL = new OfferDAL();

        #region CREATE
        public void Insert(Offer offer)
        {
            offerDAL.Insert(offer);
        }

        public int InsertReturnId(Offer offer)
        {
            return offerDAL.InsertReturnId(offer);
        }
        #endregion

        #region RETRIEVE
        public List<Offer> GetAll()
        {
            return offerDAL.GetAll().ToList();
        }

        public Offer GetById(int id)
        {
            return offerDAL.GetById(id);
        }

        public List<Offer> GetAllActive()
        {
            return offerDAL.GetAllActive().ToList();
        }
        #endregion

        #region UPDATE
        public void Update(Offer offer)
        {
            offerDAL.Update(offer);
        }
        #endregion

        #region DELETE
        public void Delete(Offer offer)
        {
            offerDAL.Delete(offer);
        }

        public void DeletePermanently(Offer offer)
        {
            offerDAL.DeletePermanently(offer);
        }
        #endregion
    }
}
