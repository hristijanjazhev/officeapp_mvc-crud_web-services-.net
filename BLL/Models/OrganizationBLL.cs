using BusinessLogicLayer;
using DAL_EF;
using DAL_EF.Models;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class OrganizationBLL
    {
         OrganizationDAL organizationDAL = new OrganizationDAL();
        AddressBLL addressBLL = new AddressBLL();
        OfferBLL offerBLL = new OfferBLL();
        //ALL
        public List<Organization> GetALL()
        {
            return organizationDAL.GetAll();
        }
        //Active
        public IEnumerable<Organization> GetAllActive()
        {
            return organizationDAL.GetAll().Where(p => p.IsActive == true && p.IsDeleted == false);
        }
        //NotActive
        public IEnumerable<Organization> GetAllNotActive()
        {
            return organizationDAL.GetAll().Where(p => p.IsActive == false && p.IsDeleted == false);
        }
        //Deleted
        public IEnumerable<Organization> GetAllDeleted()
        {
            return organizationDAL.GetAll().Where(p => p.IsActive == false && p.IsDeleted == true);
        }
        //ById
        public Organization GetById (int id)
        {
            return organizationDAL.GetById(id);
        }
        //VatNumber
        public Organization GetByVatNumber (string vatNumber)
        {
            return organizationDAL.GetAll().Where(p => p.VatNumber == vatNumber).FirstOrDefault();    
        }
        //CompanyId
        public Organization GetByCompanyId(string companyId)
        {
            return organizationDAL.GetAll().Where(p => p.CompanyId == companyId).FirstOrDefault();
        }
        //ByVatAndCompanyId
        public Organization GetByVatNumberAndByCompanyId(string vatNumber,string companyId)
        {
            return organizationDAL.GetAll().Where(p => p.VatNumber == vatNumber && p.CompanyId == companyId).FirstOrDefault();
        }
        //INSERTS
        public void Insert(Organization organization)
        {
             organizationDAL.Insert(organization);
        }
        //ReturnID
        public Int32 InsertReturnId (Organization organization)
        {
            return organizationDAL.InsertReturnId(organization);
        }
        //Update
        public void Update(Organization organization) 
        {
            organizationDAL.Update(organization);
        }
        //Delete
        public void Delete(Organization organization) 
        {
            //organization.IsActive == false;
            //organization.IsDelete == true;
            organizationDAL.Update(organization);
        }
        public void DeletePermanently(Organization organization)
        {
            List<Offer> relatedOffersForDelete = offerBLL.GetAllOffersByOrganizationId(organization.OrganizationId);
            Address addressForDelete = addressBLL.GetById(organization.AddressId);
            organizationDAL.DeletePermanently(organization);
            addressBLL.DeletePermanently(addressForDelete);
        }
        

    }
}
