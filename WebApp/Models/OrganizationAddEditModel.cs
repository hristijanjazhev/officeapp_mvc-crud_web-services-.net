using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class OrganizationAddEditModel
    {
        [Key]
        public int OrganizationId { get; set; }

        [Display(Name = "Име на организација")]
        [Required(ErrorMessage = "Задолжителен внес")]
        [StringLength(512, ErrorMessage = "Дозволени се 256 карактери")]
        public string OrganizationName { get; set; }

        [Display(Name = "Даночен број")]
        [Required(ErrorMessage = "Задолжителен внес")]
        [StringLength(50, ErrorMessage = "Дозволени се 50 карактери")]
        public string VatNumber { get; set; }

        [Display(Name = "Матичен број")]
        [Required(ErrorMessage = "Задолжителен внес")]
        [StringLength(50, ErrorMessage = "Дозволени се 50 карактери")]
        public string CompanyId { get; set; }

        [Display(Name = "Опис")]
        public string Description { get; set; }

        [Display(Name = "Адреса за е-пошта")]
        [StringLength(256, ErrorMessage = "Дозволени се 256 карактери")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        public string Email { get; set; }

        [Display(Name = "Телефонски број")]
        [StringLength(50, ErrorMessage = "Дозволени се 50 карактери")]
        [Required(ErrorMessage = "Полето е задолжително")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Тип")]
        public Nullable<int> Type { get; set; }


        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

        [Display(Name = "Адреса - Улица")]
        [StringLength(512, ErrorMessage = "Дозволени се 512 карактери")]
        [Required(ErrorMessage = "Полето е задолжително")]
        public string Street { get; set; }

        [Display(Name = "Адреса - Број")]
        [StringLength(50, ErrorMessage = "Дозволени се 50 карактери")]
        [Required(ErrorMessage = "Полето е задолжително")]
        public string Number { get; set; }

        [Display(Name = "Поштенски код")]
        [Required(ErrorMessage = "Полето е задолжително")]
        public string PostCode { get; set; }

        [Display(Name = "Град")]
        [StringLength(50, ErrorMessage = "Дозволени се 50 карактери")]
        [Required(ErrorMessage = "Полето е задолжително")]
        public string City { get; set; }

        [Display(Name = "Држава")]
        [Required(ErrorMessage = "Полето е задолжително")]
        public string State { get; set; }

        [Display(Name = "Покраина")]
        [StringLength(50, ErrorMessage = "Дозволени се 50 карактери")]
        public string Province { get; set; }

        [Display(Name = "Земја")]
        [StringLength(50, ErrorMessage = "Дозволени се 50 карактери")]
        [Required(ErrorMessage = "Полето е задолжително")]
        public string Country { get; set; }


        public int AddressId { get; set; }
    }
}