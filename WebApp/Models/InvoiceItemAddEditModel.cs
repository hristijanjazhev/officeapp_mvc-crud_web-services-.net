using DAL_EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class InvoiceItemAddEditModel
    {
        public int InvoiceItemId { get; set; }
        public string ItemName { get; set; }
        public int InvoiceId { get; set; }
        public double UnitPrice { get; set; }
        public int Vat { get; set; }
        public double VatUnitPrice { get; set; }
        public int Quantity { get; set; }
        public double PriceIncludingVat { get; set; }
        public double PriceExcludingVat { get; set; }
        public double VatAmount { get; set; }
        public Nullable<double> DiscountAmount { get; set; }
        public Nullable<double> DiscountPersentage { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

        public virtual Invoice Invoice { get; set; }

    }
}