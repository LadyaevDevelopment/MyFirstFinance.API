namespace Domain.UseCases.VerifyConfirmationCode
{
	public record VerifyConfirmationCodeError(
		VerifyConfirmationCodeErrorType ErrorType,
		int? TemporaryBlockingTimeInSeconds,
		Exception? Exception);
}
