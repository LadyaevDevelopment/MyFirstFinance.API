namespace Api.Responses.Confirmation
{
	public class RequireConfirmationCodeResponse(
		Guid confirmationCodeId,
		int confirmationCodeLength,
		int resendTimeInSeconds,
		int allowedCodeConfirmationAttemptCount,
		int confirmationCodeLifeTimeInSeconds)
	{
		public Guid ConfirmationCodeId { get; set; } = confirmationCodeId;

		public int ConfirmationCodeLength { get; set; } = confirmationCodeLength;

		public int ResendTimeInSeconds { get; set; } = resendTimeInSeconds;

		public int AllowedCodeConfirmationAttemptCount { get; set; } = allowedCodeConfirmationAttemptCount;

		public int ConfirmationCodeLifeTimeInSeconds { get; set; } = confirmationCodeLifeTimeInSeconds;
	}
}
