using System;
using System.Collections.Generic;

namespace Data.Production.Models;

public partial class ConfirmationCode
{
    public Guid Id { get; set; }

    public Guid UserId { get; set; }

    public string Code { get; set; } = null!;

    public DateTime CreationDate { get; set; }

    public int StatusId { get; set; }

    public int FailedCodeConfirmationAttemptCount { get; set; }

    public virtual User User { get; set; } = null!;
}
