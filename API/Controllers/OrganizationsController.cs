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
using DataAccessLayer;

namespace API.Controllers
{
    public class OrganizationsController : ApiController
    {
        OrganizationBLL organizationBLL = new OrganizationBLL();
        OrganizationDAL organizationDAL = new OrganizationDAL();
        DMSEntities db = new DMSEntities();
        int organizationId;


        // GET: api/Organizations
        #region GET
        [HttpGet]
        public IHttpActionResult GetOrganizations()
        {
            {
                IEnumerable<Organization> organizations = organizationBLL.GetALL();
                List<Models.OrganizationViewModel> organizationToReturn = new List<Models.OrganizationViewModel>();

                foreach (Organization o in organizations)
                {
                    Models.OrganizationViewModel organizationModel = new Models.OrganizationViewModel();
                    organizationModel.OrganizationId = o.OrganizationId;
                    organizationModel.OrganizationName = o.OrganizationName;
                    organizationModel.CompanyId = o.CompanyId;
                    organizationModel.VatNumber = o.VatNumber;
                    organizationModel.Description = o.Description;
                    organizationModel.Email = o.Email;
                    organizationModel.PhoneNumber = o.PhoneNumber;
                    organizationModel.Type = o.Type;
                    organizationModel.AddressId = o.AddressId;
                    organizationModel.IsActive = o.IsActive;
                    organizationModel.IsDeleted = o.IsDeleted;
                    //tempAddress.IsDeleted = a.IsDeleted;
                    organizationToReturn.Add(organizationModel);
                }
                if (organizationToReturn.Count == 0)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(organizationToReturn);
                }
            }
        }
        #endregion



        //GET: api/Organizations/5
        #region Get{id}
        [HttpGet]
        [ResponseType(typeof(Organization))]
        public IHttpActionResult GetOrganization(int id)
        {
            Organization organization = db.Organizations.Find(id);
            if (organization == null)
            {
                return NotFound();
            }

            return Ok(organization);
        }
        #endregion



        //PUT: api/Organizations/5
        #region PUT
        [HttpGet]
        public IHttpActionResult EditOrganization(int id)
        {
            var organization = organizationBLL.GetById(id);
            return Ok();
        }
        [HttpPut]
        public IHttpActionResult EditOrganization(int id, Models.OrganizationViewModel organizationViewModel)
        {
            Organization newOrganization = new Organization();
            newOrganization.OrganizationId = organizationViewModel.OrganizationId;
            newOrganization.OrganizationName = organizationViewModel.OrganizationName;
            newOrganization.CompanyId = organizationViewModel.CompanyId;
            newOrganization.VatNumber = organizationViewModel.VatNumber;
            newOrganization.Description = organizationViewModel.Description;
            newOrganization.Email = organizationViewModel.Email;
            newOrganization.PhoneNumber = organizationViewModel.PhoneNumber;
            newOrganization.Type = organizationViewModel.Type;
            newOrganization.AddressId = organizationViewModel.AddressId;
            newOrganization.IsActive = organizationViewModel.IsActive;
            newOrganization.IsDeleted = organizationViewModel.IsDeleted;

           var organizations =  organizationBLL.InsertReturnId(newOrganization);

            if (!ModelState.IsValid)
            {
                return Ok(organizations);
            }
            else
            {
                return NotFound();
            }


        }
        #endregion



        //POST 
        #region POST
        [HttpPost]
        public IHttpActionResult PostOrganization(Models.OrganizationViewModel organizationViewModel)
        {
            Organization organization = new Organization();
            organizationViewModel.OrganizationId = organization.OrganizationId;
            organizationViewModel.OrganizationName = organization.OrganizationName;
            organizationViewModel.CompanyId = organization.CompanyId;
            organizationViewModel.VatNumber = organization.VatNumber;
            organizationViewModel.Description = organization.Description;
            organizationViewModel.Email = organization.Email;
            organizationViewModel.PhoneNumber = organization.PhoneNumber;
            organizationViewModel.Type = organization.Type;
            organizationViewModel.AddressId = organization.AddressId;
            organizationViewModel.IsActive = organization.IsActive;
            organizationViewModel.IsDeleted = organization.IsDeleted;

            var organizationId = organizationBLL.InsertReturnId(organization);

            return Ok(organizationId);
        }
        #endregion



        // DELETE: api/Organizations/5
        #region DELETE
        [ResponseType(typeof(Organization))]
        [HttpDelete]
        public IHttpActionResult DeleteOrganization(int id)
        {
            Organization organization = organizationDAL.GetById(id);
            organizationDAL.DeletePermanently(organization);


            return Ok(organization);


        }
    }
}
    #endregion














