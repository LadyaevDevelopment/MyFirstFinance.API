using Api.Communication;
using Api.Models;
using Api.Requests.Misc;
using Api.Responses.Misc;
using Domain.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
	[ApiController]
	[Route("[controller]")]
	[AllowAnonymous]
	public class MiscController(
		ICountryRepository countryRepository,
		IPolicyDocumentRepository policyDocumentRepository,
		IAddressRepository addressRepository) : ControllerBase
	{
		[HttpGet("[action]")]
		public async Task<SimpleResponseWrapper<PolicyDocumentsResponse>> PolicyDocuments()
		{
			var documents = await policyDocumentRepository.FilteredEntities(new());
			return new SimpleResponseWrapper<PolicyDocumentsResponse>(
				new PolicyDocumentsResponse(documents.Select(PolicyDocumentModel.FromEntity).ToList()));
		}

		[HttpGet("[action]")]
		public async Task<SimpleResponseWrapper<CountriesResponse>> Countries()
		{
			var countries = await countryRepository.FilteredEntities(new());
			return new SimpleResponseWrapper<CountriesResponse>(
				new CountriesResponse(countries.Select(CountryModel.FromEntity).ToList()));
		}

		[Authorize]
		[HttpGet("[action]")]
		public async Task<SimpleResponseWrapper<AddressesResponse>> Addresses([FromQuery] AddressesRequest request)
		{
			var addresses = await addressRepository.FilteredEntities(new(request.CountryIso2Code, request.SearchQuery));
			return new SimpleResponseWrapper<AddressesResponse>(
				new AddressesResponse(addresses.Select(AddressModel.FromEntity).ToList()));
		}
	}
}
