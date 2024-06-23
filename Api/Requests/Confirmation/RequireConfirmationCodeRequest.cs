using System.ComponentModel.DataAnnotations;

namespace Api.Requests.Confirmation
{
    public class RequireConfirmationCodeRequest
    {
        [Required]
        public string CountryPhoneCode { get; set; } = "";

        [Required]
        public string PhoneNumber { get; set; } = "";
    }
}
