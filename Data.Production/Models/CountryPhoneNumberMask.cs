using System;
using System.Collections.Generic;

namespace Data.Production.Models;

public partial class CountryPhoneNumberMask
{
    public Guid Id { get; set; }

    public Guid CountryId { get; set; }

    public string Mask { get; set; } = null!;

    public virtual Country Country { get; set; } = null!;
}
