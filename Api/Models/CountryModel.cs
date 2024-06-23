using Domain.Entities.Countries;
using SpaceApp.Dev.ApiToMobile.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Api.Models
{
    public class CountryModel(string name, string phoneNumberCode, string flagImageUrl, string[] phoneNumberMasks)
	{
		[Required]
		public string Name { get; set; } = name;

		[Required]
		public string PhoneNumberCode { get; set; } = phoneNumberCode;

		[Required]
		public string FlagImageUrl { get; set; } = flagImageUrl;

		[Required]
		[GenericArgumentsNotNull]
		public string[] PhoneNumberMasks { get; set; } = phoneNumberMasks;

		public static CountryModel FromEntity(Country entity)
		{
			return new(entity.Name, entity.PhoneNumberCode, entity.FlagImageUrl, entity.PhoneNumberMasks);
		}
	}
}
