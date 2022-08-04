using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using BLL.Models;
using DAL_EF;
using DAL_EF.Models;

namespace API.Controllers
{
    public class OffersController : ApiController
    {
        OfferBLL offerBLL = new OfferBLL();
        OfferDAL offerDAL = new OfferDAL();
        int offerId;
        readonly DMSEntities db = new DMSEntities();

        // GET: api/Offers
        #region GET
        [HttpGet]
        public IHttpActionResult GetOffers()
        {
            var offers = offerBLL.GetAll();

            return Ok(offers);
        }
        #endregion

        // GET: api/Offers/5
        #region GET{id}
        [HttpGet]
        [ResponseType(typeof(Offer))]
        public IHttpActionResult GetOffer(int id)
        {
            Offer offer = db.Offers.Find(id);
            if (offer == null)
            {
                return NotFound();
            }

            return Ok(offer);
        }
        #endregion


        // POST: api/Offers
        #region POST
        [HttpPost]
        [ResponseType(typeof(Offer))]
        public IHttpActionResult PostOffer(Models.OfferViewModel offerViewModel)
        {
            Offer offer = new Offer();

            offerViewModel.OfferId = offer.OfferId;
            offerViewModel.OrganizationId = offer.OrganizationId;
            offerViewModel.PersonId = offer.PersonId;
            offerViewModel.OfferNumber = offer.OfferNumber;
            offerViewModel.Amount = offer.Amount;
            offerViewModel.DiscountPercent = offer.DiscountPercent;
            offerViewModel.DiscountAmount = offer.DiscountAmount;
            offerViewModel.OfferAmount = offer.OfferAmount;
            offerViewModel.CreateDate = offer.CreateDate;
            offerViewModel.ValidityDays = offer.ValidityDays;
            offerViewModel.ValidityDate = offer.ValidityDate;
            offerViewModel.Disclaimer = offer.Disclaimer;
            offerViewModel.Title = offer.Title;
            offerViewModel.Subject = offer.Subject;
            offerViewModel.Body = offer.Body;
            offerViewModel.Currency = offer.Currency;
            offerViewModel.CurrencyRate = offer.CurrencyRate;
            offerViewModel.Vat = offer.Vat;
            offerViewModel.VatAmount = offer.VatAmount;
            offerViewModel.ReasonForDeclining = offer.ReasonForDeclining;
            offerViewModel.IsAccepted = offer.IsAccepted;
            offerViewModel.IsDeleted = offer.IsDeleted;

            var offerId =  offerBLL.InsertReturnId(offer);


            if (!ModelState.IsValid)
            {
                return NotFound();
            }
            else
            {
                return Ok(offerId);
            }
        }
        #endregion

        // DELETE: api/Offers/5
        #region DELETE
        [HttpDelete]
        [ResponseType(typeof(Offer))]
        public IHttpActionResult DeleteOffer(int id)
        {
            Offer offer = offerDAL.GetById(id);
            offerDAL.DeletePermanently(offer);

            return Ok();
        }
        #endregion
    }
}