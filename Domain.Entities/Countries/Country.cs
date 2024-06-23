namespace Domain.Entities.Countries
{
    public record Country(
        string Name,
        string Iso2Code,
        string PhoneNumberCode,
        string FlagImageUrl,
        string[] PhoneNumberMasks);
}
