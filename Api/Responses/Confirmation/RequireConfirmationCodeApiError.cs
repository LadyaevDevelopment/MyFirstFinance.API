namespace Api.Responses.Confirmation
{
	public class RequireConfirmationCodeApiError(
		RequireConfirmationCodeApiErrorType errorType,
		int? remainingTemporaryBlockingTimeInSeconds)
	{
		public RequireConfirmationCodeApiErrorType ErrorType { get; set; } = errorType;

		public int? RemainingTemporaryBlockingTimeInSeconds { get; set; } = remainingTemporaryBlockingTimeInSeconds;
	}
}
