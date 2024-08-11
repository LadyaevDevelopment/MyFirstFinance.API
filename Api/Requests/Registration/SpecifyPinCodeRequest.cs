using System.ComponentModel.DataAnnotations;

namespace Api.Requests.Registration
{
	public class SpecifyPinCodeRequest
	{
        [Required]
        public string PinCode { get; set; } = "";
	}
}
