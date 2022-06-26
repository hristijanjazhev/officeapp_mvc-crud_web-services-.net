using BLL.Models;
using BusinessLogicLayer;
using DAL_EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{

    public class OfferController : Controller
    {
        OfferBLL offerBLL = new OfferBLL();
        OrganizationBLL organizationBLL = new OrganizationBLL();
        PersonBLL personBLL = new PersonBLL();

        // GET: List
        public ActionResult Index()
        {
            List<Offer> listOfOffer = offerBLL.GetAll();
            return View(listOfOffer);
        }


        //GET Create
        public ActionResult Create()
        {
            //List<Organization> listOrganization = organizationBLL.GetAll();
            //ViewBag.OrganizationList = new SelectList(listOrganization, "OrganizationId", "OrganizationName");
            ViewBag.OrganizationId = new SelectList(organizationBLL.GetALL(), "OrganizationId", "OrganizationName");
            ViewBag.PersonId = new SelectList(personBLL.GetAll(), "PersonId", "PersonName");

            return View(new OfferAddEditModel());
        }

        //POST Create
        [HttpPost, ActionName("Create")]
        //public ActionResult Create(Offer offerFromView)
        public ActionResult Create(Models.OfferAddEditModel offerAddEditModel)
        {
            Offer offerToCheck = offerBLL.GetByIdNumber(offerAddEditModel.OfferNumber);


            if (ModelState.IsValid)
            {

                if (offerToCheck != null)
                {
                    TempData["Message"] = "Понудата постои";
                    TempData.Keep();
                }
                else
                {
                    Offer offer = new Offer();

                    offer.OfferNumber = offerAddEditModel.OfferNumber;
                    offer.Amount = offerAddEditModel.Amount;
                    offer.DiscountPercent = offerAddEditModel.DiscountPercent;
                    offer.DiscountAmount = offerAddEditModel.DiscountAmount;
                    offer.OfferAmount = offerAddEditModel.OfferAmount;

                    offer.CreateDate = Convert.ToDateTime(offerAddEditModel.CreateDate);
                    //offer.CreateDate = DateTime.Now;
                    //offer.CreateDate = offerAddEditModel.CreateDate;
                    offer.ValidityDays = offerAddEditModel.ValidityDays;
                    offer.ValidityDate = DateTime.Now;
                    //offer.ValidityDate = offerAddEditModel.ValidityDate;
                    offer.Disclaimer = offerAddEditModel.Disclaimer;
                    offer.Title = offerAddEditModel.Title;
                    offer.Subject = offerAddEditModel.Subject;
                    offer.Body = offerAddEditModel.Body;
                    offer.Currency = offerAddEditModel.Currency;
                    offer.CurrencyRate = offerAddEditModel.CurrencyRate;
                    offer.Vat = offerAddEditModel.Vat;
                    offer.VatAmount = offerAddEditModel.VatAmount;
                    offer.ReasonForDeclining = offerAddEditModel.ReasonForDeclining;
                    offer.IsAccepted = offerAddEditModel.IsAccepted;
                    offer.IsDeleted = offerAddEditModel.IsDeleted;
                    offer.OrganizationId = offerAddEditModel.OrganizationId;
                    offer.PersonId = offerAddEditModel.PersonId;

                    //ViewBag.OrganizationId = new SelectList(organizationBLL.GetAll(), "Organization", "OrganizationName");

                    //if (offerFromView.OrganizationId == null && offerFromView.PersonId == null)
                    //{

                    //}

                    offerBLL.Insert(offer);

                    //return RedirectToAction("Index");

                    TempData["Message"] = "Успешно ја креиравте понудата " + offer.OfferNumber;

                    return RedirectToAction("Details", new { id = offer.OfferId });
                }

            }
            return View();
        }

        //GET Edit
        public ActionResult Edit(int id)
        {
            Offer offer = offerBLL.GetById(id);


            Models.OfferAddEditModel offerAddEditModel = new Models.OfferAddEditModel();

            offerAddEditModel.OfferId = offer.OfferId;
            offerAddEditModel.OfferNumber = offer.OfferNumber;
            offerAddEditModel.Amount = offer.Amount;
            offerAddEditModel.DiscountPercent = offer.DiscountPercent;
            offerAddEditModel.DiscountAmount = offer.DiscountAmount;
            offerAddEditModel.OfferAmount = offer.OfferAmount;
            offerAddEditModel.CreateDate = Convert.ToDateTime(offer.CreateDate);
            offerAddEditModel.ValidityDays = offer.ValidityDays;
            offerAddEditModel.ValidityDate = Convert.ToDateTime(offer.ValidityDate);
            offerAddEditModel.Disclaimer = offer.Disclaimer;
            offerAddEditModel.Title = offer.Title;
            offerAddEditModel.Subject = offer.Subject;
            offerAddEditModel.Body = offer.Body;
            offerAddEditModel.Currency = offer.Currency;
            offerAddEditModel.CurrencyRate = offer.CurrencyRate;
            offerAddEditModel.Vat = offer.Vat;
            offerAddEditModel.VatAmount = offer.VatAmount;
            offerAddEditModel.ReasonForDeclining = offer.ReasonForDeclining;
            offerAddEditModel.IsAccepted = offer.IsAccepted;
            offerAddEditModel.IsDeleted = offer.IsDeleted;

            offerAddEditModel.OrganizationId = offer.OrganizationId;
            offerAddEditModel.PersonId = offer.PersonId;

            return View(offerAddEditModel);
        }

        //POST Edit
        [HttpPost, ActionName("Edit")]
        public ActionResult Edit(Models.OfferAddEditModel offerAddEditModel)
        {
            Offer offerForUpdate = new Offer();

            offerForUpdate.OfferId = offerAddEditModel.OfferId;
            offerForUpdate.OfferNumber = offerAddEditModel.OfferNumber;
            offerForUpdate.Amount = offerAddEditModel.Amount;
            offerForUpdate.DiscountPercent = offerAddEditModel.DiscountPercent;
            offerForUpdate.DiscountAmount = offerAddEditModel.DiscountAmount;
            offerForUpdate.OfferAmount = offerAddEditModel.OfferAmount;
            offerForUpdate.CreateDate = Convert.ToDateTime(offerAddEditModel.CreateDate);
            offerForUpdate.ValidityDays = offerAddEditModel.ValidityDays;
            offerForUpdate.ValidityDate = DateTime.Now;
            offerForUpdate.Disclaimer = offerAddEditModel.Disclaimer;
            offerForUpdate.Title = offerAddEditModel.Title;
            offerForUpdate.Subject = offerAddEditModel.Subject;
            offerForUpdate.Body = offerAddEditModel.Body;
            offerForUpdate.Currency = offerAddEditModel.Currency;
            offerForUpdate.CurrencyRate = offerAddEditModel.CurrencyRate;
            offerForUpdate.Vat = offerAddEditModel.Vat;
            offerForUpdate.VatAmount = offerAddEditModel.VatAmount;
            offerForUpdate.ReasonForDeclining = offerAddEditModel.ReasonForDeclining;
            offerForUpdate.IsAccepted = offerAddEditModel.IsAccepted;
            offerForUpdate.IsDeleted = offerAddEditModel.IsDeleted;
            offerForUpdate.OrganizationId = offerAddEditModel.OrganizationId;
            offerForUpdate.PersonId = offerAddEditModel.PersonId;

            offerBLL.Update(offerForUpdate);

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            Offer offer = offerBLL.GetById(id);
            offerBLL.DeletePermanently(offer);
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            Offer offer = offerBLL.GetById(id);
            Models.OfferAddEditModel offerViewModel = GetAllElementsFromCustomModel(offer);
            return View(offerViewModel);
        }

        [NonAction]
        public virtual Models.OfferAddEditModel GetAllElementsFromCustomModel(Offer offer)
        {
            Models.OfferAddEditModel offerViewModel = new Models.OfferAddEditModel();

            offerViewModel.OfferId = offer.OfferId;
            offerViewModel.OfferNumber = offer.OfferNumber;
            offerViewModel.Amount = offer.Amount;
            offerViewModel.DiscountPercent = offer.DiscountPercent;
            offerViewModel.DiscountAmount = offer.DiscountAmount;
            offerViewModel.OfferAmount = offer.OfferAmount;
            offerViewModel.CreateDate = Convert.ToDateTime(offer.CreateDate);
            offerViewModel.ValidityDays = offer.ValidityDays;
            offerViewModel.ValidityDate = Convert.ToDateTime(offer.ValidityDate);
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

            offerViewModel.OrganizationId = offer.OrganizationId;
            offerViewModel.PersonId = offer.PersonId;

            return offerViewModel;

        }
    }


}
       
