using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models
{
    public class NoticeViewModel
    {
        public int NoticeId { get; set; }
        public string NoticeText { get; set; }
        public int NoticeNumber { get; set; }
        public DateTime NoticeDate { get; set; }
        public int InvoiceId { get; set; }
        public int? PersonId { get; set; }
        public int? OrganizationId { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}