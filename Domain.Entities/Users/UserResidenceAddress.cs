namespace Domain.Entities.Users
{
	public record UserResidenceAddress(
		Guid CountryId,
		string City,
		string Street,
		string BuildingNumber,
		string ApartmentNumber);
}
