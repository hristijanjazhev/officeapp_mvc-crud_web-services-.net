using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopWPF.Models
{
    public class Organization
    {
        public int OrganizationId { get; set; }
        public string OrganizationName { get; set; }
        public string CompanyId { get; set; }
        public string VatNumber { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Type { get; set; }
        public int AddressId { get; set; }
        public int IsActive { get; set; }
        public int IsDeleted { get; set; }
        public string FullInfo => $"{ OrganizationName } { CompanyId }";

    }
}
