namespace Api.Responses.Confirmation
{
	public class RequireConfirmationCodeResponse(
		Guid confirmationCodeId,
		int confirmationCodeLength,
		int resendTimeInSeconds,
		int allowedConfirmCodeAttemptCount,
		int confirmationCodeLifeTimeInSeconds)
	{
		public Guid ConfirmationCodeId { get; set; } = confirmationCodeId;

		public int ConfirmationCodeLength { get; set; } = confirmationCodeLength;

		public int ResendTimeInSeconds { get; set; } = resendTimeInSeconds;

		public int AllowedConfirmCodeAttemptCount { get; set; } = allowedConfirmCodeAttemptCount;

		public int ConfirmationCodeLifeTimeInSeconds { get; set; } = confirmationCodeLifeTimeInSeconds;
	}
}
