using Api.Models;
using SpaceApp.Dev.ApiToMobile.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Api.Responses.Misc
{
	public class AddressesResponse(List<AddressModel> addresses)
	{
		[Required]
		[GenericArgumentsNotNull]
		public List<AddressModel> Addresses { get; set; } = addresses;
	}
}
