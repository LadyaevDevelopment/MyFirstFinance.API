using System;
using System.Collections.Generic;

namespace Data.Production.Models;

public partial class UserResidenceAddress
{
    public Guid Id { get; set; }

    public Guid CountryId { get; set; }

    public string City { get; set; } = null!;

    public string Street { get; set; } = null!;

    public string BuildingNumber { get; set; } = null!;

    public string ApartmentNumber { get; set; } = null!;

    public virtual Country Country { get; set; } = null!;
}
