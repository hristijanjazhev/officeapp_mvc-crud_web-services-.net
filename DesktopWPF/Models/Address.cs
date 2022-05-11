using System.ComponentModel.DataAnnotations;

namespace DesktopWPF
{
    public class Address
    {
        [Key]
        public int AddressId { get; set; }
        [Required(ErrorMessage ="This field is required.")]
        public string Street { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        public int Number { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        public int PostalCode { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        public string City { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        public string State { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        public string Province { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        public string Country { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        public int IsActive { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        public int IsDeleted { get; set; }
        public string FullInfo => $"{ Street } { Number }";
    }
}
