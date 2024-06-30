using System;
using System.Collections.Generic;

namespace Data.Production.Models;

public partial class User
{
    public Guid Id { get; set; }

    public string? FirstName { get; set; }

    public string? MiddleName { get; set; }

    public DateTime RegistrationDate { get; set; }

    public string? LastName { get; set; }

    public int StatusId { get; set; }

    public DateOnly? BirthDate { get; set; }

    public string? PinCode { get; set; }

    public string PhoneNumber { get; set; } = null!;

    public string? Email { get; set; }

    public string? AvatarPath { get; set; }

    public bool IsBlocked { get; set; }

    public virtual ICollection<ConfirmationCode> ConfirmationCodes { get; set; } = new List<ConfirmationCode>();

    public virtual ICollection<IdentityDocument> IdentityDocuments { get; set; } = new List<IdentityDocument>();

    public virtual ICollection<UserTemporaryBan> UserTemporaryBans { get; set; } = new List<UserTemporaryBan>();
}
