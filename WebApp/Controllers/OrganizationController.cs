using BLL.Models;
using BusinessLogicLayer;
using DAL_EF;
using DAL_EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class OrganizationController : Controller
    {
        OrganizationBLL organizationBLL = new OrganizationBLL();
        AddressBLL addressBLL = new AddressBLL();

        //List
        #region ListOfOrganization
        public ActionResult Index()
        {
            List<Organization> ListOfOrganization = organizationBLL.GetALL();
            return View(ListOfOrganization);
        }
        #endregion

        //Create?
        #region CreateNew
        public ActionResult Create()
        {

            return View(new OrganizationAddEditModel());
        }

        [HttpPost, ActionName("Create")]
        public ActionResult Create(Models.OrganizationAddEditModel organizationFromView)
        {

            Organization organizationToCheck = organizationBLL.GetByVatNumberAndByCompanyId(organizationFromView.VatNumber, organizationFromView.CompanyId);
            if (ModelState.IsValid)
            {

                if (organizationToCheck != null)
                {
                    TempData["Message"] = "Компанијата постои";
                    TempData.Keep();
                }
                else
                {

                    Address address = new Address();
                    Int32 addressIdFromDatabase = 0;

                    address.City = organizationFromView.City;
                    address.Country = organizationFromView.Country;
                    address.PostCode = organizationFromView.PostCode;
                    address.Street = organizationFromView.Street;
                    address.Province = organizationFromView.Province;
                    address.State = organizationFromView.State;
                    address.Number = organizationFromView.Number;
                    address.IsActive = organizationFromView.IsActive;
                    address.IsDeleted = organizationFromView.IsDeleted;


                    addressIdFromDatabase = addressBLL.InsertReturnId(address);

                    Organization organization = new Organization();

                    organization.OrganizationName = organizationFromView.OrganizationName;
                    organization.CompanyId = organizationFromView.CompanyId;
                    organization.VatNumber = organizationFromView.VatNumber;
                    organization.Description = organizationFromView.Description;
                    organization.Email = organizationFromView.Email;
                    organization.PhoneNumber = organizationFromView.PhoneNumber;
                    organization.Type = organizationFromView.Type;
                    organization.AddressId = addressIdFromDatabase;
                    organization.IsActive = organizationFromView.IsActive;
                    organization.IsDeleted = organizationFromView.IsDeleted;

                    organizationBLL.Insert(organization);

                    TempData["Message"] = "Успешно ја креиравте компанијата " + organization.OrganizationName;

                    return RedirectToAction("Index", new { id = organization.OrganizationId });
                }
            }

            return View();

        }
        #endregion


        //Edit
        #region Edit
        [HttpGet]
        public ActionResult Edit(int id)
        {

            Organization organization = organizationBLL.GetById(id);
            Address address = addressBLL.GetById(organization.AddressId);

            Models.OrganizationAddEditModel organizatoAtEditModelObject = new Models.OrganizationAddEditModel();

            organizatoAtEditModelObject.OrganizationId = organization.OrganizationId;
            organizatoAtEditModelObject.OrganizationName = organization.OrganizationName;
            organizatoAtEditModelObject.CompanyId = organization.CompanyId;
            organizatoAtEditModelObject.VatNumber = organization.VatNumber;
            organizatoAtEditModelObject.Description = organization.Description;
            organizatoAtEditModelObject.Email = organization.Email;
            organizatoAtEditModelObject.PhoneNumber = organization.PhoneNumber;
            organizatoAtEditModelObject.Type = organization.Type;
            organizatoAtEditModelObject.IsActive = organization.IsActive;
            organizatoAtEditModelObject.IsDeleted = organization.IsDeleted;


            organizatoAtEditModelObject.AddressId = address.AddressId;
            organizatoAtEditModelObject.Street = address.Street;
            organizatoAtEditModelObject.Number = address.Number;
            organizatoAtEditModelObject.PostCode = address.PostCode;
            organizatoAtEditModelObject.City = address.City;
            organizatoAtEditModelObject.State = address.State;
            organizatoAtEditModelObject.Province = address.Province;
            organizatoAtEditModelObject.Country = address.Country;
            return View(organizatoAtEditModelObject);
        }


        [HttpPost, ActionName("Edit")]
        public ActionResult Edit(Models.OrganizationAddEditModel organization)
        {

            Organization organizationForUpdate = new Organization();

            if (ModelState.IsValid)
            {
                organizationForUpdate.OrganizationId = organization.OrganizationId;
                organizationForUpdate.OrganizationName = organization.OrganizationName;
                organizationForUpdate.VatNumber = organization.VatNumber;
                organizationForUpdate.Description = organization.Description;
                organizationForUpdate.Type = organization.Type;
                organizationForUpdate.Email = organization.Email;
                organizationForUpdate.PhoneNumber = organization.PhoneNumber;
                organizationForUpdate.AddressId = organization.AddressId;
                organizationForUpdate.IsActive = organization.IsActive;
                organizationForUpdate.IsDeleted = organization.IsDeleted;
                organizationForUpdate.CompanyId = organization.CompanyId;

                Address addressForUpdate = addressBLL.GetById(organization.AddressId);

                addressForUpdate.Street = organization.Street;
                addressForUpdate.Number = organization.Number;
                addressForUpdate.PostCode = organization.PostCode;
                addressForUpdate.City = organization.City;
                addressForUpdate.State = organization.State;
                addressForUpdate.Province = organization.Province;
                addressForUpdate.Country = organization.Country;

                organizationBLL.Update(organizationForUpdate);
                addressBLL.Update(addressForUpdate);

                return RedirectToAction("Index");
            }
            else
            {
                return View();

            }
            //organizationDAL.Edit(organization);
        }
        #endregion


        //Details
        #region Details
        public ActionResult Details(int id)
        {
            Organization organization = organizationBLL.GetById(id);
            Models.OrganizationAddEditModel organizationViewModel = GetAllElementsFromCustomModel(organization);
            return View(organizationViewModel);
        }

        [NonAction]
        public virtual Models.OrganizationAddEditModel GetAllElementsFromCustomModel(Organization organization)
        {
            Models.OrganizationAddEditModel organizationViewModel = new Models.OrganizationAddEditModel();

            organizationViewModel.OrganizationId = organization.OrganizationId;
            organizationViewModel.OrganizationName = organization.OrganizationName;
            organizationViewModel.CompanyId = organization.CompanyId;
            organizationViewModel.VatNumber = organization.VatNumber;
            organizationViewModel.Description = organization.Description;
            organizationViewModel.Email = organization.Email;
            organizationViewModel.PhoneNumber = organization.PhoneNumber;
            organizationViewModel.Type = organization.Type;
            organizationViewModel.IsActive = organization.IsActive;
            organizationViewModel.IsDeleted = organization.IsDeleted;

            organizationViewModel.AddressId = organization.AddressId;
            organizationViewModel.Street = organization.Address.Street;
            organizationViewModel.Number = organization.Address.Number;
            organizationViewModel.PostCode = organization.Address.PostCode;
            organizationViewModel.City = organization.Address.City;
            organizationViewModel.State = organization.Address.State;
            organizationViewModel.Province = organization.Address.Province;
            organizationViewModel.Country = organization.Address.Country;

            return organizationViewModel;
        }
        #endregion



        //Delete
        #region Delete
        public ActionResult Delete(int id)
        {
            Organization organization = organizationBLL.GetById(id);
            organizationBLL.DeletePermanently(organization);
            return RedirectToAction("Index");
        }

        #endregion



    }

}