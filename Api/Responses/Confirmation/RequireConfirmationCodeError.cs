namespace Api.Responses.Confirmation
{
	public class RequireConfirmationCodeError(
		RequireConfirmationCodeErrorType errorType,
		int? remainingTemporaryBlockingTimeInSeconds)
	{
		public RequireConfirmationCodeErrorType ErrorType { get; set; } = errorType;

		public int? RemainingTemporaryBlockingTimeInSeconds { get; set; } = remainingTemporaryBlockingTimeInSeconds;
	}
}
