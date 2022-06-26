using DAL_EF;
using DAL_EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class InvoiceBLL
    {
        InvoiceDAL invoiceDAL = new InvoiceDAL();
        AgreementBLL agreementBLL = new AgreementBLL();

        public List<Invoice> GetAll()
        {
            return invoiceDAL.GetAll();
        }

        public Invoice GetById(Int32 id)
        {
            return invoiceDAL.GetById(id);
        }

        public void Insert(Invoice invoice)
        {
            invoiceDAL.Insert(invoice);
        }

        public Int32 InsertReturnId(Invoice invoice)
        {
            return invoiceDAL.InsertReturnId(invoice);
        }

        public void Update(Invoice invoice)
        {
            invoiceDAL.Update(invoice);
        }

        public void Delete(Invoice invoice)
        {
            invoice.IsActive = false;
            invoice.IsDeleted = true;
            invoiceDAL.Update(invoice);
        }

        public void DeletePermanently(Invoice invoice)
        {
            //List<Agreement> relatedAgreementsForDelete = agreementBLL.

            invoiceDAL.DeletePermanently(invoice);


            //List<Offer> relatedOffersForDelete = offerBLL.GetAllOffersByOrganizationId(organization.OrganizationId);
            //Address addressForDelete = addressBLL.GetById(organization.AddressId);
            //organizationDAL.DeletePermanently(organization);
            //addressBLL.DeletePermanently(addressForDelete);
        }

        public IEnumerable<Invoice> GetAllActive()
        {
            return invoiceDAL.GetAll().Where(p => p.IsActive == true && p.IsDeleted == false);
        }

        public IEnumerable<Invoice> GetAllNotActive()
        {
            return invoiceDAL.GetAll().Where(p => p.IsActive == false && p.IsDeleted == false);
        }

        public IEnumerable<Invoice> GetAllDeleted()
        {
            return invoiceDAL.GetAll().Where(p => p.IsActive == false && p.IsDeleted == true);
        }

        public Invoice GetByInvoiceNumber(string InvoiceNumber)
        {
            return invoiceDAL.GetAll().Where(p => p.InvoiceNumber == InvoiceNumber).FirstOrDefault();
        }

        public List<Invoice> GetAllInvoiceByAgreementId(int id)
        {
            return invoiceDAL.GetAll().Where(item => item.AgreementId == id).ToList();
        }

    }
}
