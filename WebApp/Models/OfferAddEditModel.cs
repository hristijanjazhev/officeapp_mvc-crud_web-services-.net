using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class OfferAddEditModel
    {
        [Key]

        public int OfferId { get; set; }

        public Nullable<int> OrganizationId { get; set; }

        public Nullable<int> PersonId { get; set; }

        [Display(Name = "Број на понуда")]
        [Required(ErrorMessage = "Задолжителен внес")]
        [StringLength(512, ErrorMessage = "Дозволени се 256 карактери")]
        public string OfferNumber { get; set; }

        [Display(Name = "Износ")]
        [Range(1.00, 10000.00, ErrorMessage = "Внесете вредност од 1.00 до 10000.00")]
        public double Amount { get; set; }

        [Display(Name = "Процент на попуст")]
        [Range(0.00, 50.00, ErrorMessage = "Внесете вредност од 0.00 до 50.00")]
        public Nullable<double> DiscountPercent { get; set; }

        [Display(Name = "Износ со попуст")]
        [Range(1.00, 100000.00, ErrorMessage = "Внесете вредност од 1.00 до 100000.00")]
        public Nullable<double> DiscountAmount { get; set; }

        [Display(Name = "Износ на понудата")]
        [Range(1.00, 100.00, ErrorMessage = "Внесете вредност од 1.00 до 100.00")]
        public double OfferAmount { get; set; }

        [Display(Name = "Дата на креирање")]
        public DateTime CreateDate { get; set; }

        [Display(Name = "Валидност на понудата")]
        [Required(ErrorMessage = "Задолжителен внес")]
        public int ValidityDays { get; set; }

        [Display(Name = "Датум на валидност")]
        [Required(ErrorMessage = "Задолжителен внес")]
        public System.DateTime ValidityDate { get; set; }

        [Display(Name = "Одрекување")]
        [Required(ErrorMessage = "Задолжителен внес")]
        [StringLength(256, ErrorMessage = "Дозволени се 256 карактери")]
        public string Disclaimer { get; set; }

        [Display(Name = "Наслов")]
        [Required(ErrorMessage = "Задолжителен внес")]
        [StringLength(512, ErrorMessage = "Дозволени се 512 карактери")]
        public string Title { get; set; }

        [Display(Name = "Предмет")]
        [Required(ErrorMessage = "Задолжителен внес")]
        [StringLength(1024, ErrorMessage = "Дозволени се 1024 карактери")]
        public string Subject { get; set; }

        [Display(Name = "Опис")]
        [Required(ErrorMessage = "Задолжителен внес")]
        [StringLength(1024, ErrorMessage = "Дозволени се 1024 карактери")]
        public string Body { get; set; }

        [Display(Name = "Валута")]
        [Required(ErrorMessage = "Задолжителен внес")]
        [StringLength(320, ErrorMessage = "Дозволени се 320 карактери")]
        public string Currency { get; set; }

        [Display(Name = "Вредност на валута")]
        [Range(1.00, 100.00, ErrorMessage = "Внесете вредност од 1.00 до 100.00")]
        public double CurrencyRate { get; set; }

        [Display(Name = "ДДВ")]
        [Range(1.00, 100.00, ErrorMessage = "Внесете вредност од 1.00 до 100.00")]
        public int Vat { get; set; }

        [Display(Name = "Износ на ДДВ")]
        [Range(1.00, 100.00, ErrorMessage = "Внесете вредност од 1.00 до 100.00")]
        public double VatAmount { get; set; }

        [Display(Name = "Причина за не прифаќање")]
        [Required(ErrorMessage = "Задолжителен внес")]
        [StringLength(1024, ErrorMessage = "Дозволени се 1024 карактери")]
        public string ReasonForDeclining { get; set; }

        public bool IsAccepted { get; set; }
        public bool IsDeleted { get; set; }
    }
}