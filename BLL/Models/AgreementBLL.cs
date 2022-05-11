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

        #region CREATE
        public void Insert(Agreement agreement)
        {
            agreementDAL.Insert(agreement);
        }

        public int InsertReturnId(Agreement agreement)
        {
            return agreementDAL.InsertReturnId(agreement);
        }
        #endregion

        #region RETRIEVE
        public List<Agreement> GetAll()
        {
            return agreementDAL.GetAll().ToList();
        }

        public Agreement GetById(int id)
        {
            return agreementDAL.GetById(id);
        }

        public List<Agreement> GetAllActive()
        {
            return agreementDAL.GetAllActive().ToList();
        }
        #endregion

        #region UPDATE
        public void Update(Agreement agreement)
        {
            agreementDAL.Update(agreement);
        }
        #endregion

        #region DELETE
        public void Delete(Agreement agreement)
        {
            agreementDAL.Delete(agreement);
        }

        public void DeletePermanently(Agreement agreement)
        {
            agreementDAL.DeletePermanently(agreement);
        }
        #endregion
    }
}
