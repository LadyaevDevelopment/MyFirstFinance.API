namespace Domain.Entities.Users
{
	public record IdentityDocument(
		Guid Id,
		bool Skipped,
		byte[] Content);
}
