using System;
using System.Collections.Generic;

namespace Data.Production.Models;

public partial class Country
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public string Iso2Code { get; set; } = null!;

    public string PhoneNumberCode { get; set; } = null!;

    public string FlagImagePath { get; set; } = null!;

    public virtual ICollection<CountryPhoneNumberMask> CountryPhoneNumberMasks { get; set; } = new List<CountryPhoneNumberMask>();

    public virtual ICollection<UserResidenceAddress> UserResidenceAddresses { get; set; } = new List<UserResidenceAddress>();
}
