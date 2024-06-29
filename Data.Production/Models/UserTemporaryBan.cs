using System;
using System.Collections.Generic;

namespace Data.Production.Models;

public partial class UserTemporaryBan
{
    public Guid Id { get; set; }

    public Guid UserId { get; set; }

    public DateTime StartDate { get; set; }

    public int DurationInSeconds { get; set; }

    public virtual User User { get; set; } = null!;
}
