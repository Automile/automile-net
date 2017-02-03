using System.ComponentModel.DataAnnotations;

namespace Automile.Net
{
    public class CreateOrderModel
    {
        [Required(ErrorMessage = "You need to supply a company")]
        public string Company { get; set; }
        
        [Required(ErrorMessage = "You need to supply a first name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "You need to supply a last name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "You need to supply a e-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "You need to supply a number of devices")]
        public int NumberOfDevices { get; set; }

        [Required(ErrorMessage = "You need to supply a shipping street address")]
        public string ShippingAddress { get; set; }

        [Required(ErrorMessage = "You need to supply a shipping address zip code")]
        public string ShippingAddressZipCode { get; set; }

        [Required(ErrorMessage = "You need to supply a shipping address city")]
        public string ShippingAddressState { get; set; }

        [Required(ErrorMessage = "You need to supply a shipping address country")]
        public string ShippingAddressCountry { get; set; }

        [Required(ErrorMessage = "You need to supply a billing street address")]
        public string BillingAddress { get; set; }

        [Required(ErrorMessage = "You need to supply a billing address zipcode")]
        public string BillingAddressZipCode { get; set; }

        [Required(ErrorMessage = "You need to supply a billing address city")]
        public string BillingAddressState { get; set; }

        [Required(ErrorMessage = "You need to supply a billing address country")]
        public string BillingAddressCountry { get; set; }

        public bool UseShippingAddressAsBillingAddress { get; set; }

        [Required(ErrorMessage = "You need to supply a subscription currency")]
        public string SubscriptionCurrency { get; set; }

        
        [Required(ErrorMessage = "You need to supply a mobile phone number")]
        public string MobilePhoneNumber { get; set; }

        [Required(ErrorMessage = "You need to supply office phone number")]
        public string OfficePhoneNumber { get; set; }

        public int? LeadId { get; set; }
    }
}
