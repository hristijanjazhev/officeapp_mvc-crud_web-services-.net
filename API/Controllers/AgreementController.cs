using BLL;
using DAL_EF;
using DAL_EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
    public class AgreementController : ApiController
    {
        AgreementBLL agreementBLL = new AgreementBLL();
        AgreementDAL agreementDAL = new AgreementDAL();
        int agreementId;

        // GET: api/Agreement
        #region GET
        [HttpGet]
        public IHttpActionResult GetAllAgreements()
        {
            IEnumerable<Agreement> agreements = agreementBLL.GetAll();
            List<Models.AgreementViewModel> agreementViewModel = new List<Models.AgreementViewModel>();

            foreach (Agreement a in agreements)
            {
                Models.AgreementViewModel agreementView = new Models.AgreementViewModel();
                agreementView.AgreementId = a.AgreementId;
                agreementView.OfferId = a.OfferId;
                agreementView.AgreementNumber = a.AgreementNumber;
                agreementView.CreateDate = a.CreateDate;
                agreementView.PersonId = a.PersonId;
                agreementView.InvoiceId = a.InvoiceId;
                agreementView.StartDate = a.StartDate;
                agreementView.EndDate = a.EndDate;
                agreementView.Title = a.Title;
                agreementView.Subject = a.Subject;
                agreementView.Body = a.Body;
                agreementView.IsActive = a.IsActive;
                //agreementView.IsDeleted = a.IsDeleted;
                agreementViewModel.Add(agreementView);

            }
            return Ok(agreementViewModel);
        }
        #endregion

        // GET{id} : api/Agreement/{id}
        #region GET{id}
        public IHttpActionResult GetAgreementById(int id)
        {
            Agreement agreement = agreementBLL.GetById(id);

            return Ok(agreement);
        }
        #endregion

        // POST: api/Agreement
        #region POST
        [HttpPost]
        public IHttpActionResult InsertAgreements(Models.AgreementViewModel agreementViewModel)
        {
            Agreement newAgreementToAdd = new Agreement();
            newAgreementToAdd.AgreementId = agreementViewModel.AgreementId;
            newAgreementToAdd.OfferId = agreementViewModel.OfferId;
            newAgreementToAdd.AgreementNumber = agreementViewModel.AgreementNumber;
            newAgreementToAdd.CreateDate = agreementViewModel.CreateDate;
            newAgreementToAdd.PersonId = agreementViewModel.PersonId;
            newAgreementToAdd.InvoiceId = agreementViewModel.InvoiceId;
            newAgreementToAdd.StartDate = agreementViewModel.StartDate;
            newAgreementToAdd.EndDate = agreementViewModel.EndDate;
            newAgreementToAdd.Title = agreementViewModel.Title;
            newAgreementToAdd.Subject = agreementViewModel.Subject;
            newAgreementToAdd.Body = agreementViewModel.Body;
            newAgreementToAdd.IsActive = agreementViewModel.IsActive;
            newAgreementToAdd.IsDeleted = agreementViewModel.IsDeleted;

            var agreementId = agreementBLL.InsertReturnId(newAgreementToAdd);


            if (!ModelState.IsValid)
            {
                return NotFound();
            }
            else
            {
                return Ok(newAgreementToAdd);
            }
        }
        #endregion

        // PUT : api/Agreement
        #region PUT
        [HttpGet]
        public IHttpActionResult Edit(int id)
        {
            var agreement = agreementBLL.GetById(id);


            return Ok();
        }
        [HttpPut]
        public IHttpActionResult Edit(int id, Models.AgreementViewModel agreementViewModel)
        {
            Agreement agreementForUpdate = new Agreement();
            agreementForUpdate.AgreementId = id;
            agreementForUpdate.OfferId = agreementViewModel.OfferId;
            agreementForUpdate.AgreementNumber = agreementViewModel.AgreementNumber;
            agreementForUpdate.CreateDate = agreementViewModel.CreateDate;
            agreementForUpdate.PersonId = agreementViewModel.PersonId;
            agreementForUpdate.InvoiceId = agreementViewModel.InvoiceId;
            agreementForUpdate.StartDate = agreementViewModel.StartDate;
            agreementForUpdate.EndDate = agreementViewModel.EndDate;
            agreementForUpdate.Title = agreementViewModel.Title;
            agreementForUpdate.Subject = agreementViewModel.Subject;
            agreementForUpdate.Body = agreementViewModel.Body;
            agreementForUpdate.IsActive = agreementViewModel.IsActive;
            agreementForUpdate.IsDeleted = agreementViewModel.IsDeleted;

            agreementBLL.Update(agreementForUpdate);

            if (!ModelState.IsValid)
            {
                return NotFound();
            }
            else
            {
                return Ok(agreementForUpdate);
            }

        }

        #endregion

        // DELETE : api/Agreement
        #region DELETE
        [HttpDelete]
        public IHttpActionResult DeleteAgreement(int id)
        {
            Agreement agreement = agreementBLL.GetById(id);
            agreementDAL.DeletePermanently(agreement);


            return Ok();
        }
        #endregion


    }
}
