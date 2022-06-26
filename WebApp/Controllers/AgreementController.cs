using BLL.Models;
using DAL_EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class AgreementController : Controller
    {

        AgreementBLL agreementBLL = new AgreementBLL();
        OfferBLL offerBLL = new OfferBLL();

        // GET: Agreement
        public ActionResult Index()
        {
            List<Agreement> ListOfAgreement = agreementBLL.GetAll();
            return View(ListOfAgreement);
        }

        //GET Create
        public ActionResult Create()
        {
            ViewBag.OfferId = new SelectList(offerBLL.GetAll(), "OfferId", "OfferNumber");
            return View(new Agreement());
        }

        //POST Create
        [HttpPost, ActionName("Create")]
        public ActionResult Create(Models.AgreementAddEditModel agreementAddEditModel)
        {

            Agreement agreementToCheck = agreementBLL.GetByAgreementNumber(agreementAddEditModel.AgreementNumber);
            if (ModelState.IsValid)
            {

                if (agreementToCheck != null)
                {
                    TempData["Message"] = "Договорот постои";
                    TempData.Keep();
                }
                else
                {

                    Agreement agreement = new Agreement();


                    agreement.AgreementNumber = agreementAddEditModel.AgreementNumber;
                    agreement.CreateDate = agreementAddEditModel.CreateDate;
                    agreement.StartDate = agreementAddEditModel.StartDate;
                    agreement.EndDate = agreementAddEditModel.EndDate;
                    agreement.Title = agreementAddEditModel.Title;
                    agreement.Subject = agreementAddEditModel.Subject;
                    agreement.Body = agreementAddEditModel.Body;
                    agreement.IsActive = agreementAddEditModel.IsActive;
                    agreement.IsDeleted = agreementAddEditModel.IsDeleted;

                    agreement.OfferId = agreementAddEditModel.OfferId;

                    agreementBLL.Insert(agreement);

                    TempData["Message"] = "Успешно го креиравте договорот со број " + agreement.AgreementNumber;

                    return RedirectToAction("Details", new { id = agreement.AgreementId });
                }
            }
            return View();
            //return RedirectToAction("Index");
        }

        //GET Edit
        public ActionResult Edit(int id)
        {
            Agreement agreement = agreementBLL.GetById(id);
            Models.AgreementAddEditModel agreementAddEditModel = new Models.AgreementAddEditModel();

            agreementAddEditModel.AgreementId = agreement.AgreementId;
            agreementAddEditModel.AgreementNumber = agreement.AgreementNumber;
            agreementAddEditModel.CreateDate = agreement.CreateDate;
            agreementAddEditModel.StartDate = agreement.StartDate;
            agreementAddEditModel.EndDate = agreement.EndDate;
            agreementAddEditModel.Title = agreement.Title;
            agreementAddEditModel.Subject = agreement.Subject;
            agreementAddEditModel.Body = agreement.Body;
            agreementAddEditModel.IsActive = agreement.IsActive;
            agreementAddEditModel.IsDeleted = agreement.IsDeleted;

            agreementAddEditModel.OfferId = agreement.OfferId;

            return View(agreementAddEditModel);
        }

        //POST Edit
        [HttpPost, ActionName("Edit")]
        public ActionResult Edit(Models.AgreementAddEditModel agreementAddEditModel)
        {
            Agreement agreementForUpdate = new Agreement();

            agreementForUpdate.AgreementId = agreementAddEditModel.AgreementId;
            agreementForUpdate.AgreementNumber = agreementAddEditModel.AgreementNumber;
            agreementForUpdate.CreateDate = Convert.ToDateTime(agreementAddEditModel.CreateDate);
            agreementForUpdate.StartDate = Convert.ToDateTime(agreementAddEditModel.StartDate);
            agreementForUpdate.EndDate = Convert.ToDateTime(agreementAddEditModel.EndDate);
            agreementForUpdate.Title = agreementAddEditModel.Title;
            agreementForUpdate.Subject = agreementAddEditModel.Subject;
            agreementForUpdate.Body = agreementAddEditModel.Body;
            agreementForUpdate.IsActive = agreementAddEditModel.IsActive;
            agreementForUpdate.IsDeleted = agreementAddEditModel.IsDeleted;

            agreementForUpdate.OfferId = agreementAddEditModel.OfferId;

            agreementBLL.Update(agreementForUpdate);

            return RedirectToAction("Index");
        }

        //Delete
        public ActionResult Delete(int id)
        {
            Agreement agreement = agreementBLL.GetById(id);
            agreementBLL.DeletePermanently(agreement);
            return RedirectToAction("Index");

        }

        //Details
        public ActionResult Details(int id)
        {
            Agreement agreement = agreementBLL.GetById(id);
            Models.AgreementAddEditModel agreementViewModel = GetAllElementsFromModel(agreement);
            return View(agreementViewModel);
        }

        [NonAction]
        public virtual Models.AgreementAddEditModel GetAllElementsFromModel(Agreement agreement)
        {
            Models.AgreementAddEditModel agreementViewModel = new Models.AgreementAddEditModel();

            agreementViewModel.AgreementId = agreement.AgreementId;
            agreementViewModel.AgreementNumber = agreement.AgreementNumber;
            agreementViewModel.CreateDate = Convert.ToDateTime(agreement.CreateDate);
            agreementViewModel.StartDate = Convert.ToDateTime(agreement.StartDate);
            agreementViewModel.EndDate = Convert.ToDateTime(agreement.EndDate);
            agreementViewModel.Title = agreement.Title;
            agreementViewModel.Subject = agreement.Subject;
            agreementViewModel.Body = agreement.Body;
            agreementViewModel.IsActive = agreement.IsActive;
            agreementViewModel.IsDeleted = agreement.IsDeleted;
            agreementViewModel.OfferId = agreement.OfferId;

            return agreementViewModel;
        }
    }
}