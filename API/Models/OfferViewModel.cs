using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models
{
    public class OfferViewModel
    {
        public int OfferId { get; set; }
        public Nullable<int> OrganizationId { get; set; }
        public Nullable<int> PersonId { get; set; }
        public int InvoiceItemId { get; set; }
        public string OfferNumber { get; set; }
        public double Amount { get; set; }
        public Nullable<double> DiscountPercent { get; set; }
        public Nullable<double> DiscountAmount { get; set; }
        public double OfferAmount { get; set; }
        public DateTime CreateDate { get; set; }
        public int ValidityDays { get; set; }
        public System.DateTime ValidityDate { get; set; }
        public string Disclaimer { get; set; }
        public string Title { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public string Currency { get; set; }
        public double CurrencyRate { get; set; }
        public int Vat { get; set; }
        public double VatAmount { get; set; }
        public string ReasonForDeclining { get; set; }
        public bool IsAccepted { get; set; }
        public bool IsDeleted { get; set; }
    }
}

