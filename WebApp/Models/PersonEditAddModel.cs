using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace DMS.Models
{
    public class PersonAddEditModel
    {
        [Key]
        public int PersonId { get; set; }

        [Display(Name = "Име")]
        [Required(ErrorMessage = "Задолжителен внес")]
        [StringLength(50, ErrorMessage = "Дозволени се 50 карактери")]
        public string PersonName { get; set; }

        [Display(Name = "Презиме")]
        [Required(ErrorMessage = "Задолжителен внес")]
        [StringLength(50, ErrorMessage = "Дозволени се 50 карактери")]
        public string PersonLastName { get; set; }

        [Display(Name = "ID Број")]
        [Required(ErrorMessage = "Задолжителен внес")]
        [StringLength(20, ErrorMessage = "Дозволени се 20 карактери")]
        public string IdNumber { get; set; }

        [Display(Name = "Надимак")]
        public string MiddleName { get; set; }

        [Display(Name = "Адреса за е-пошта")]
        [StringLength(256, ErrorMessage = "Дозволени се 256 карактери")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        public string Email { get; set; }

        [Display(Name = "Телефон")]
        [Required(ErrorMessage = "Задолжителен внес")]
        [StringLength(50, ErrorMessage = "Дозволени се 50 карактери")]
        public string PhoneNumber { get; set; }

        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

        [Display(Name = "Пол")]
        [Required(ErrorMessage = "Задолжителен внес")]
        public int Gender { get; set; }

        public int AddressId { get; set; }

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

    }
}