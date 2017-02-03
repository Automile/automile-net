using System.ComponentModel.DataAnnotations;

namespace Automile.Net
{
    public class ProOrderModel
    {
        public string ISO4217CurrencyCode { get; set; }

        public int NumberOfUnits { get; set; }

        public bool NonOBDUnits { get; set; }

        public bool ExtensionCables { get; set; }

        public int NumberOfExtensionCords { get; set; }

        [Required(ErrorMessage = "You need to supply a company name")]
        public string CompanyName { get; set; }

        [Required(ErrorMessage = "You need to supply a first name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "You need to supply a last name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "You need to supply an email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "You need to supply a mobile phone number")]
        public string MobilePhoneNumber { get; set; }

        public AddressModel ShippingAddress { get; set; }

        public bool UseShippingAddressForBillingAddress { get; set; }

        public AddressModel BillingAddress { get; set; }
    }
}