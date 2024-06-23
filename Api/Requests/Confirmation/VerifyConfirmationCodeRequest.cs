using System.ComponentModel.DataAnnotations;

namespace Api.Requests.Confirmation
{
	public class VerifyConfirmationCodeRequest
	{
		public Guid ConfirmationCodeId { get; set; }

		[Required]
		public string ConfirmationCode { get; set; } = "";
	}
}
