using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models
{
    public class InvoiceViewModel
    {
        public int InvoiceId { get; set; }
        public int AgreementId { get; set; }
        public string InvoiceNumber { get; set; }
        public int PersonId { get; set; }
        public int OrganizationId { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime InvoiceDate { get; set; }
        public int DueDays { get; set; }
        public DateTime DueDate { get; set; }
        public double Amount { get; set; }
        public double? DiscountAmount { get; set; }
        public int?  DiscountPercent { get; set; }
        public int Vat { get; set; }
        public double VatAmount { get; set; }
        public double TotalAmount { get; set; }
        public string Currency { get; set; }
        public double CurrencyRate { get; set; }
        public string Disclaimer { get; set; }
        public bool IsPaid { get; set; }
        public DateTime? PaidDate { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

    }
}