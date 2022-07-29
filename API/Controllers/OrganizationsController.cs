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

namespace API.Controllers
{
    public class OrganizationsController : ApiController
    {
        OrganizationBLL organizationBLL = new OrganizationBLL();
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
                    organizationModel.Type = (int)o.Type;
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
        [HttpPut]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutOrganization(int id, Organization organization)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != organization.OrganizationId)
            {
                return BadRequest();
            }

            db.Entry(organization).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrganizationExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }
        #endregion



        //POST 
        #region POST
        [ResponseType(typeof(Organization))]
        public IHttpActionResult PostOrganization(Organization organization)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Organizations.Add(organization);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = organization.OrganizationId }, organization);
        }
        #endregion



        // DELETE: api/Organizations/5
        #region DELETE
        [ResponseType(typeof(Organization))]
        [HttpDelete]
        public IHttpActionResult DeleteOrganization(int id)
        {
            Organization organization = db.Organizations.Find(id);
            if (organization == null)
            {
                return NotFound();
            }

            db.Organizations.Remove(organization);
            db.SaveChanges();

            return Ok(organization);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool OrganizationExists(int id)
        {
            return db.Organizations.Count(e => e.OrganizationId == id) > 0;
        }
    }
}
    #endregion


















//[HttpPost]
//[Route("api/[controller]")]
//[ResponseType(typeof(Organization))]
//public IHttpActionResult Create(Models.OrganizationViewModel newOrganization)
//{
//    Organization newOrgToInsert = new Organization();

//    newOrgToInsert.OrganizationId = newOrganization.OrganizationId;
//    newOrgToInsert.OrganizationName = newOrganization.OrganizationName;
//    newOrgToInsert.CompanyId = newOrganization.CompanyId;
//    newOrgToInsert.VatNumber = newOrganization.VatNumber;
//    newOrgToInsert.Description = newOrganization.Description;
//    newOrgToInsert.Email = newOrganization.Email;
//    newOrgToInsert.PhoneNumber = newOrganization.PhoneNumber;
//    newOrgToInsert.Type = newOrganization.Type;
//    newOrgToInsert.AddressId = newOrganization.AddressId;
//    newOrgToInsert.IsActive = newOrganization.IsActive;
//    newOrgToInsert.IsDeleted = newOrganization.IsDeleted;

//    var organizaionId = organizationBLL.InsertReturnId(newOrgToInsert);

//    return Ok();
//}





// POST: api/Organizations



