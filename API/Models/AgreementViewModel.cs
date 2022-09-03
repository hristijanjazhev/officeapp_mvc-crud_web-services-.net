using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models
{
    public class AgreementViewModel
    {
        public int AgreementId { get; set; }
        public int OfferId { get; set; }
        public string AgreementNumber { get; set; }
        public DateTime CreateDate { get; set; }
        public int PersonId { get; set; }
        public int InvoiceId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Title { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}