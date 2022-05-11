namespace DesktopWPF
{
    public class Person
    {
        public int PersonId { get; set; }
        public string PersonFirstName { get; set; }
        public string PersonLastName { get; set; }
        public string PersonMiddleName { get; set; }
        public int IdNumber { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int AddressId { get; set; }
        public int IsActive { get; set; }
        public int IsDeleted { get; set; }
        public int Gender { get; set; }
        public string EMBG { get; set; }
        public string FullInfo => $"{ PersonFirstName } { PersonLastName }";
    }
}
