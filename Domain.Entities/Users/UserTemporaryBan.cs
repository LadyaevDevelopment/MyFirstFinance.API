namespace Domain.Entities.Users
{
	public record UserTemporaryBan(Guid Id, Guid UserId, DateTimeOffset StartDate, int DurationInSeconds);
}
