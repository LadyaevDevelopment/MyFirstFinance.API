namespace Domain.Entities.Users
{
    public record User(
        Guid Id,
        string LastName,
        string FirstName,
        string? MiddleName,
        string PhoneNumber,
        string Email,
        string? AvatarPath,
        bool IsBlocked,
        UserStatus Status);
}
