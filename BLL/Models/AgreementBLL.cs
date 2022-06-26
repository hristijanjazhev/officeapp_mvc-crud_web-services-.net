using DAL_EF;
using DAL_EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class AgreementBLL
    {
        readonly AgreementDAL agreementDAL = new AgreementDAL();

        public List<Agreement> GetAll()
        {
            return agreementDAL.GetAll();
        }

        public IEnumerable<Agreement> GetAllActive()
        {
            return agreementDAL.GetAll().Where(p => p.IsActive == true && p.IsDeleted == false);
        }

        public IEnumerable<Agreement> GetAllNotActive()
        {
            return agreementDAL.GetAll().Where(p => p.IsActive == false && p.IsDeleted == false);
        }

        public IEnumerable<Agreement> GetAllDeleted()
        {
            return agreementDAL.GetAll().Where(p => p.IsActive == false && p.IsDeleted == true);
        }

        public Agreement GetById(Int32 id)
        {
            return agreementDAL.GetById(id);
        }


        public void Insert(Agreement agreement)
        {
            agreementDAL.Insert(agreement);
        }

        public Int32 InsertReturnId(Agreement agreement)
        {
            return agreementDAL.InsertReturnId(agreement);
        }

        public void Update(Agreement agreement)
        {
            agreementDAL.Update(agreement);
        }

        public void Delete(Agreement agreement)
        {
            agreement.IsActive = false;
            agreement.IsDeleted = true;
            agreementDAL.Update(agreement);

        }
        public void DeletePermanently(Agreement agreement)
        {
            agreementDAL.DeletePermanently(agreement);

        }

        public Agreement GetByAgreementNumber(string agreementNumber)
        {
            return agreementDAL.GetAll().Where(p => p.AgreementNumber == agreementNumber).FirstOrDefault();
        }

        public List<Agreement> GetAllAgreementByOfferId(int id)
        {
            return agreementDAL.GetAll().Where(item => item.OfferId == id).ToList();
        }
    }
}
