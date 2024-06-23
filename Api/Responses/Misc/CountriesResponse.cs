using Api.Models;
using SpaceApp.Dev.ApiToMobile.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Api.Responses.Misc
{
	public class CountriesResponse(List<CountryModel> countries)
	{
		[Required]
		[GenericArgumentsNotNull]
		public List<CountryModel> Countries { get; set; } = countries;
	}
}
