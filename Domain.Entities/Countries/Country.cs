namespace Domain.Entities.Countries
{
    public record Country(
        Guid Id,
        string Name,
        string Iso2Code,
        string PhoneNumberCode,
        string FlagImageUrl,
        string[] PhoneNumberMasks);
}
