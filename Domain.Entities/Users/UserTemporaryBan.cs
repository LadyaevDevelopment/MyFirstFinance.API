namespace Domain.Entities.Users
{
	public record UserTemporaryBan(Guid Id, Guid UserId, DateTime StartDate, int DurationInSeconds);
}
