namespace Domain.Entities.Users
{
	public record IdentityDocument(
		Guid Id,
		Guid UserId,
		bool Skipped,
		string? Path);
}
