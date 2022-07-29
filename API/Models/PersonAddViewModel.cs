using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class PersonAddViewModel
    {
        [Key]
        public int PersonId { get; set; }

        public string PersonName { get; set; }

        public string PersonLastName { get; set; }

        public string IdNumber { get; set; }

        public string MiddleName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public int AddressId { get; set; }

        public bool IsActive { get; set; }

        public bool IsDeleted { get; set; }

        public int Gender { get; set; }

        public string EMBG { get; set; }
        //public int AddressId { get; set; }
        //public string Street { get; set; }
        //public string Number { get; set; }
        //public string PostCode { get; set; }
        //public string City { get; set; }
        //public string State { get; set; }
        //public string Province { get; set; }
        //public string Country { get; set; }

    }
}
