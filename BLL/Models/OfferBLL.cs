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
        OfferDAL offerDAL = new OfferDAL();

        public List<Offer> GetAll()
        {
            return offerDAL.GetAll().ToList();
        }

        public Offer GetById(Int32 id)
        {
            return offerDAL.GetById(id);
        }
        public void Insert(Offer offer)
        {
            offerDAL.Insert(offer);
        }

        public Int32 InsertReturnId(Offer offer)
        {
            return offerDAL.InsertReturnId(offer);
        }
        public void Update(Offer offer)
        {
            offerDAL.Update(offer);
        }
        public void Delete(Offer offer)
        {
            //offer.IsAccepted == false;
            //offer.IsDeleted == true;
            offerDAL.Update(offer);
        }
        public void DeletePermanently(Offer offer)
        {

            offerDAL.DeletePermanently(offer);

        }

        public IEnumerable<Offer> GetAllActive()
        {
            return offerDAL.GetAll().Where(p => p.IsAccepted == true && p.IsDeleted == false);
        }

        public IEnumerable<Offer> GetAllNotActive()
        {
            return offerDAL.GetAll().Where(p => p.IsAccepted == false && p.IsDeleted == false);
        }

        public IEnumerable<Offer> GetAllDeleted()
        {
            return offerDAL.GetAll().Where(p => p.IsAccepted == false && p.IsDeleted == true);
        }

        public Offer GetByIdNumber(string offerNumber)
        {
            return offerDAL.GetAll().Where(p => p.OfferNumber == offerNumber).SingleOrDefault();
        }

        public List<Offer> GetAllOffersByOrganizationId(int id)
        {
            return offerDAL.GetAll().Where(item => item.OrganizationId == id).ToList();
        }

    }
}
