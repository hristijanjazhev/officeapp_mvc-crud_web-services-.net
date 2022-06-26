using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class NoticeAddEditModel
    {
        [Key]
        public int NoticeId { get; set; }
        public string NoticeText { get; set; }
        public int NoticeNumber { get; set; }

        [Display(Name = "Датум на известување:")]
        [DataType(DataType.Date)]
        public System.DateTime NoticeDate { get; set; }
        public int InvoiceId { get; set; }
        public Nullable<int> PersonId { get; set; }
        public Nullable<int> OrganizationId { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

    }
}