using DAL_EF;
using DAL_EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class OrganizationBLL
    {
        readonly OrganizationDAL organizationDAL = new OrganizationDAL();

        #region CREATE
        public void Insert(Organization organization)
        {
            organizationDAL.Insert(organization);
        }

        public int InsertReturnId(Organization organization)
        {
            return organizationDAL.InsertReturnId(organization);
        }
        #endregion

        #region RETRIEVE
        public List<Organization> GetAll()
        {
            return organizationDAL.GetAll().ToList();
        }

        public Organization GetById(int id)
        {
            return organizationDAL.GetById(id);
        }

        public List<Organization> GetAllActive()
        {
            return organizationDAL.GetAllActive().ToList();
        }
        #endregion

        #region UPDATE
        public void Update(Organization organization)
        {
            organizationDAL.Update(organization);
        }
        #endregion

        #region DELETE
        public void Delete(Organization organization)
        {
            organizationDAL.Delete(organization);
        }

        public void DeletePermanently(Organization organization)
        {
            organizationDAL.DeletePermanently(organization);
        }
        #endregion
    }
}
