namespace Domain.UseCases.RequireConfirmationCode
{
	public record RequireConfirmationCodeData(
		Guid ConfirmationCodeId,
		int ConfirmationCodeLength,
		int ResendTimeInSeconds,
		int AllowedConfirmCodeAttemptCount,
		int ConfirmationCodeLifeTimeInSeconds);
}
