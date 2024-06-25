namespace Domain.Entities.ConfirmationCodes
{
	public record ConfirmationCode(
		Guid Id,
		Guid UserId,
		string Code,
		DateTime CreationDate,
		ConfirmationCodeStatus Status);
}
