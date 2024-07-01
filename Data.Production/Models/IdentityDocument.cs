using System;
using System.Collections.Generic;

namespace Data.Production.Models;

public partial class IdentityDocument
{
    public Guid Id { get; set; }

    public Guid UserId { get; set; }

    public bool Skipped { get; set; }

    public string? Path { get; set; }

    public virtual User User { get; set; } = null!;
}
