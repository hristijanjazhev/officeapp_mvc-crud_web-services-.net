using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models
{
    public class AddressViewModel
    {
        public int AddressId { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string PostCode { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Province { get; set; }
        public string Country { get; set; }
        public bool  IsActive { get; set; }
        public bool IsDeleted { get; set; }

    }
}