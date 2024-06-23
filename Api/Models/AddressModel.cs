using Domain.Entities.Addresses;
using System.ComponentModel.DataAnnotations;

namespace Api.Models
{
	public class AddressModel(string country, string city, string street, string buildingNumber)
	{
		[Required]
		public string Country { get; set; } = country;

		[Required]
		public string City { get; set; } = city;

		[Required]
		public string Street { get; set; } = street;

		[Required]
		public string BuildingNumber { get; set; } = buildingNumber;

		public static AddressModel FromEntity(Address entity)
		{
			return new(entity.Country, entity.City, entity.Street, entity.BuildingNumber);
		}
	}
}
