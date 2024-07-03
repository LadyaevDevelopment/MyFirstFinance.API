namespace Domain.Entities.ConfirmationCodes
{
	public record ConfirmationCode(
		Guid Id,
		Guid UserId,
		string Code,
        DateTimeOffset CreationDate,
		ConfirmationCodeStatus Status,
		int FailedCodeConfirmationAttemptCount);
}
