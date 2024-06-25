using System;
using System.Collections.Generic;

namespace Data.Production.Models;

public partial class User
{
    public Guid Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string? MiddleName { get; set; }

    public string LastName { get; set; } = null!;

    public DateTime RegistrationDate { get; set; }

    public int StatusId { get; set; }

    public string PhoneNumber { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? AvatarPath { get; set; }

    public bool IsBlocked { get; set; }

    public virtual ICollection<ConfirmationCode> ConfirmationCodes { get; set; } = new List<ConfirmationCode>();
}
