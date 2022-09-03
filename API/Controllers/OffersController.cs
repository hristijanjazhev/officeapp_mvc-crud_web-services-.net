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

        // GET: api/Offers
        #region GET
        [HttpGet]
        public IHttpActionResult GetAllOffers()
        {
            IEnumerable<Offer> offers = offerBLL.GetAll();
            List<Models.OfferViewModel> offerViewModels = new List<Models.OfferViewModel>();


            foreach(Offer o in offers)
            {
                Models.OfferViewModel newOfferViewModels = new Models.OfferViewModel();
                newOfferViewModels.OfferId = o.OfferId;
                newOfferViewModels.OrganizationId = o.OrganizationId;
                newOfferViewModels.PersonId = o.PersonId;
                newOfferViewModels.InvoiceItemId = o.InvoiceItemId;
                newOfferViewModels.OfferNumber = o.OfferNumber;
                newOfferViewModels.Amount = o.Amount;
                newOfferViewModels.DiscountPercent = o.DiscountPercent;
                newOfferViewModels.DiscountAmount = o.DiscountAmount;
                newOfferViewModels.OfferAmount = o.OfferAmount;
                newOfferViewModels.CreateDate = o.CreateDate;
                newOfferViewModels.ValidityDays = o.ValidityDays;
                newOfferViewModels.ValidityDate = o.ValidityDate;
                newOfferViewModels.Disclaimer = o.Disclaimer;
                newOfferViewModels.Title = o.Title;
                newOfferViewModels.Subject = o.Subject;
                newOfferViewModels.Body = o.Body;
                newOfferViewModels.Currency = o.Currency;
                newOfferViewModels.CurrencyRate = o.CurrencyRate;
                newOfferViewModels.Vat = o.Vat;
                newOfferViewModels.VatAmount = o.VatAmount;
                newOfferViewModels.ReasonForDeclining = o.ReasonForDeclining;
                newOfferViewModels.IsAccepted = o.IsAccepted;
                newOfferViewModels.IsDeleted = o.IsDeleted;

                offerViewModels.Add(newOfferViewModels);
            }
            return Ok();
        }
        #endregion

        // GET: api/Offers/5
        #region GET{id}
        [HttpGet]
        public IHttpActionResult GetOffer(int id)
        {
            var offers = offerBLL.GetById(id);
            return Ok();
        }
        #endregion


        // POST: api/Offers
        #region POST
        [HttpPost]
        public IHttpActionResult InsertOffer(Models.OfferViewModel offerViewModel)
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
        public IHttpActionResult DeleteOffer(int id)
        {
            Offer offer = offerDAL.GetById(id);
            offerDAL.DeletePermanently(offer);

            return Ok();
        }
        #endregion
    }
}