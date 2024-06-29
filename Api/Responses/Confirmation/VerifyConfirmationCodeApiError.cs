namespace Api.Responses.Confirmation
{
	public class VerifyConfirmationCodeApiError(
		VerifyConfirmationCodeApiErrorType errorType,
		int? temporaryBlockingTimeInSeconds)
	{
		public VerifyConfirmationCodeApiErrorType ErrorType { get; set; } = errorType;

		public int? TemporaryBlockingTimeInSeconds { get; set; } = temporaryBlockingTimeInSeconds;
	}
}
