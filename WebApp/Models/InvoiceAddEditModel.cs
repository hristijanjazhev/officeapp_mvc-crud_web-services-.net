using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class InvoiceAddEditModel
    {
        [Key]
        public int InvoiceId { get; set; }
        public string InvoiceNumber { get; set; }

        [Display(Name = "Датум на креирање:")]
        [DataType(DataType.Date)]
        public System.DateTime CreateDate { get; set; }

        [Display(Name = "Датум на фактурата:")]
        [DataType(DataType.Date)]
        public System.DateTime InvoiceDate { get; set; }

        public int DueDays { get; set; }

        [Display(Name = "Истекува на:")]
        [DataType(DataType.Date)]
        public System.DateTime DueDate { get; set; }
        public double Amount { get; set; }
        public Nullable<double> DiscountAmount { get; set; }
        public Nullable<int> DiscountPercent { get; set; }
        public int Vat { get; set; }
        public double VatAmount { get; set; }
        public double TotalAmount { get; set; }
        public string Currency { get; set; }
        public double CurrencyRate { get; set; }
        public string Disclaimer { get; set; }
        public bool IsPaid { get; set; }

        [DataType(DataType.Date)]
        public Nullable<System.DateTime> PaidDate { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

        public int AgreementId { get; set; }
        public Nullable<int> PersonId { get; set; }
        public Nullable<int> OrganizationId { get; set; }
    }
}