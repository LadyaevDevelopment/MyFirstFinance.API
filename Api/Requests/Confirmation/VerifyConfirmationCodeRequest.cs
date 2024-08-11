using System.ComponentModel.DataAnnotations;

namespace Api.Requests.Confirmation
{
	public class VerifyConfirmationCodeRequest
	{
        [Required]
        public string ConfirmationCodeId { get; set; } = "";

		[Required]
		public string ConfirmationCode { get; set; } = "";
	}
}
