using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Models
{
    public class AgreementAddEditModel
    {
        [Key]
        public int AgreementId { get; set; }

        [Display(Name = "Број на договор:")]
        [Required(ErrorMessage = "Задолжителен внес")]
        [StringLength(256, ErrorMessage = "Дозволени се 256 карактери")]
        public string AgreementNumber { get; set; }

        [Display(Name = "Датум на креирање:")]
        public DateTime CreateDate { get; set; }

        [Display(Name = "Почнува:")]
        public DateTime StartDate { get; set; }

        [Display(Name = "Завршува:")]
        public DateTime EndDate { get; set; }

        [Display(Name = "Наслов на договорот:")]
        [Required(ErrorMessage = "Задолжителен внес")]
        [StringLength(256, ErrorMessage = "Дозволени се 256 карактери")]
        public string Title { get; set; }

        [Display(Name = "Предмет на договор:")]
        [Required(ErrorMessage = "Задолжителен внес")]
        [StringLength(1024, ErrorMessage = "Дозволени се 1024 карактери")]
        public string Subject { get; set; }

        [AllowHtml]
        [Display(Name = "Опис на договорот:")]
        [Required(ErrorMessage = "Задолжителен внес")]
        [StringLength(4000, ErrorMessage = "Дозволени се 4000 карактери")]
        public string Body { get; set; }


        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

        [Display(Name = "Понуда број: ")]
        public int OfferId { get; set; }

    }
}