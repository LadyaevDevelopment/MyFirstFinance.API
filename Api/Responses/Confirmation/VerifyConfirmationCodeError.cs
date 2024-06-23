namespace Api.Responses.Confirmation
{
	public class VerifyConfirmationCodeError(
		VerifyConfirmationCodeErrorType errorType,
		int? remainingTemporaryBlockingTimeInSeconds)
	{
		public VerifyConfirmationCodeErrorType ErrorType { get; set; } = errorType;

		public int? RemainingTemporaryBlockingTimeInSeconds { get; set; } = remainingTemporaryBlockingTimeInSeconds;
	}
}
