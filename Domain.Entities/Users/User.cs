namespace Domain.Entities.Users
{
	public record User(
        Guid Id,
        string? LastName,
        string? FirstName,
        string? MiddleName,
        DateOnly? BirthDate,
        string? PinCode,
        string PhoneNumber,
        string? Email,
        string? AvatarPath,
        bool IsBlocked,
        DateTimeOffset RegistrationDate,
        UserStatus Status)
    {
        public List<UserTemporaryBan> UserTemporaryBans { get; set; } = [];

        public UserResidenceAddress? UserResidenceAddress { get; set; }

        public IdentityDocument? IdentityDocument { get; set; }
	}
}
