using System;
using System.Collections.Generic;

namespace Data.Production.Models;

public partial class PolicyDocument
{
    public Guid Id { get; set; }

    public string Title { get; set; } = null!;

    public string Path { get; set; } = null!;
}
