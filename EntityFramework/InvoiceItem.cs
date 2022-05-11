//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EF
{
    using System;
    using System.Collections.Generic;
    
    public partial class InvoiceItem
    {
        public int InvoiceItemId { get; set; }
        public string ItemName { get; set; }
        public int InvoiceId { get; set; }
        public Nullable<double> UnitPrice { get; set; }
        public Nullable<int> Vat { get; set; }
        public Nullable<double> VatUnitPrice { get; set; }
        public Nullable<double> Quantity { get; set; }
        public Nullable<double> PriceIncludingVat { get; set; }
        public Nullable<double> PriceExcludingVat { get; set; }
        public Nullable<double> VatAmount { get; set; }
        public Nullable<double> DiscountAmount { get; set; }
        public Nullable<double> DiscountPercentage { get; set; }
        public int IsActive { get; set; }
        public int IsDeleted { get; set; }
    
        public virtual Invoice Invoice { get; set; }
    }
}
