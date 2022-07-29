using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models
{
    public class OrganizationViewModel
    {
        public int OrganizationId { get; set; }
        public string OrganizationName { get; set; }
        public string CompanyId { get; set; }
        public string VatNumber { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int Type { get; set; }
        public int AddressId { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}