using System.ComponentModel.DataAnnotations;

namespace Api.Requests.Confirmation
{
	public class VerifyConfirmationCodeRequest
	{
		public string ConfirmationCodeId { get; set; } = "";

		[Required]
		public string ConfirmationCode { get; set; } = "";
	}
}
