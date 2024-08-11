using System.ComponentModel.DataAnnotations;

namespace Api.Responses.Confirmation
{
	public class RequireConfirmationCodeResponse(
		string confirmationCodeId,
		int confirmationCodeLength,
		int resendTimeInSeconds,
		int allowedCodeConfirmationAttemptCount,
		int confirmationCodeLifeTimeInSeconds)
	{
		[Required]
		public string ConfirmationCodeId { get; set; } = confirmationCodeId;

		public int ConfirmationCodeLength { get; set; } = confirmationCodeLength;

		public int ResendTimeInSeconds { get; set; } = resendTimeInSeconds;

		public int AllowedCodeConfirmationAttemptCount { get; set; } = allowedCodeConfirmationAttemptCount;

		public int ConfirmationCodeLifeTimeInSeconds { get; set; } = confirmationCodeLifeTimeInSeconds;
	}
}
