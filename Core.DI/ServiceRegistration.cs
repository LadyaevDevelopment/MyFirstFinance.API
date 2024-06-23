using Data.Mock.Addresses;
using Data.Mock.Countries;
using Data.Mock.PolicyDocuments;
using Data.Mock.Users;
using Domain.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace Core.DI
{
	public static class ServiceRegistration
	{
		public static void Register(IServiceCollection services)
		{
			services.AddScoped<IUserRepository, UserRepositoryMock>();
			services.AddScoped<ICountryRepository, CountryRepositoryMock>();
			services.AddScoped<IPolicyDocumentRepository, PolicyDocumentRepositoryMock>();
			services.AddScoped<IAddressRepository, AddressRepositoryMock>();
		}
	}
}
